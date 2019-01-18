using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Nuget_x86
{
    class Program
    {
        static void Main(string[] args)
        {           
            if (Environment.Is64BitProcess)
            {
                Console.WriteLine("//Runtime is x64");
            }
            else
            {
                Console.WriteLine("//Runtime is x86");
            }

            int number1 = 3;
            int number2 = 4;
            NativeLibWrapper.NativeLibWrapper.Sum(number1, number2, out int result);
            Console.WriteLine($"{number1} + {number2} = {result}");
            Console.ReadLine();
        }
    }
}
