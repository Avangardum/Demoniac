using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demoniac.GameEntityModelSubsystem;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewStorage : IEnumerable<GameEntityView>
    {
        private readonly List<GameEntityView> _gameEntityViews = new List<GameEntityView>();

        private readonly Dictionary<Type, Type> _gameEntityViewTypes = new Dictionary<Type, Type>()
        {
            {typeof(TestSquare), typeof(TestSquareView)},
            {typeof(TestCircle), typeof(TestCircleView)},
            {typeof(TestHexagon), typeof(TestHexagonView)},
            {typeof(PlayerCharacter), typeof(PlayerCharacterView)},
            {typeof(TestPlatform), typeof(TestPlatformView)}
        };
        private GameEntityStorage _gameEntityStorage;
        private SpriteStorage _spriteStorage;
        private AnimatorControllerStorage _animatorControllerStorage;

        public GameEntityViewStorage()
        {
            
        }
        
        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade, SpriteStorage spriteStorage, AnimatorControllerStorage animatorControllerStorage)
        {
            _gameEntityStorage = gameEntityModelSubsystemFacade.GameEntityStorage;
            _spriteStorage = spriteStorage;
            _animatorControllerStorage = animatorControllerStorage;
            _gameEntityStorage.GameEntityCreated += OnGameEntityCreated;
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
            Type viewType = _gameEntityViewTypes[gameEntity.GetType()];
            GameEntityView view = (GameEntityView)Activator.CreateInstance(viewType, gameEntity);
            Add(view);
        }
    }
}