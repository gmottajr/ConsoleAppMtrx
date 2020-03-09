using SpiralMatrixConsoleApp;
using System;

namespace ConsoleAppMtrx
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------- Spiral --------------------------");
            var mtx = SpiralMatrixWm.SpiralRecursive(6);
            SpiralMatrixWm.PrintArray(mtx);
            Console.ReadKey();
        }
    }
}
