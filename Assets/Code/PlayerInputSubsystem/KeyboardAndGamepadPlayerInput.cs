using Demoniac.GameManagerSubsystem;
using UnityEngine;

namespace Demoniac.PlayerInputSubsystem
{
    public class KeyboardAndGamepadPlayerInput
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");

        public bool Jump => _jumpButton.IsDown;
        public bool Menu => _menuButton.IsDown;
        public bool Submit => _submitButton.IsDown;
        public bool Cancel => _cancel.IsDown;

        private Button _jumpButton = new Button();
        private Button _menuButton = new Button();
        private Button _submitButton = new Button();
        private Button _cancel = new Button();

        private UnityMethodListener _unityMethodListener;

        public void InjectDependencies(GameManagerSubsystemFacade gameManagerSubsystemFacade)
        {
            _unityMethodListener = gameManagerSubsystemFacade.UnityMethodListener;
            _unityMethodListener._Update += Update;
        }

        private void Update(float frameTime)
        {
            _jumpButton.Update(Input.GetAxisRaw("Jump") > 0);
            _menuButton.Update(Input.GetAxisRaw("Menu") > 0);
            _submitButton.Update(Input.GetAxisRaw("Submit") > 0);
            _cancel.Update(Input.GetAxisRaw("Cancel") > 0);
        }
        
        private class Button
        {
            private bool _isDown;
            private bool _wasPressedPreviousFrame;

            public bool IsDown
            {
                get
                {
                    if (_isDown)
                    {
                        _isDown = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }  
                }
            }

            public void Update(bool isPressed)
            {
                if (isPressed && !_wasPressedPreviousFrame)
                {
                    _isDown = true;
                }

                _wasPressedPreviousFrame = isPressed;
            }
        }
    }
}