using UnityEngine;
using System.Collections;

namespace Demoniac.GameManagerSubsystem
{
    public class GameManagerSubsystemInitialiser
    {
        public GameManagerSubsystemFacade Facade { get; private set; }

        public void Initialise()
        {
            Facade = new GameManagerSubsystemFacade();
        }

        public void InjectDependencies()
        {
            Facade.InjectDependencies(Object.FindObjectOfType<UnityMethodListener>());
        }
    }

}