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
        /// <typeparam name="T">The type of instances in the returned collection</typeparam>
        /// <returns>Collection of instances<</returns>
        public IEnumerable<T> SearchTypes<T>(string partialName)
        {
            var result = new List<T>();

            foreach (var type in GetInstances<T>())
            {
                if (type.GetType().Name.ToLower().Contains(partialName.ToLower()))
                {
                    result.Add(type);
                }
            }

            return result;
        }
    }
}