using System;
using System.Linq;
using static Nandit.NandDefinitions;

namespace Nandit
{
    class Program
    {
        static void Main(string[] args)
        {
            Not not = new Not();
            And and = new And();
            Or or = new Or();
            Nor nor = new Nor();

            Console.WriteLine($"Not");
            Test(not, 1);
            Console.WriteLine($"And");
            Test(and, 2);
            Console.WriteLine($"Or");
            Test(or, 2);
            Console.WriteLine($"Nor");
            Test(nor, 2);
        }

        public static void Test(NandConfiguration config, int size)
        {
            bool[] permutations = new bool[size];
            for(var i = 0; i < size; i++)
            {
                permutations[i] = false;
            }

            var length = Math.Pow(2, size);
            for (var i = 0; i < length; i++)
            {
                for(var sz = 0; sz < size; sz++)
                {
                 
                    
                    var factor = (i + 1) % (sz + 1);
                    if(factor == 0)
                        permutations[sz] = !permutations[sz];
                }
                Console.WriteLine($"{string.Join(',', permutations)}:{config.Calc(permutations)}");
            }

        }
    }
}
