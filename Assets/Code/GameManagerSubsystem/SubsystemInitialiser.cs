using Demoniac.GameEntityModelSubsystem;

namespace Demoniac.GameManagerSubsystem
{
    public class SubsystemInitialiser
    {
        public void Initialise()
        {
            GameManagerSubsystemInitialiser gameManagerSubsystemInitialiser = new GameManagerSubsystemInitialiser();
            GameEntityModelSubsystemInitialiser gameEntityModelSubsystemInitialiser = new GameEntityModelSubsystemInitialiser();

            gameManagerSubsystemInitialiser.Initialise();
            gameEntityModelSubsystemInitialiser.Initialise();

            gameManagerSubsystemInitialiser.InjectDependencies();
            gameEntityModelSubsystemInitialiser.InjectDependencies(gameManagerSubsystemInitialiser.Facade);
        }
    }

}