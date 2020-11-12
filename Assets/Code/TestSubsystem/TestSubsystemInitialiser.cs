using Demoniac.GameEntityModelSubsystem;
using Demoniac.GameManagerSubsystem;

namespace Demoniac.TestSubsystem
{
    public class TestSubsystemInitialiser
    {
        private Test _test;
        
        public void Initialise()
        {
            _test = new Test();
        }

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade, GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            _test.InjectDependencies(gameEntityModelSubsystemFacade, gameManagerSubsystemFacade);
        }
    }
}