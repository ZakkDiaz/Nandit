using System;

namespace Nandit
{
    public class GateLink
    {

        private Gate gate1;
        private Gate gate2;
        public int Id;
        private GateLink _from;
        private GateLink _from2;
        private Gate c;

        public GateLink(int id, Gate gate1, Gate gate2)
        {
            Id = id;
            this.gate1 = gate1;
            this.gate2 = gate2;
        }

        public GateLink(int v, GateLink from, Gate c)
        {
            Id = v;
            _from = from;
            this.c = c;
        }
        public GateLink(int v, GateLink from, GateLink from2)
        {
            Id = v;
            _from = from;
            _from2 = from2;
        }

        internal bool Calc()
        {
            if (_from != null)
                if (_from2 != null)
                    return Nand.Calc(_from.Calc(), _from2.Calc());
                else if(c != null)
                    return Nand.Calc(_from.Calc(), c.Value);
            return Nand.Calc(gate1.Value, gate2.Value);
        }
    }
}