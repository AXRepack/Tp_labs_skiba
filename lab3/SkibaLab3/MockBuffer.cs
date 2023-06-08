using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkibaLab3Test
{
    public class MockBuffer : BufferInterface
    {
        public string paste { get; set; }

        public bool tryToPaste()
        {
            return false;
        }
        public bool successPaste()
        {
            return true;
        }
    }
}
