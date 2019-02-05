using System;
using CQRS;
using Decorator;

namespace Patterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DecoratorMain().Run();
            new CqrsMain().Run();
            Console.ReadLine();
        }
    }
}