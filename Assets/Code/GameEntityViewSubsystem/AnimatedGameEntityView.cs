using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public abstract class AnimatedGameEntityView : GameEntityView
    {
        protected static AnimatorControllerStorage AnimatorControllerStorage;
        
        protected readonly Animator Animator;
        
        protected AnimatedGameEntityView(GameEntity gameEntity) : base(gameEntity)
        {
            Animator = _gameObject.AddComponent<Animator>();
        }

        protected RuntimeAnimatorController AnimatorController
        {
            get => Animator.runtimeAnimatorController;
            set => Animator.runtimeAnimatorController = value;
        }
        
        public static void InjectDependenciesStatic(AnimatorControllerStorage animatorControllerStorage)
        {
            AnimatorControllerStorage = animatorControllerStorage;
        }
    }
}