using System;
using UnityEngine;

namespace Demoniac.GameManagerSubsystem
{
    public class UnityMethodListener : MonoBehaviour
    {
        public event Action _Awake;
        public event Action _Start;
        public event Action<float> _Update;
        public event Action<float> _FixedUpdate;

        private void Awake()
        {
            new SubsystemInitialiser().Initialise();
            _Awake?.Invoke();
        }

        private void Start()
        {
            _Start?.Invoke();
        }

        private void Update()
        {
            _Update?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _FixedUpdate?.Invoke(Time.fixedDeltaTime);
        }
    }
}