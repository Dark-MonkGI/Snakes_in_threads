using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesInThreads
{
    internal struct Сoordinates
    {
        public int x;
        public int y;

        public Сoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Сoordinates Plus(Сoordinates сoord)
        {
            return new Сoordinates(this.x + сoord.x, this.y + сoord.y);
        }

        public static Сoordinates operator + (Сoordinates сoord1, Сoordinates сoord2)
        {
            return new Сoordinates(сoord1.x + сoord2.x, сoord1.y + сoord2.y);
        }
    }
}
