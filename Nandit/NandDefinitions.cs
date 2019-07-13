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
    }
}
