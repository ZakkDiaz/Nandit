using System;

namespace Nandit
{
    public class Gate
    {
        public int Id;
        public bool Value = false;
        public Gate(int i)
        {
            this.Id = i;
        }

        public void Flip()
        {
            Value = !Value;
        }

        public void Set(bool v)
        {
            Value = v;
        }
    }
}