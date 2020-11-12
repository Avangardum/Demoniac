using Demoniac.GameManagerSubsystem;

namespace Demoniac.PlayerInputSubsystem
{
    public class PlayerInputSubsystemFacade
    {
        public float Horisontal => _keyboardAndGamepadPlayerInput.Horizontal;
        public bool Jump => _keyboardAndGamepadPlayerInput.Jump;
        public bool Menu => _keyboardAndGamepadPlayerInput.Menu;
        public bool Submit => _keyboardAndGamepadPlayerInput.Submit;
        public bool Cancel => _keyboardAndGamepadPlayerInput.Cancel;
        
        private KeyboardAndGamepadPlayerInput _keyboardAndGamepadPlayerInput;

        public void InjectDependencies(KeyboardAndGamepadPlayerInput keyboardAndGamepadPlayerInput)
        {
            _keyboardAndGamepadPlayerInput = keyboardAndGamepadPlayerInput;
        }
    }
}