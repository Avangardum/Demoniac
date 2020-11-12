using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class TestSquareView : NotAnimatedGameEntityView
    {
        public TestSquareView(GameEntity gameEntity, Sprite sprite) : base(gameEntity, sprite)
        {
            TestSquare testSquare = (TestSquare)gameEntity;
            testSquare.ColorChanged += ChangeColor;
        }

        private void ChangeColor()
        {
            Color color = Random.ColorHSV();
            color.a = 1;
            _spriteRenderer.color = color;
        }
    }
}