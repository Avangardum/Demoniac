using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class PlayerCharacterView : AnimatedGameEntityView
    {
        public PlayerCharacterView(GameEntity gameEntity) : base(gameEntity)
        {
            Sprite = SpriteStorage.Square;
            _spriteRenderer.color = Color.green;
            AnimatorController = AnimatorControllerStorage.PlayerCharacter;
        }
    }
}