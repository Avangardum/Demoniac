using Demoniac.GameEntityModelSubsystem;
using Demoniac.GameEntityViewSubsystem;
using TestSubsystem;

namespace Demoniac.GameManagerSubsystem
{
    public class SubsystemInitialiser
    {
        public void Initialise()
        {
            GameManagerSubsystemInitialiser gameManagerSubsystemInitialiser = new GameManagerSubsystemInitialiser();
            GameEntityModelSubsystemInitialiser gameEntityModelSubsystemInitialiser = new GameEntityModelSubsystemInitialiser();
            GameEntityViewSubsystemInitialiser gameEntityViewSubsystemInitialiser = new GameEntityViewSubsystemInitialiser();
            TestSubsystemInitialiser testSubsystemInitialiser = new TestSubsystemInitialiser();

            gameManagerSubsystemInitialiser.Initialise();
            gameEntityModelSubsystemInitialiser.Initialise();
            gameEntityViewSubsystemInitialiser.Initialise();
            testSubsystemInitialiser.Initialise();

            gameManagerSubsystemInitialiser.InjectDependencies();
            gameEntityModelSubsystemInitialiser.InjectDependencies(gameManagerSubsystemInitialiser.Facade);
            gameEntityViewSubsystemInitialiser.InjectDependencies(gameEntityModelSubsystemInitialiser.Facade);
            testSubsystemInitialiser.InjectDependencies(gameEntityModelSubsystemInitialiser.Facade);
        }
    }

}