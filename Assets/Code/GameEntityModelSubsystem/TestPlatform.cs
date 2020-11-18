using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class TestPlatform : SolidTerrainElement
    {
        public TestPlatform(Vector2 position) : base(position)
        {
            Size = new Vector2(10, 1);
        }
    }
}