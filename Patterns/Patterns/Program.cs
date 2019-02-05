using System;
using System.Collections.Generic;

using Decorator;

namespace Patterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunDecorator();

            Console.ReadLine();
        }

        public static void RunDecorator()
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
            //Think of a way to solve this, and then look at the below class to see how I solved it.
            new Answers().ManyDecoratorsSolution(pairs);
        }
    }
}
