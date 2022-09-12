using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakesInThreads
{
    internal class Snake
    {
        public static readonly char aSpace = ' ';
        public static readonly char aWall = '#';
        public static readonly char aSnakeBody = '*';
        public static readonly char aEat = '$';
        public static readonly char[] aHead = new char [] {'<', '>', '^', 'v' };

        public static readonly Сoordinates size = new Сoordinates(120, 29);
        private static char[,] screen = new char[size.x, size.y];

        private static Random random = new Random();

        Сoordinates head;
        Direction arrow;
        Сoordinates step;
        ConsoleColor color;
        Queue<Сoordinates> body;


        private Snake(Сoordinates start)
        {
            this.head = start;
            this.body = new Queue<Сoordinates> ();
            body.Enqueue(head);
            this.color = (ConsoleColor)random.Next(1, 15);
            TurnTo(Direction.Right);
        }

        public static Snake Create()
        {
            Сoordinates start = RandomСoordinat();

            int loop = 50;

            while (!IsEmpty(start) && --loop > 0)
            {
                start = RandomСoordinat();
            }

            if (loop <= 0)
                return null;

            Snake snake = new Snake(start);
            return snake;
        }

        public static void InitScreen()
        {
            for(int x = 0; x < size.x; x++)
            {
                for(int y = 0; y < size.y; y++)
                {
                    if(x * y == 0 || x == size.x - 1 || y == size.y - 1)
                        PutScreen(new Сoordinates(x, y), ConsoleColor.DarkGray, aWall);
                    else
                        PutScreen(new Сoordinates(x, y), ConsoleColor.DarkGray, aSpace);
                }
            }
        }

        private static void PutScreen(Сoordinates Сoordinat, ConsoleColor color, char symbol)
        {
            screen[Сoordinat.x, Сoordinat.y] = symbol;
            Console.ForegroundColor = color;
            Console.SetCursorPosition(Сoordinat.x, Сoordinat.y);
            Console.Write(symbol);
        }

        public static void AddEat()
        {
            Сoordinates newEat = RandomСoordinat();

            int loop = 100;

            while (!IsEmpty(newEat) && --loop > 0)
            {
                newEat = RandomСoordinat();
            }

            if (loop > 0)
                PutScreen(newEat, ConsoleColor.Cyan, aEat);

        }

        public static bool IsEmpty(Сoordinates Сoordinat)
        {
            char symbol = ScreenFrame(Сoordinat);
            return (symbol == aSpace || symbol == aEat);
        }


        public static Сoordinates RandomСoordinat()
        {
            return new Сoordinates(random.Next(0, size.x), random.Next(0, size.y));
        }

        public static char ScreenFrame(Сoordinates Сoordinat)
        {
            if(!OnScreen(Сoordinat))
                return aSpace;
            return screen[Сoordinat.x, Сoordinat.y];
        }

        public static bool OnScreen(Сoordinates Сoordinat)
        {
            return (Сoordinat.x >= 0 && Сoordinat.x < size.x &&
                    Сoordinat.y >= 0 && Сoordinat.y < size.y);
        }

        private void ShowMe(Сoordinates cHead, Сoordinates cSpace)
        {
            PutScreen(cHead, color, aHead[(int)arrow]);
            //PutScreen(cSpace, color, aSpace);
        }

        private void TurnTo(Direction direction)
        {
            if(this.arrow == direction)
                return;
            this.arrow = direction;
            step.x = 0;
            step.y = 0;

            switch (arrow)
            {
                case Direction.Left:
                    step.x = -1;
                    break;
                case Direction.Right:
                    step.x = +1;
                    break;
                case Direction.Top:
                    step.y = -1;
                    break;
                case Direction.Bottom:
                    step.y = +1;
                    break;
                default:
                    step.y = +1;
                    break;
            }
        }

        private void Turn()
        {
            if (random.Next(10) > 0)
                if (IsEmpty(head + step))
                    return;
            for(int i = 0; i < 10; i++)
            {
                TurnTo((Direction)random.Next(0, 4));
                if (IsEmpty(head + step))
                    return;
            }
        }

        public void Step()
        {
            Turn();
            Сoordinates nextHead = head + step;
            if (!IsEmpty(nextHead))
                nextHead = head;
            ShowMe(nextHead, head);
            head = nextHead;
        }

    }
}
