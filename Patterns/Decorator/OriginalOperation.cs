using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Decorator
{
    public class OriginalOperation : IOperable
    {
        private IDictionary<string, string> Dict = new Dictionary<string, string>();
        
        public bool DoOperation(IEnumerable<KeyValuePair<string, string>> kvPairs)
        {
            try
            {
                var timer = new Stopwatch();
                timer.Start();

                foreach (var pair in kvPairs)
                {
                    Dict.Add(pair.Key.ToString(), pair.Value.ToString());
                }

                timer.Stop();
                Console.WriteLine($"It took {timer.ElapsedMilliseconds} milliseconds to perform the operation.");
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}