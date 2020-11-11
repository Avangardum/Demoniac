using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class PlayerCharacter : GameEntity
    {
        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);
        }

        public PlayerCharacter(Vector2 position, Vector2 size) : base(position, size)
        {
        }
    } 
}
