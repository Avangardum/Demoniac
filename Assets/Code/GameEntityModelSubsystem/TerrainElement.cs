using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public abstract class TerrainElement : GameEntity
    {
        protected TerrainElement(Vector2 position) : base(position)
        {
        }
    }
}