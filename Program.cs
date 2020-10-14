using System;

namespace FlexyBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var instanceService = new InstanceService();

            var instanceCol = instanceService.GetInstances<Car>();
            //var instanceCol = instanceService.GetInstances<Vehicle>();

            foreach (var instance in instanceCol)
            {
                System.Console.WriteLine("OUT Type:" + instance.GetType().Name);
                System.Console.WriteLine("OUT BaseType:" + instance.GetType().BaseType);
                System.Console.WriteLine();
            }
        }
    }
}