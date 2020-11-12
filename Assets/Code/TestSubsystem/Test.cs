using Demoniac.GameEntityModelSubsystem;
using Demoniac.GameManagerSubsystem;
using UnityEngine;

namespace Demoniac.TestSubsystem
{
    public class Test
    {
        private GameEntityStorage _gameEntityStorage;
        private UnityMethodListener _unityMethodListener;

        public void InjectDependencies(GameEntityModelSubsystemFacade gameEntityModelSubsystemFacade, GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            _gameEntityStorage = gameEntityModelSubsystemFacade.GameEntityStorage;
            _unityMethodListener = gameManagerSubsystemFacade.UnityMethodListener;
            _unityMethodListener._Start += StartTesting;
        }

        private void StartTesting()
        {
            _gameEntityStorage.CreateTestSquare(Vector2.zero, Vector2.one);
            _gameEntityStorage.CreateTestSquare(new Vector2(3, 3), new Vector2(2, 2));
            _gameEntityStorage.CreateTestCircle(new Vector2(-8, -3));
        }
    }
}