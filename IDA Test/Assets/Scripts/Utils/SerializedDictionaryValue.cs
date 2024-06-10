using System;

namespace IDATest
{
    [Serializable]
    internal class SerializedDictionaryValue<TKey, TValue>
    {
        public TKey key;
        public TValue value;

        public SerializedDictionaryValue(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
}