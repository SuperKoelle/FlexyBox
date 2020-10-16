using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexyBox
{
    public class InstanceService
    {
        /// <summary>
        /// Returns a collection of instances of all classes of type T
        /// </summary>
        /// <typeparam name="T">The type of instances in the returned collection</typeparam>
        /// <returns>Collection of instances</returns>
        public IEnumerable<T> GetInstances<T>()
        {
            var allInstances = new List<T>();
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("FlexyBox")).FirstOrDefault();          

            if (assembly != null)
            {
                var subTypes = assembly.GetTypes().Where(x => x.BaseType == typeof(T) || x == typeof(T));

                foreach (var subType in subTypes)
                {
                    allInstances.Add((T)Activator.CreateInstance(subType));
                }

                return allInstances;
            }
            else
            {
                throw new Exception("The assemblyname was not found.");
            }
        }
    
        /// <summary>
        /// Get a collection of types containing the partial name in the type name. The search is based on lowercase comparisson.
        /// </summary>
        /// <param name="partialName">Partial name to search for</param>
        /// <returns>Collection of types</returns>
        public IEnumerable<Type> SearchTypes(string partialName)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("FlexyBox")).FirstOrDefault();

            if (assembly != null)
            {                
               var result = new List<Type>();

                foreach (var type in assembly.GetTypes())
                {
                    if (type.Name.ToLower().Contains(partialName.ToLower()))
                    {
                        result.Add(type);
                    }
                } 

                return result;
            }
            else
            {
                throw new Exception("The assemblyname was not found.");
            }
        }
    }
}