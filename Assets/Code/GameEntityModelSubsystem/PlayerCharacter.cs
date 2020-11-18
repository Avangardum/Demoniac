using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class PlayerCharacter : GameEntity
    {
        private const float Gravity = -9.8f;
        private const float MAXVerticalSpeedAbs = 10;

        private Vector2 _velocity;
        
        public PlayerCharacter(Vector2 position) : base(position)
        {
        }
        
        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);
            _velocity.y += Gravity * frameTime;
            _velocity.y = Mathf.Clamp(_velocity.y, -MAXVerticalSpeedAbs, MAXVerticalSpeedAbs);
            
            Move(_velocity * frameTime);
        }
    } 
}
