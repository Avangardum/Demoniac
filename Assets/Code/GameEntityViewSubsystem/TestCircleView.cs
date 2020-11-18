using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class TestCircleView : GameEntityView
    {
        public TestCircleView(GameEntity gameEntity) : base(gameEntity)
        {
            Sprite = SpriteStorage.Cirlce;
        }
    }
}