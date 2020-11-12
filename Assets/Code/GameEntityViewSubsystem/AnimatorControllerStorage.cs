using System.Collections.Generic;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class AnimatorControllerStorage
    {
        private const string TestHexagonPath = "Animator Controllers/Test Hexagon";
        
        public readonly RuntimeAnimatorController TestHexagon = Resources.Load<RuntimeAnimatorController>(TestHexagonPath);
    }
}