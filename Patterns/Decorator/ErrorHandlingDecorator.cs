using System;
using System.Collections.Generic;

namespace Decorator
{
    public class ErrorHandlingDecorator : OperationDecorator
    {
        public ErrorHandlingDecorator(IOperable operable) : base(operable) { }

        public override bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs)
        {
            try
            {
                Console.WriteLine("Doing some action before the operation inside of the ErrorHandlingDecorator");
                var result = Operable.DoOperation(kvPairs);
                Console.WriteLine("Doing some action after the operation inside of the ErrorHandlingDecorator");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Uh oh, something went wrong. Handling errors");
                throw;
            }
        }
    }
}