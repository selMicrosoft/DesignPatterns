using System.Collections.Generic;

namespace Decorator
{
    public interface IOperable
    {
        bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs);
    }
}