using System;
using System.Collections.Generic;
using System.Text;

namespace Nandit
{
    public static class Nand
    {
        public static bool Calc(bool a, bool b) => (!a) | ((a & !b));
    }
}
