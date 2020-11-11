using Demoniac.GameEntityModelSubsystem;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewSubsystemInitialiser
    {
        private GameEntityViewStorage _gameEntityViewStorage;
        
        public void Initialise()
        {
            _gameEntityViewStorage = new GameEntityViewStorage();
        }

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _gameEntityViewStorage.InjectDependencies(gameEntityModelSubsystemFacade);
        }
    } 
}
