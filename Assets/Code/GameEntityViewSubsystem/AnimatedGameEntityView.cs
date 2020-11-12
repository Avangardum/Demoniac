using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class AnimatedGameEntityView : GameEntityView
    {
        private Animator _animator;
        private RuntimeAnimatorController _animatorController;
        
        public AnimatedGameEntityView(GameEntity gameEntity, RuntimeAnimatorController animatorController) : base(gameEntity)
        {
            _animatorController = animatorController;
            _animator = _gameObject.AddComponent<Animator>();
            _animator.runtimeAnimatorController = animatorController;
        }
    }
}