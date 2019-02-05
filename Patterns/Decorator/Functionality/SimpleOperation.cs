using System;
using System.Collections.Generic;

namespace Decorator.Functionality
{
    public class SimpleOperation : IOperable
    {
        private IDictionary<string, string> Dict = new Dictionary<string, string>();

        public bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs)
        {
            Console.WriteLine("In the concrete DoOperation method");
            foreach (var pair in kvPairs)
            {
                Dict.Add(pair.Key.ToString(), pair.Value.ToString());
            }

            return true;
        }
    }
}