using System;

namespace IDATest
{
    [Serializable]
    public struct ProjectData
    {
        public SerializableDictionary<int, int> levelCounter;
    }
}