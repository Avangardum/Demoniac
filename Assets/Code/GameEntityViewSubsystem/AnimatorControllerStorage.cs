using System.Collections.Generic;
using UnityEngine;

namespace Demoniac.GameEntityViewSubsystem
{
    public class AnimatorControllerStorage
    {
        private const string TestHexagonPath = "Animator Controllers/Test Hexagon";
        private const string PlayerCharacterPath = "Animator Controllers/Player Character";
        
        public readonly RuntimeAnimatorController TestHexagon = Resources.Load<RuntimeAnimatorController>(TestHexagonPath);
        public readonly RuntimeAnimatorController PlayerCharacter = Resources.Load<RuntimeAnimatorController>(PlayerCharacterPath);
    }
}