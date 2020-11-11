using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public abstract class GameEntity
    {
        public Vector2 Position;
        public Vector2 Size;

        public virtual void FrameAction(float frameTime) { }
    } 
}
