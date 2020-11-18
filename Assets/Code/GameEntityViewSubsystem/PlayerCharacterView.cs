using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class PlayerCharacterView : AnimatedGameEntityView
    {
        public PlayerCharacterView(GameEntity gameEntity) : base(gameEntity)
        {
            Sprite = SpriteStorage.Square;
            AnimatorController = AnimatorControllerStorage.PlayerCharacter;
        }
    }
}