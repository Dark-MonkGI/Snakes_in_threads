using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesInThreads
{
    public struct Сoordinates
    {
        public int x;
        public int y;
        public Сoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal class Snake
    {
        public static readonly Сoordinates size = new Сoordinates(70, 24);
        public static readonly char aSpace = ' ';
        public static readonly char aWall = '#';
        public static readonly char aSnakeBody = '*';
        public static readonly char aEat = '$';

    }
}
