using System.Collections.Generic;
using System.Linq;

namespace FlexyBox
{
    public class Problemsolving
    {
        /// <summary>
        /// Reverse a string without using String.Reverse()
        /// </summary>
        /// <param name="stringToReverse">String to be reversed</param>
        /// <returns>Reversed string</returns>
        public static string ReverseString(string stringToReverse)
        {
            var result = "";

            for(int i = stringToReverse.Length - 1; i >= 0; i--)
            {
                result += stringToReverse.Substring(i,1);
            }

            return result; 
        }

        /// <summary>
        /// Tests if string is a palindrome. The test is based on lowercase comparisson.
        /// </summary>
        /// <param name="stringToTest">The string to test</param>
        /// <returns>Result of the test</returns>
        public static bool IsPalindrome(string stringToTest)
        {
            var reversedString = ReverseString(stringToTest);
            return stringToTest.ToLower() == reversedString.ToLower();
        }

        /// <summary>
        /// Check if the array representing continues integers and returns an array of missing integers.
        /// </summary>
        /// <param name="arr">Array of integers</param>
        /// <returns>Array of missing integers.</returns>
        public static IEnumerable<int> MissingElements(int[] arr)
        {
            // First sort to make sure the lower values are represented before higher values
            var sortedArray = arr.OrderBy(i => i).ToArray();
            var missingElements = new List<int>();

            for (int i = 0; i < sortedArray.Length; i++)
            {
                //  If 'i' is not the last index of the array
                if (i != sortedArray.Length - 1)
                {
                    // If 'i' + 1 doesn't represent a value higher than the next value in the array
                    if (sortedArray[i] + 1 != sortedArray[i + 1])
                    {
                        var missingElement = sortedArray[i] + 1;

                        while (missingElement < sortedArray[i + 1])
                        {
                            missingElements.Add(missingElement);
                            missingElement++;
                        }
                    }
                }
            }

            return missingElements.ToArray();
        }
    }
}