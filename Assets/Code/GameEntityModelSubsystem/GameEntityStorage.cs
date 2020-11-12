using System;
using System.Collections;
using System.Collections.Generic;
using Demoniac.GameManagerSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class GameEntityStorage : IEnumerable<GameEntity>
    {
        private GameManagerSubsystemFacade _gameManagerSubsystemFacade;

        private readonly List<GameEntity> _gameEntities = new List<GameEntity>();

        public event Action<GameEntity> GameEntityCreated;
        public event Action<GameEntity> GameEntityDeleted; 

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            _gameManagerSubsystemFacade = gameManagerSubsystemFacade;
            _gameManagerSubsystemFacade.UnityMethodListener._FixedUpdate += FrameAction;
        }

        public GameEntity this[int i]
        {
            get => _gameEntities[i];
        }

        public IEnumerator<GameEntity> GetEnumerator()
        {
            return ((IEnumerable<GameEntity>)_gameEntities).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<GameEntity>)_gameEntities).GetEnumerator();
        }

        public void Add(GameEntity item)
        {
            _gameEntities.Add(item);
            item.Storage = this;
            GameEntityCreated?.Invoke(item);
        }
        /// <summary>
        /// Убирает объект их хранилища, но не удаляет его. Вызывать только из GameEntity.Delete()
        /// </summary>
        public void Remove(GameEntity item)
        {
            _gameEntities.Remove(item);
            item.Storage = null;
            GameEntityDeleted?.Invoke(item);
        }

        public void CreateTestSquare(Vector2 position, Vector2 size)
        {
            var item = new TestSquare(position, size);
            Add(item);
        }

        public void CreateTestCircle(Vector2 position)
        {
            Add(new TestCircle(position));
        }

        private void FrameAction(float frameTime)
        {
            foreach (var entity in this)
                entity.FrameAction(frameTime);
        }
    }
}
