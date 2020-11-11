using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demoniac.GameEntityModelSubsystem;
using Demoniac.GameManagerSubsystem;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewStorage : IEnumerable<GameEntityView>
    {
        private readonly List<GameEntityView> _gameEntityViews = new List<GameEntityView>();
        
        private GameEntityStorage _gameEntityStorage;

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _gameEntityStorage = gameEntityModelSubsystemFacade.GameEntityStorage;
            _gameEntityStorage.GameEntityCreated += OnGameEntityCreated;
            _gameEntityStorage.GameEntityDeleted += OnGameEntityDeleted;
        }

        public IEnumerator<GameEntityView> GetEnumerator()
        {
            return _gameEntityViews.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _gameEntityViews).GetEnumerator();
        }
        
        private GameEntityView this[int i] => _gameEntityViews[i];

        private void Add(GameEntityView item)
        {
            _gameEntityViews.Add(item);
            item.Storage = this;
        }

        /// <summary>
        /// Убирает объект их хранилища, но не удаляет его. Вызывать только из GameEntityView.Delete()
        /// </summary>
        public void Remove(GameEntityView item)
        {
            _gameEntityViews.Remove(item);
            item.Storage = null;
        }

        private void RemoveViewOfGameEntity(GameEntity gameEntity)
        {
            Remove(_gameEntityViews.Single(x => x.GameEntity == gameEntity));
        }

        private void OnGameEntityCreated(GameEntity gameEntity)
        {
            Add(new GameEntityView(gameEntity));
        }
        
        private void OnGameEntityDeleted(GameEntity gameEntity)
        {
            GameEntityView view = _gameEntityViews.Single(x => x.GameEntity == gameEntity);
            Remove(view);
        }
    }
}