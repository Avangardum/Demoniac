using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityView
    {
        public readonly GameEntity GameEntity;
        public GameEntityViewStorage Storage;
        
        private readonly GameObject _gameObject;
        private readonly SpriteRenderer _spriteRenderer;

        public GameEntityView(GameEntity gameEntity)
        {
            GameEntity = gameEntity;
            _gameObject = new GameObject("GameEntityView");
            _gameObject.transform.localPosition = gameEntity.Position;
            _gameObject.transform.localScale = gameEntity.Size;
            _spriteRenderer = _gameObject.AddComponent<SpriteRenderer>();
            _spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Square");

            GameEntity.PositionChanged += SetPosition;
            GameEntity.SizeChanged += SetSize;
            GameEntity.Deleted += Delete;
        }
        
        private void SetPosition(Vector2 position) => _gameObject.transform.position = position;
        
        private void SetSize(Vector2 size) { }

        private void Delete()
        {
            Object.Destroy(_gameObject);
            Storage.Remove(this);
        }
    }
}