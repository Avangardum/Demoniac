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

        public GameEntity(Vector2 position)
        {
            Position = position;
            Size = Vector2.one;
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

        public virtual void FrameAction(float frameTime) { }

        public virtual void Delete()
        {
            Storage.Remove(this);
            Deleted?.Invoke();
        }

        public void Move(Vector2 move) => Position += move;
        public void Move(float x, float y) => Move(new Vector2(x, y));
        
        /// <summary>
        /// Пересекается ли данный объект с другим
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Overlaps(GameEntity other)
        {
            Vector2 overlapAmount = OverlapAmount(other);
            return overlapAmount.x > 0 && overlapAmount.y > 0;
        }
        /// <summary>
        /// Пересекался ли бы данный объект с другим, если бы данный объект имел другую позицию
        /// </summary>
        /// <param name="other"></param>
        /// <param name="assumedPositon"></param>
        /// <returns></returns>
        public bool OverlapsAssumePosition(GameEntity other, Vector2 assumedPositon)
        {
            Vector2 overlapAmount = OverlapAmountAssumePosition(other, assumedPositon);
            return overlapAmount.x > 0 && overlapAmount.y > 0;
        }

        private static Vector2 OverlapAmount(Vector2 entity1Pos, Vector2 entity2Pos, Vector2 entity1HalfSize, Vector2 entity2HalfSize)
        {
            float xDistance = Mathf.Abs(entity1Pos.x - entity2Pos.x);
            float yDistance = Math.Abs(entity1Pos.y - entity2Pos.y);
            float xHalfSizeSum = entity1HalfSize.x + entity2HalfSize.x;
            float yHalfSizeSum = entity1HalfSize.y + entity2HalfSize.y;
            float xOverlapAmount = xHalfSizeSum - xDistance;
            float yOverlapAmount = yHalfSizeSum - yDistance;
            return new Vector2(xOverlapAmount, yOverlapAmount);
        }
        /// <summary>
        /// Насколько сильно пересекается данный объект с другим
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vector2 OverlapAmount(GameEntity other)
        {
            return OverlapAmount(this.Position, other.Position, this.HalfSize, other.HalfSize);
        }
        /// <summary>
        /// Насколько сильно бы данный объект пересекался с другим, если бы данный объект имел другую позицию
        /// </summary>
        /// <param name="other"></param>
        /// <param name="assumedPosition"></param>
        /// <returns></returns>
        public Vector2 OverlapAmountAssumePosition(GameEntity other, Vector2 assumedPosition)
        {
            return OverlapAmount(assumedPosition, other.Position, this.HalfSize, other.HalfSize);
        }
    } 
}
