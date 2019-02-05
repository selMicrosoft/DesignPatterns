using System.Collections.Generic;

using Decorator.Functionality;

namespace Decorator.Decorators
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