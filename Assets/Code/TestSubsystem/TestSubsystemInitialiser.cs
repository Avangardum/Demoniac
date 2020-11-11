using Demoniac.GameEntityModelSubsystem;

namespace TestSubsystem
{
    public class TestSubsystemInitialiser
    {
        private Test _test;
        
        public void Initialise()
        {
            _test = new Test();
        }

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _test.InjectDependencies(gameEntityModelSubsystemFacade);
        }
    }
}