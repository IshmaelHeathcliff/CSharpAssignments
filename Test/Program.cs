using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input == "") Console.WriteLine("The input is blank");
            if (input == null) Console.WriteLine("The input is null");

            Console.ReadKey();
        }
    }
}
