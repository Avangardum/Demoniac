using Demoniac.GameEntityModelSubsystem;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewSubsystemInitializer
    {
        private GameEntityViewStorage _gameEntityViewStorage;
        private SpriteStorage _spriteStorage;
        private AnimatorControllerStorage _animatorControllerStorage;
        
        public void Initialise()
        {
            _gameEntityViewStorage = new GameEntityViewStorage();
            _spriteStorage = new SpriteStorage();
            _animatorControllerStorage = new AnimatorControllerStorage();
        }

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _gameEntityViewStorage.InjectDependencies(gameEntityModelSubsystemFacade, _spriteStorage, _animatorControllerStorage);
        }
    } 
}
