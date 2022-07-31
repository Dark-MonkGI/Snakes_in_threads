﻿using System;
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
        public static readonly char aSpace = ' ';
        public static readonly char aWall = '#';
        public static readonly char aSnakeBody = '*';
        public static readonly char aEat = '$';

        public static readonly Сoordinates size = new Сoordinates(120, 29);
        private static char[,] screen = new char[size.x, size.y];

        private static Random random = new Random();

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

    }
}
