using System.Collections.Generic;

namespace Assets.Sources.Core.Log
{
    public class LogFactory
    {
        public static readonly LogFactory Instance = new LogFactory();

        private readonly Dictionary<string, LogStrategy> _strategies = new Dictionary<string, LogStrategy>()
        {
            {nameof(ConsoleLogStrategy), new ConsoleLogStrategy()},
            {nameof(FileLogStrategy), new FileLogStrategy()},
            {nameof(DatabaseLogStrategy), new DatabaseLogStrategy()}
        };

        public LogStrategy Resolve<T>() where T : LogStrategy
        {
            return _strategies[typeof(T).Name];
        }
    }
}
