﻿using System;
using System.Linq;
using static Nandit.NandDefinitions;

namespace Nandit
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a;
            bool b;
            a = b = false;

            Not not = new Not();
            And and = new And();
            Or or = new Or();
            Nor nor = new Nor();

            //Test(not, 1);
            //Test(and, 2);
            //Test(or, 2);
            Test(nor, 2);

            //for (var i = 0; i < 4; i++)
            //{
            //    if (i % 2 == 0)
            //        a = !a;
            //    b = !b;
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