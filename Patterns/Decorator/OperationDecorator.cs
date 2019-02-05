using System.Collections.Generic;

namespace Decorator
{
    public abstract class OperationDecorator : IOperable
    {
        protected readonly IOperable Operable;

        public OperationDecorator(IOperable operable)
        {
            Operable = operable;
        }

        public abstract bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs);
    }
}