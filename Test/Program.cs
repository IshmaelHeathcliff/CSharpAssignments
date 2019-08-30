using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Test
{
    class Test
    {
        public enum Operator
        {
            Plus, Minus, Multiply, Divide
        }

        private static void Main()
        {
            Operator operators = Operator.Divide;
            Console.WriteLine((int)operators);
        }
    }
}
