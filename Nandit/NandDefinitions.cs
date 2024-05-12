using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nandit
{
    public static class NandDefinitions
    {
        public class Not : NandConfiguration
        {
            public Not() : base(1)
            {

            }
        }

        public class And : NandConfiguration
        {
            public And() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 2; i++)
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates.Where(g => g.Id == 0).FirstOrDefault();
                Gate B = gates.Where(g => g.Id == 1).FirstOrDefault();
                var link = new GateLink(0, A, B);
                gateLinks.Add(link);
                gateLinks.Add(new GateLink(1, link, link));
                Set(gates, gateLinks);
            }
        }

        public class Or : NandConfiguration
        {
            public Or() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 3; i++)
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates.Where(g => g.Id == 0).FirstOrDefault();
                Gate B = gates.Where(g => g.Id == 1).FirstOrDefault();
                Gate C = gates.Where(g => g.Id == 2).FirstOrDefault();
                var link1 = new GateLink(0, A, A);
                var link2 = new GateLink(1, B, B);
                gateLinks.Add(link1);
                gateLinks.Add(link2);
                gateLinks.Add(new GateLink(2, link1, link2));

                Set(gates, gateLinks);
            }
        }
        public class Nor : NandConfiguration
        {
            public Nor() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 4; i++)
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates.Where(g => g.Id == 0).FirstOrDefault();
                Gate B = gates.Where(g => g.Id == 1).FirstOrDefault();
                Gate C = gates.Where(g => g.Id == 2).FirstOrDefault();
                Gate D = gates.Where(g => g.Id == 3).FirstOrDefault();
                var f0 = new GateLink(0, A, A);
                var f1 = new GateLink(1, B, B);
                var f2 = new GateLink(2, f0, f1);
                var f3 = new GateLink(3, f2, f2);

                gateLinks.Add(f0);
                gateLinks.Add(f1);
                gateLinks.Add(f2);
                gateLinks.Add(f3);

                Set(gates, gateLinks);
            }
        }
        public class Xor : NandConfiguration
        {
            public Xor() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 2; i++) 
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates[0];
                Gate B = gates[1];
                var nandAB = new GateLink(0, A, B);
                var notA = new GateLink(1, nandAB, A);
                var notB = new GateLink(2, nandAB, B);
                var xorOutput = new GateLink(3, notA, notB);

                gateLinks.Add(nandAB);
                gateLinks.Add(notA);
                gateLinks.Add(notB);
                gateLinks.Add(xorOutput);
                Set(gates, gateLinks);
            }
        }
        public class Nxor : NandConfiguration
        {
            public Nxor() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 2; i++)
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates[0];
                Gate B = gates[1];

                var nandAB = new GateLink(0, A, B);
                var notA = new GateLink(1, nandAB, A);
                var notB = new GateLink(2, nandAB, B);
                var xorOutput = new GateLink(3, notA, notB);
                var nxorOutput = new GateLink(4, xorOutput, xorOutput);

                gateLinks.Add(nandAB);
                gateLinks.Add(notA);
                gateLinks.Add(notB);
                gateLinks.Add(xorOutput);
                gateLinks.Add(nxorOutput);

                Set(gates, gateLinks);
            }
        }
        public class Nand : NandConfiguration
        {
            public Nand() : base(2)
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                for (var i = 0; i < 2; i++)
                {
                    gates.Add(new Gate(i));
                }

                Gate A = gates[0];
                Gate B = gates[1];
                var nandOutput = new GateLink(0, A, B);

                gateLinks.Add(nandOutput);
                Set(gates, gateLinks);
            }
        }
        public class Buffer : NandConfiguration
        {
            public Buffer() : base(1) 
            {
                List<Gate> gates = new List<Gate>();
                List<GateLink> gateLinks = new List<GateLink>();

                gates.Add(new Gate(0));
                Gate A = gates[0];

                var firstNot = new GateLink(0, A, A);
                var secondNot = new GateLink(1, firstNot, firstNot);

                gateLinks.Add(firstNot);
                gateLinks.Add(secondNot);

                Set(gates, gateLinks);
            }
        }
    }
}
