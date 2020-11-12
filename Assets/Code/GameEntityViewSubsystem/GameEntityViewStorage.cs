using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewStorage : IEnumerable<GameEntityView>
    {
        private readonly List<GameEntityView> _gameEntityViews = new List<GameEntityView>();
        //private readonly Dictionary<Type, Func<GameEntity, GameEntityView>> _viewCreationMethods;
        private GameEntityStorage _gameEntityStorage;
        private SpriteStorage _spriteStorage;
        private AnimatorControllerStorage _animatorControllerStorage;

        // public GameEntityViewStorage()
        // {
        //     _viewCreationMethods = new Dictionary<Type, Func<GameEntity, GameEntityView>>()
        //     {
        //         {typeof(TestGameEntity), gameEntity => new TestGameEntityView(gameEntity, _spriteLoader["Square"])}
        //     };
        // }
        
        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade, SpriteStorage spriteStorage, AnimatorControllerStorage animatorControllerStorage)
        {
            _gameEntityStorage = gameEntityModelSubsystemFacade.GameEntityStorage;
            _spriteStorage = spriteStorage;
            _animatorControllerStorage = animatorControllerStorage;
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
            if (gameEntity is TestSquare)
                Add(new TestSquareView(gameEntity, _spriteStorage.Square));
            else if (gameEntity is TestCircle)
                Add(new TestCircleView(gameEntity, _spriteStorage.Cirlce));
            else if (gameEntity is TestHexagon)
                Add(new TestHexagonView(gameEntity ,_animatorControllerStorage.TestHexagon));
            else
                throw new Exception($"Cannot create view for {gameEntity.GetType()}");
        }
        
        private void OnGameEntityDeleted(GameEntity gameEntity)
        {
            GameEntityView view = _gameEntityViews.Single(x => x.GameEntity == gameEntity);
            Remove(view);
        }
    }
}