using Demoniac.GameManagerSubsystem;

namespace Demoniac.GameEntityModelSubsystem
{
    public class GameEntityModelSubsystemInitialiser
    {
        private GameEntityStorage gameEntityStorage;
        public GameEntityModelSubsystemFacade Facade { get; private set; }

        public void Initialise()
        {
            gameEntityStorage = new GameEntityStorage();
            Facade = new GameEntityModelSubsystemFacade();
        }

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            gameEntityStorage.InjectDependencies(gameManagerSubsystemFacade);
            Facade.InjectDependencies(gameEntityStorage);
        }
    } 
}
