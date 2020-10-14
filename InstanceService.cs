using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexyBox
{
class InstanceService
{
    // Returns a list of instances of all classes of type T

    // Lav en InstanceService med metoden IEnumerable<T> GetInstances() 
    // som returnerer en instans  af alle klasser af typen T. 

    // Vehicle, så vil jeg gerne have alle
    // Car, BumperCar eller Bicycle, så vil jeg blot have den.

    // bt = object && type = T - bingo
    // bt = T && type = ? - bingo
    // bt

    public IEnumerable<T> GetInstances<T>()
    {
/*         var f = typeof(T);
        System.Console.WriteLine("IN BaseType:" + f.BaseType);
        System.Console.WriteLine("IN Type:" + f.Name);
        System.Console.WriteLine(""); */

        var allInstances = new List<T>();

        foreach(var assem in AppDomain.CurrentDomain.GetAssemblies())
        {
            var subTypes = assem.GetTypes().Where(x => x.BaseType == typeof(T) || x == typeof(T));

            foreach (var subType in subTypes)
            {
                allInstances.Add((T)Activator.CreateInstance(subType));
            }
        }
        
        return allInstances;
    }

/* 
    public T[] Reverse<T>(T[] array)
{
    var result = new T[array.Length];
    int j=0;
    for(int i=array.Length - 1; i>= 0; i--)
    {
        result[j] = array[i];
        j++;
    }
    return result; 
} */
}
}