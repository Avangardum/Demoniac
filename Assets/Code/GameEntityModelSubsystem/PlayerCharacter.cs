using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class PlayerCharacter : GameEntity
    {
        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);
        }

        public PlayerCharacter(Vector2 position) : base(position)
        {
        }
    } 
}
