namespace Demoniac.GameEntityModelSubsystem
{
    public class GameEntityModelSubsystemFacade
    {
        public GameEntityStorage GameEntityStorage { get; private set; }

        public void InjectDependencies(GameEntityStorage gameEntityStorage)
        {
            GameEntityStorage = gameEntityStorage;
        }
    }
}