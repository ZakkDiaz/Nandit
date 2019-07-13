using System;
using System.Collections.Generic;
using System.Text;

namespace Nandit
{
    public class Composer
    {

        private NandConfiguration _configuration;

        public Composer()
        {

        }

        public void ComposerInit(int parameterCount)
        {
            _configuration = new NandConfiguration(parameterCount);

            
        }
    }
}
