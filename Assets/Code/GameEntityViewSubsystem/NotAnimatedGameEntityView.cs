using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public abstract class NotAnimatedGameEntityView : GameEntityView
    {
        protected NotAnimatedGameEntityView(GameEntity gameEntity, Sprite sprite) : base(gameEntity)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}