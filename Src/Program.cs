using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlexyBox
{
    public class Program
    {
        #region Kommentarer til FlexyBox
        // Disse kommentarer er her blot for at uddybe overvejelser jeg har haft under udvikling. Disse ville ikke være noteret på samme
        // måde, hvis dette var et produkt til en kunde.
        //
        // GUI kunne laves pænere, men dette virkede ikke til at være i fokus i denne løsning. Løsningen kan afvikles, ved at udkommentere metode
        // kald i Main metoden.
        // Tests kan afvikles med "dotnet test Tests/Tests.csproj" i Visual Studio Code.
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("\nFlexyBox Vehicle System\n-----------------------");
            
            Console.WriteLine("Task 3: Functionality");
            ListTypes();
            
            Console.WriteLine();
            SearchTypes("car");
            
            Console.WriteLine();
            ListTypesToFile("types.txt");

            Console.WriteLine("\nTask 4: Problem");
            ReverseString("FlexyBox samler hele din drift i et system, og frigiver tid til dine kunder.");
            
            Console.WriteLine();
            IsPalidrome("beeb");
            
            Console.WriteLine();
            MissingElements(new int[] { 1,3,4 });
        }

        /// <summary>
        /// Create instances of the type vehicle and displays these
        /// </summary>
        private static void ListTypes()
        {
            Console.WriteLine("Types in the system:");

            foreach (var instance in GetAndSortTypes<Vehicle>())
            {
                Console.WriteLine("\t"+ instance.GetType().Name);
            }
        }

        /// <summary>
        /// Testable method to make sure that types are returned ordered
        /// </summary>
        /// <typeparam name="T">The type of instances in the returned collection</typeparam>
        /// <returns>Ordered collection of instances</returns>
        public static IEnumerable<T> GetAndSortTypes<T>()
        {
            var instanceService = new InstanceService();
            var types = instanceService.GetInstances<T>();
            return types.OrderBy(x => x.GetType().Name).ToList();
        }

        /// <summary>
        /// Searches for types in the assembly containing the partial name. The search is based on lowercase comparisson.
        /// </summary>
        /// <param name="partialName">Partial name to search for</param>
        private static void SearchTypes(string partialName)
        {
            Console.WriteLine("Types in the assembly containing the partial name (" + partialName + "):");

            foreach (var instance in GetSearchedTypes<Vehicle>(partialName))
            {
                Console.WriteLine("\t"+ instance.GetType().Name);
            }
        }

        /// <summary>
        /// Testable method for searching for types
        /// </summary>
        /// <param name="partialName">Partial name to search for</param>
        /// <returns>Collection of instances</returns>
        public static IEnumerable<T> GetSearchedTypes<T>(string partialName)
        {
            var instanceService = new InstanceService();
            return instanceService.SearchTypes<T>(partialName);
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