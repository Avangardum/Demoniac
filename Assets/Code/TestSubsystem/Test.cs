﻿using Demoniac.GameEntityModelSubsystem;
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
            _gameEntityStorage.CreateTestSquare(new Vector2(0, -4));
            _gameEntityStorage.CreateTestCircle(new Vector2(-8, -4));
            _gameEntityStorage.CreateTestHexagon(new Vector2(3, -4));
            _gameEntityStorage.CreateTestPlatform(new Vector2(0, -2));
            _gameEntityStorage.CreatePlayerCharacter(new Vector2(0, 3));
        }
    }
}