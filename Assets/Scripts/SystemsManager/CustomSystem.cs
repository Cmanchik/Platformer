namespace SystemsManager
{
    [System.Serializable]
    public class CustomSystem
    {
        public AbstractInput input;
        public AbstractSystem system;
        public int priority;
    }
}
