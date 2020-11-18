using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class TestHexagonView : AnimatedGameEntityView
    {
        public TestHexagonView(GameEntity gameEntity) : base(gameEntity)
        {
            Sprite = SpriteStorage.Hexagon;
            AnimatorController = AnimatorControllerStorage.TestHexagon;
        }
    }
}