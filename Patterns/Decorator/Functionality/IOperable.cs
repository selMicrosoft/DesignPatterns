using System.Collections.Generic;

namespace Decorator.Functionality
{
    public interface IOperable
    {
        bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs);
    }
}