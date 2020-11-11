using System;
using System.Collections;
using System.Collections.Generic;
using Demoniac.GameManagerSubsystem;

namespace Demoniac.GameEntityModelSubsystem
{
    public class GameEntityStorage : IEnumerable<GameEntity>
    {
        private GameManagerSubsystemFacade GameManagerSubsystemFacade;

        private List<GameEntity> gameEntities;

        public event Action GameEntitiesChanged;

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            GameManagerSubsystemFacade = gameManagerSubsystemFacade;
            GameManagerSubsystemFacade.UnityMethodListener.FixedUpdate_ += FrameAction;
        }

        public GameEntity this[int i]
        {
            get => gameEntities[i];
        }

        public IEnumerator<GameEntity> GetEnumerator()
        {
            return ((IEnumerable<GameEntity>)gameEntities).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<GameEntity>)gameEntities).GetEnumerator();
        }

        public void Add(GameEntity item) => gameEntities.Add(item);

        public void Remove(GameEntity item) => gameEntities.Remove(item);

        public void RemoveAt(int index) => gameEntities.RemoveAt(index);

        private void FrameAction(float frameTime)
        {
            foreach (var entity in this)
                entity.FrameAction(frameTime);
            GameEntitiesChanged?.Invoke();
        }
    } 
}
