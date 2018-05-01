using System;

namespace Samples.Functional
{
    public abstract class Command
    {
        public DateTime Timestamp { get; set; }

        public T WithTimestamp<T>(DateTime timestamp)
            where T : Command
        {
            T result = (T)MemberwiseClone();
            result.Timestamp = timestamp;
            return result;
        }
    }
}