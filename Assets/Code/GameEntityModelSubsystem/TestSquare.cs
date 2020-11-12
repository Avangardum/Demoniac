using System;
using Demoniac.PlayerInputSubsystem;
using UnityEngine;

namespace Demoniac.GameEntityModelSubsystem
{
    public class TestSquare : GameEntity
    {
        public event Action ColorChanged; 
        
        private const float Speed = 3;
        
        private PlayerInputSubsystemFacade _playerInput;
        
        public TestSquare(Vector2 position, PlayerInputSubsystemFacade playerInput) : base(position)
        {
            _playerInput = playerInput;
        }

        public override void FrameAction(float frameTime)
        {
            base.FrameAction(frameTime);
            Move(_playerInput.Horisontal * frameTime * Speed, 0);
            if (_playerInput.Jump)
            {
                ColorChanged?.Invoke();
            }
        }
    }
}