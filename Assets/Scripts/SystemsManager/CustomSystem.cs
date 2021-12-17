using System;

namespace SystemsManager
{
    [Serializable]
    public class CustomSystem
    {
        public AbstractInput input;
        public int priority;
        public AbstractSystem system;
    }
}