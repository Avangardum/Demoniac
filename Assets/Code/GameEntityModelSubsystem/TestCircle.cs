using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class TestCircle : GameEntity
    {
        private const float Speed = 1;
        private const float ScalingSpeed = 0.5f;
        private const float MINSize = 0.5f;
        private const float MAXSize = 1.5f;

        private float _currentSize = 1;
        private bool _isGrowing = true;
        
        public TestCircle(Vector2 position) : base(position, Vector2.one)
        {
        }

        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);
            Move(Speed * frameTime, 0);
            
            float sizeDelta = ScalingSpeed * frameTime * (_isGrowing ? 1 : -1);
            _currentSize += sizeDelta;
            while (_currentSize > MAXSize || _currentSize < MINSize)
            {
                if (_currentSize > MAXSize)
                {
                    float overflow = _currentSize - MAXSize;
                    _currentSize = MAXSize - overflow;
                    _isGrowing = false;
                }
                else if (_currentSize < MINSize)
                {
                    float overflow = MINSize - _currentSize;
                    _currentSize = MINSize + overflow;
                    _isGrowing = true;
                }
            }
            Size = Vector2.one * _currentSize;
        }
    }
}