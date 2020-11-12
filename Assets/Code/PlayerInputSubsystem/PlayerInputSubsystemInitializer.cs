using Demoniac.GameManagerSubsystem;

namespace Demoniac.PlayerInputSubsystem
{
    public class PlayerInputSubsystemInitializer
    {
        public PlayerInputSubsystemFacade Facade;
        private KeyboardAndGamepadPlayerInput _keyboardAndGamepadPlayerInput;
        
        public void Initialise()
        {
            Facade = new PlayerInputSubsystemFacade();
            _keyboardAndGamepadPlayerInput = new KeyboardAndGamepadPlayerInput();
        }

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            Facade.InjectDependencies(_keyboardAndGamepadPlayerInput);
            _keyboardAndGamepadPlayerInput.InjectDependencies(gameManagerSubsystemFacade);
        }
    }
}