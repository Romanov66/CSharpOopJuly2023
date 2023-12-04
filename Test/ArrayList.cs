using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class ArrayList
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 1, 2, 3, 56, 3, 9 };
            int[] numbers2 = new int[numbers1.Length];
            Array.Copy(numbers1, 0, numbers2, 0, numbers1.Length);

            Console.WriteLine(string.Join(" ", numbers1));
            Console.WriteLine(string.Join(" ", numbers2));
            Console.WriteLine();

            numbers2[0] = 0;

            Console.WriteLine(string.Join(" ", numbers1));
            Console.WriteLine(string.Join(" ", numbers2));
            Console.WriteLine();

            Math.Abs;
        }
    }
}
