using Demoniac.GameManagerSubsystem;
using Demoniac.PlayerInputSubsystem;

namespace Demoniac.GameEntityModelSubsystem
{
    public class GameEntityModelSubsystemInitializer
    {
        private GameEntityStorage gameEntityStorage;
        public GameEntityModelSubsystemFacade Facade { get; private set; }

        public void Initialise()
        {
            gameEntityStorage = new GameEntityStorage();
            Facade = new GameEntityModelSubsystemFacade();
        }

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade, PlayerInputSubsystemFacade playerInputSubsystemFacade)
        {
            gameEntityStorage.InjectDependencies(gameManagerSubsystemFacade, playerInputSubsystemFacade);
            Facade.InjectDependencies(gameEntityStorage);
        }
    } 
}
