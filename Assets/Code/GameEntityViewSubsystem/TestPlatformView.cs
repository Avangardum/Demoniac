using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class TestPlatformView : GameEntityView
    {
        public TestPlatformView(GameEntity gameEntity) : base(gameEntity)
        {
            Sprite = SpriteStorage.Square;
        }
    }
}