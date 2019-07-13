using System.Collections.Generic;
using System.Linq;

namespace Nandit
{
    public class NandConfiguration
    {
        private int _inputCount;
        private List<Gate> _gates;
        private List<GateLink> _links;
        public NandConfiguration(int parameterCount)
        {
            this._inputCount = parameterCount;
            _gates = new List<Gate>();
            _links = new List<GateLink>();
            for (var i = 0; i < _inputCount; i++)
            {
                _gates.Add(new Gate(i));
            }

            for(var i = 0; i < _gates.Count - 1; i++)
            {
                _links.Add(new GateLink(i, _gates[i], _gates[i + 1]));
            }
            if (_links.Count == 0)
                _links.Add(new GateLink(0, _gates.FirstOrDefault(), _gates.FirstOrDefault()));
        }

        public void Set(List<Gate> gates, List<GateLink> links)
        {
            _gates = gates;
            _links = links;
        }

        public bool Calc(bool[] input)
        {
            return Calculate(input).Last();
        }

        public bool[] Calculate(bool[] input)
        {
            for(var i = 0; i < input.Length; i++)
            {
                var gate = _gates.Where(g => g.Id == i).FirstOrDefault();
                if (gate == null)
                    continue;
                gate.Set(input[i]);
            }
            bool[] output = new bool[_links.Count];

            for (var i = 0; i < _links.Count; i++)
            {
                var link = _links.Where(l => l.Id == i).FirstOrDefault();
                if (link == null)
                    output[i] = false;
                output[i] = link.Calc();
            }
            return output;
        }
    }
}