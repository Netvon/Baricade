using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Core
{
    public class Dice
    {
        private readonly List<int> list;
        private int i;

        public Dice(int eyes)
        {
            Eyes = eyes;
            list = new List<int>() { 2, 2, 10, 14, 16, 25, 26, 10 };
            i = 0;
        }

        public int Eyes { get; }
        public int LastValue { get; private set; }

        public int Roll()
        {
#if !TESTDICE
            Random r = new Random();
            LastValue = r.Next(1, Eyes + 1);
#else
            LastValue = list[i];
            i++;
#endif

            return LastValue;
        }
    }
}
