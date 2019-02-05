using Decorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Answers
    {
        public void ManyDecoratorsSolution(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            var operation = new SimpleOperation();
            var metricDecorator = new MetricsDecorator(operation);
            var errorHandlingDecorator = new ErrorHandlingDecorator(metricDecorator);

            //Note that the ordering of your decorators matters. If you want to clock everything,
            //including the error handling, then your metric decorator should be last. But if you 
            //want your error handling to cover any potential problems with the metrics, error handling
            //should be your last decoration and so on...

            var result = errorHandlingDecorator.DoOperation(pairs);
            Console.WriteLine($"Return from the multiple decorators is {result}");
        }
    }
}
