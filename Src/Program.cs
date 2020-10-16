using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexyBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nFlexyBox Vehicle System\n-----------------------");
            
            //ListTypes();
            //SearchTypes();
            //ListTypesToFile("types.txt");
            //ReverseString("FlexyBox samler hele din drift i et system, og frigiver tid til dine kunder.");
            //IsPalidrome("ene");
            //MissingElements(new int[] { 1,3,4 });
        }

        /// <summary>
        /// Create instances of the type vehicle and displays these
        /// </summary>
        private static void ListTypes()
        {
            Console.WriteLine("Types in the system:");

            var instanceService = new InstanceService();
            var vehicles = (List<Vehicle>) instanceService.GetInstances<Vehicle>();
            var alfabeticVehicles = vehicles.OrderBy(x => x.GetType().Name).ToList();

            foreach (var instance in alfabeticVehicles)
            {
                Console.WriteLine("\t"+ instance.GetType().Name);
            }
        }

        /// <summary>
        /// Searches for types in the assembly containing the partial name. The search is based on lowercase comparisson.
        /// </summary>
        /// <param name="partialName">Partial name to search for</param>
        private static void SearchTypes(string partialName)
        {
            Console.WriteLine("Searching for types where '"+ partialName +"' is part of the name.");

            var instanceService = new InstanceService();
            var types = instanceService.SearchTypes(partialName);

            Console.WriteLine("Types in the assembly containing the partial name (" + partialName + "):");

            foreach (var type in types)
            {
                Console.WriteLine("\t"+ type.Name);
            }
        }

        /// <summary>
        /// Create instances of the type vehicle and writes their names to a file
        /// </summary>
        /// <param name="fullPath">The full path including filename ie. "C:/documents/file.txt"</param>
        private static void ListTypesToFile(string fullPath)
        {
            Console.WriteLine("The types in the assembly will be written to the file: " + fullPath);

            var instanceService = new InstanceService();
            var vehicles = (List<Vehicle>) instanceService.GetInstances<Vehicle>();
  
            FileWriter.WriteTypesToFile(fullPath, vehicles);

            Console.WriteLine("The file has been written.");
        }

        /// <summary>
        /// Reverses a string and displays it.
        /// </summary>
        /// <param name="stringToReverse">The string to be reversed</param>
        private static void ReverseString(string stringToReverse)
        {
            Console.WriteLine("String to be reversed: " + stringToReverse);
            var reversedString = Problemsolving.ReverseString(stringToReverse);
            Console.WriteLine("String is reversed: " + reversedString);
        }
        
        /// <summary>
        /// Tests if a string is a palindrome and displays the result.
        /// </summary>
        /// <param name="stringToTest">The string to test</param>
        private static void IsPalidrome(string stringToTest)
        {
            if (Problemsolving.IsPalindrome(stringToTest))
            {
                System.Console.WriteLine(stringToTest + " is a palindrome.");
            }
            else
            {
                System.Console.WriteLine(stringToTest + " is not a palidnrome.");
            }
        }

        /// <summary>
        /// Finds missing elements in an array.
        /// </summary>
        /// <param name="arr">Array representing integers</param>
        private static void MissingElements(int[] arr)
        {
            Console.WriteLine("Missing elements");
            Console.Write("Input: [");

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length -1)
                {
                    Console.Write(arr[i] + ",");
                }
                else
                {
                    Console.WriteLine(arr[i] + "]");
                }
            }

            var arr2 = (int[]) Problemsolving.MissingElements(arr);

            Console.Write("Output: [");

            for (int i = 0; i < arr2.Length; i++)
            {
                if (i != arr2.Length -1)
                {
                    Console.Write(arr2[i] + ",");
                }
                else
                {
                    Console.WriteLine(arr2[i] + "]");
                }
            }
        }
    }
}