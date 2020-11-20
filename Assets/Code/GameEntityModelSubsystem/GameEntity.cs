using System;
using System.Diagnostics.Contracts;
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

        public GameEntity(Vector2 position)
        {
            Position = position;
            Size = Vector2.one;
            RecalculateCorners();
            PositionChanged += RecalculateCorners;
            SizeChanged += RecalculateCorners;
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
                HalfSize = value / 2;
                SizeChanged?.Invoke(_size);
            }
        }

        public Vector2 HalfSize { get; private set; }
        public Vector2 BottomLeft { get; private set; }
        public Vector2 BottomRight { get; private set; }
        public Vector2 TopLeft { get; private set; }
        public Vector2 TopRight { get; private set; }

        public virtual void FrameAction(float frameTime) { }

        public virtual void Delete()
        {
            Storage.Remove(this);
            Deleted?.Invoke();
        }

        public void Move(Vector2 move) => Position += move;
        public void Move(float x, float y) => Move(new Vector2(x, y));

        private void RecalculateCorners()
        {
            TopRight = Position + HalfSize;
            BottomLeft = Position - HalfSize;
            TopLeft = Position + new Vector2(-HalfSize.x, HalfSize.y);
            BottomRight = Position + new Vector2(HalfSize.x, -HalfSize.y);
        }

        private void RecalculateCorners(Vector2 arg) => RecalculateCorners();//Аргумент не используется и нужен только для соотвествия делегату Action<float>

        public bool Overlaps(GameEntity other)
        {
            if ( Mathf.Abs(Position.x - other.Position.x) > HalfSize.x + other.HalfSize.x ) return false;
            if ( Mathf.Abs(Position.y - other.Position.y) > HalfSize.y + other.HalfSize.y ) return false;
            return true;
        }

        public bool OverlapsWithBottom(GameEntity other)
        {
            return this.BottomLeft.y <= other.TopLeft.y &&
                   this.BottomLeft.y >= other.BottomLeft.y &&
                   this.BottomRight.x >= other.TopLeft.x &&
                   this.BottomLeft.x <= other.TopRight.x;
        }
        public bool OverlapsWithTop(GameEntity other)
        {
            throw new NotImplementedException();
        }
        public bool OverlapsWithLeft(GameEntity other)
        {
            throw new NotImplementedException();
        }
        public bool OverlapsWithRight(GameEntity other)
        {
            throw new NotImplementedException();
        }
    } 
}
