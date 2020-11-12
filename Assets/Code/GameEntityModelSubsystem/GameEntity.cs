using System;
using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public abstract class GameEntity
    {
        public event Action Deleted;
        public event Action<Vector2> PositionChanged;
        public event Action<Vector2> SizeChanged;

        public GameEntityStorage Storage;
        
        private Vector2 _position;
        private Vector2 _size;

        public GameEntity(Vector2 position, Vector2 size)
        {
            _position = position;
            _size = size;
        }
        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(_position);
            }
        }

        public Vector2 Size
        {
            get => _size;
            set
            {
                _size = value;
                SizeChanged?.Invoke(_size);
            }
        }

        public virtual void FrameAction(float frameTime) { }

        public virtual void Delete()
        {
            Storage.Remove(this);
            Deleted?.Invoke();
        }

        public void Move(Vector2 move) => Position += move;
        public void Move(float x, float y) => Move(new Vector2(x, y));
    } 
}
