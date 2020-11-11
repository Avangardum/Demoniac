using System;
using UnityEngine;

namespace Demoniac.GameManagerSubsystem
{
    public class UnityMethodListener : MonoBehaviour
    {
        public event Action Awake_;
        public event Action Start_;
        public event Action<float> Update_;
        public event Action<float> FixedUpdate_;

        private void Awake()
        {
            new SubsystemInitialiser().Initialise();
            Awake_?.Invoke();
        }

        private void Start()
        {
            Start_?.Invoke();
        }

        private void Update()
        {
            Update_?.Invoke(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            FixedUpdate_?.Invoke(Time.fixedDeltaTime);
        }
    }
}