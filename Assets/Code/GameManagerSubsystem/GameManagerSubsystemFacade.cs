namespace Demoniac.GameManagerSubsystem
{
    public class GameManagerSubsystemFacade
    {
        public UnityMethodListener UnityMethodListener { get; private set; }

        public void InjectDependencies(UnityMethodListener unityMethodListener)
        {
            UnityMethodListener = unityMethodListener;
        }
    } 
}
