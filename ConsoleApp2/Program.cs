using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ManyLib lib = new ManyLib();
            int[] test = {1, 4, 5};

            Console.WriteLine("Add");
            
            Console.WriteLine(lib.ToString(test));
            
            test = lib.Add(test, 2);
            test = lib.Add(test, 3);
            test = lib.Add(test, 4);

            Console.WriteLine(lib.ToString(test));
            
            Console.WriteLine("\nRemove elem - 2");
            test = lib.RemoveElement(test, 2);
            
            Console.WriteLine(lib.ToString(test));
            
            Console.WriteLine("\nUnion");
            
            test = lib.Union(test, test);
            
            Console.WriteLine(lib.ToString(test));
            
            Console.WriteLine("\nRemoveDuplicate");
            
            test = lib.RemoveDuplicate(test);
            
            Console.WriteLine(lib.ToString(test));
        }
    }
}