using System;
using System.Collections.Generic;

using Decorator.Decorators;
using Decorator.Functionality;

namespace Decorator
{
    public class DecoratorMain
    {
        public void Run()
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key1", "value1"),
                new KeyValuePair<string, string>("key2", "value2")
            };

            //The original operator handles all of the metrics, error handline, etc, along with its normal intended function
            var originalOperator = new OriginalOperation();
            var result1 = originalOperator.DoOperation(pairs);
            Console.WriteLine($"Return from concrete call: {result1}");
            Console.WriteLine();

            //The simple operator is passed to a decorator of our choosing, to add (or decorate) additional functionality
            //around the specific action we care about. This separates the concerns of the Operation from other shared concerns
            //that other Operations might similarly have, like: validation, logging, error handling, metrics, etc...
            var simpleOperation1 = new SimpleOperation();
            var metricDecorator = new MetricsDecorator(simpleOperation1);
            var result2 = metricDecorator.DoOperation(pairs);
            Console.WriteLine($"Return from metric decorator: {result2}");
            Console.WriteLine();

            var simpleOperation2 = new SimpleOperation();
            var errorHandlingDecorator = new ErrorHandlingDecorator(simpleOperation2);
            var result3 = errorHandlingDecorator.DoOperation(pairs);
            Console.WriteLine($"Return from error handling decorator: {result3}");
            Console.WriteLine();

            //What if we wanted to both get the metrics and handle any potential errors?
            //Do we need another decorator for that? Maybe an ErrorHandlingAndMetricsDecorator?
            //Think of a way to solve this, and then look at the below method to see how I solved it.
            ManyDecoratorsSolution(pairs);
        }

        private void ManyDecoratorsSolution(List<KeyValuePair<string, string>> pairs)
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