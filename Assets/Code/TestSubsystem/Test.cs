using Demoniac.GameEntityModelSubsystem;
using UnityEngine;

namespace TestSubsystem
{
    public class Test
    {
        private GameEntityStorage _gameEntityStorage;

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade)
        {
            _gameEntityStorage = gameEntityModelSubsystemFacade.GameEntityStorage;
            StartTesting();
        }

        private void StartTesting()
        {
            _gameEntityStorage.CreateTestGameEntity(Vector2.zero, Vector2.one);
            _gameEntityStorage.CreateTestGameEntity(new Vector2(3, 3), new Vector2(2, 2));
        }
    }
}