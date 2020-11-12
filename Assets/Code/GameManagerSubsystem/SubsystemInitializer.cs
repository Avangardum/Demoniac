using Demoniac.GameEntityModelSubsystem;
using Demoniac.GameEntityViewSubsystem;
using Demoniac.TestSubsystem;

namespace Demoniac.GameManagerSubsystem
{
    public class SubsystemInitializer
    {
        public void Initialise()
        {
            GameManagerSubsystemInitialiser gameManagerSubsystemInitialiser = new GameManagerSubsystemInitialiser();
            GameEntityModelSubsystemInitializer gameEntityModelSubsystemInitializer = new GameEntityModelSubsystemInitializer();
            GameEntityViewSubsystemInitializer gameEntityViewSubsystemInitializer = new GameEntityViewSubsystemInitializer();
            TestSubsystemInitializer testSubsystemInitializer = new TestSubsystemInitializer();

            gameManagerSubsystemInitialiser.Initialise();
            gameEntityModelSubsystemInitializer.Initialise();
            gameEntityViewSubsystemInitializer.Initialise();
            testSubsystemInitializer.Initialise();

            gameManagerSubsystemInitialiser.InjectDependencies();
            gameEntityModelSubsystemInitializer.InjectDependencies(gameManagerSubsystemInitialiser.Facade);
            gameEntityViewSubsystemInitializer.InjectDependencies(gameEntityModelSubsystemInitializer.Facade);
            testSubsystemInitializer.InjectDependencies(gameEntityModelSubsystemInitializer.Facade, gameManagerSubsystemInitialiser.Facade);
        }
    }

}