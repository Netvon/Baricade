using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Dice
    {
        public Dice(int eyes)
        {
            Eyes = eyes;
        }

        public int Eyes { get; }
        public int LastValue { get; private set; }

        public int Roll()
        {
#if !TESTDICE
            Random r = new Random();
            LastValue = r.Next(1, Eyes + 1);
#else
            LastValue = 28;
#endif

            return LastValue;
        }
    }
}
