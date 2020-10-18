using System.Collections.Generic;
using System.IO;

namespace FlexyBox
{
    public class FileWriter
    {
        /// <summary>
        /// Writes the name of the types to the file.
        /// </summary>
        /// <param name="fullPath">The full path including filename ie. "C:/documents/file.txt"</param>
        /// <param name="types">The types whos names needs to be written to the file</param>
        public static void WriteTypesToFile(string fullPath, IEnumerable<object> types)
        {
            using (var writer = new StreamWriter(fullPath))
            {  
                foreach (var type in types)
                {
                    writer.WriteLine(type.GetType().Name);
                }
            }
        }
    }
}