using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class TestSquareView : GameEntityView
    {
        public TestSquareView(GameEntity gameEntity) : base(gameEntity)
        {
            TestSquare testSquare = (TestSquare)gameEntity;
            testSquare.ColorChanged += ChangeColor;
            Sprite = SpriteStorage.Square;
        }

        private void ChangeColor()
        {
            Color color = Random.ColorHSV();
            color.a = 1;
            _spriteRenderer.color = color;
        }
    }
}