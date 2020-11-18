using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public abstract class SolidTerrainElement : GameEntity
    {
        protected SolidTerrainElement(Vector2 position) : base(position)
        {
        }
    }
}