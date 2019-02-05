using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Decorator
{
    public class MetricsDecorator : OperationDecorator
    {
        public MetricsDecorator(IOperable operable) : base(operable) { }

        public override bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs)
        {
            Console.WriteLine("Doing some stuff in the Metrics Decorator");
            var timer = new Stopwatch();
            timer.Start();

            var result = Operable.DoOperation(kvPairs);

            timer.Stop();
            Console.WriteLine($"It took {timer.ElapsedMilliseconds} milliseconds to do the operation.");
            return result;
        }
    }
}