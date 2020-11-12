using Demoniac.GameEntityModelSubsystem;

namespace Demoniac.GameEntityViewSubsystem
{
    public class GameEntityViewSubsystemInitialiser
    {
        private GameEntityViewStorage _gameEntityViewStorage;
        private SpriteStorage _spriteStorage;
        private AnimationControllerStorage _animationControllerStorage;
        
        public void Initialise()
        {
            _gameEntityViewStorage = new GameEntityViewStorage();
            _spriteStorage = new SpriteStorage();
            _animationControllerStorage = new AnimationControllerStorage();
        }

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _gameEntityViewStorage.InjectDependencies(gameEntityModelSubsystemFacade, _spriteStorage, _animationControllerStorage);
        }
    } 
}
