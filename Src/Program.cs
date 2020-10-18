using System;
using System.Collections.Generic;
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
        //
        // Exceptionhandling kunne være foretaget pænere, samt programmet kunne logge bedre, måske endda til en centralt sted. Dette vurderes dog, 
        // at være uden for scope af denne opgave.
        // 
        // Projektet kan startes med "dotnet run -p Src/FlexyBox.csproj" i Visual Studio Code.
        #endregion

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nFlexyBox Vehicle System\n-----------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.WriteLine("Task 3: Functionality");

            Console.WriteLine();
            ListTypes();
            
            Console.WriteLine();
            SearchTypes("car");
            
            Console.WriteLine();
            ListTypesToFile("types.txt");

            Console.WriteLine();
            Console.WriteLine("\nTask 4: Problem");

            Console.WriteLine();
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
            WriteSeperator();

            Console.WriteLine("- Writing all types in the system alphabetically ordered: ");

            foreach (var instance in GetAndSortTypes<Vehicle>())
            {
                Console.WriteLine("- \t"+ instance.GetType().Name);
            }

            WriteSeperator();
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
            WriteSeperator();

            Console.WriteLine("- Types in the assembly containing the partial name (" + partialName + "):");

            foreach (var instance in GetSearchedTypes<Vehicle>(partialName))
            {
                Console.WriteLine("- \t"+ instance.GetType().Name);
            }

            WriteSeperator();
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
            WriteSeperator();

            Console.WriteLine("- Writting the types in the assembly to the file: " + fullPath);

            var instanceService = new InstanceService();
            var vehicles = (List<Vehicle>) instanceService.GetInstances<Vehicle>();

            try
            {
                FileWriter.WriteTypesToFile(fullPath, vehicles);
                Console.WriteLine("-\tThe file has been written.");
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("-\tAn error has occurred. Please use following message for troubleshooting:");
                Console.WriteLine("-\t\t'"+ ex.Message +"'");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

            WriteSeperator();
        }

        /// <summary>
        /// Reverses a string and displays it.
        /// </summary>
        /// <param name="stringToReverse">The string to be reversed</param>
        private static void ReverseString(string stringToReverse)
        {
            WriteSeperator();

            Console.WriteLine("Reversing a string:");

            Console.WriteLine("\tString to be reversed: " + stringToReverse);
            var reversedString = Problemsolving.ReverseString(stringToReverse);
            Console.WriteLine("\tString is reversed to: " + reversedString);

            WriteSeperator();
        }
        
        /// <summary>
        /// Tests if a string is a palindrome and displays the result.
        /// </summary>
        /// <param name="stringToTest">The string to test</param>
        private static void IsPalidrome(string stringToTest)
        {
            WriteSeperator();

            Console.WriteLine("- Testing to see if ("+ stringToTest +") is a palindrome:");

            var result = Problemsolving.IsPalindrome(stringToTest) ? "-\tIt is" : "-\tIt isn't";
            
            Console.WriteLine(result);

            WriteSeperator();
        }

        /// <summary>
        /// Finds missing elements in an array.
        /// </summary>
        /// <param name="arr">Array representing integers</param>
        private static void MissingElements(int[] arr)
        {
            WriteSeperator();

            Console.WriteLine("- Finding missing numbers in the series:");
            Console.Write("-\tNumber series:   [");

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

            Console.Write("-\tMissing numbers: [");

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

            WriteSeperator();
        }
    
        /// <summary>
        /// Writing seperator to console.
        /// </summary>
        private static void WriteSeperator()
        {
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}