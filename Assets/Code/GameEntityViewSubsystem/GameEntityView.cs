using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public abstract class GameEntityView
    {
        public readonly GameEntity GameEntity;
        public GameEntityViewStorage Storage;

        protected readonly GameObject _gameObject;
        protected readonly SpriteRenderer _spriteRenderer;

        protected GameEntityView(GameEntity gameEntity)
        {
            GameEntity = gameEntity;
            _gameObject = new GameObject(GetType().Name);
            _gameObject.transform.localPosition = gameEntity.Position;
            _gameObject.transform.localScale = gameEntity.Size;
            _spriteRenderer = _gameObject.AddComponent<SpriteRenderer>();

            GameEntity.PositionChanged += SetPosition;
            GameEntity.SizeChanged += SetSize;
            GameEntity.Deleted += Delete;
        }
        
        private void SetPosition(Vector2 position) => _gameObject.transform.position = position;

        private void SetSize(Vector2 size) => _gameObject.transform.localScale = new Vector3(size.x, size.y, 1);

        private void Delete()
        {
            Object.Destroy(_gameObject);
            Storage.Remove(this);
        }
    }
}