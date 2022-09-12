using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakesInThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        private void Start()
        {
            Snake.InitScreen();
            Snake.AddEat();

            //int count = 100;
            //while(--count >  0)
            //    Snake.AddEat();

            int max = 10;
            Snake[] snakes = new Snake[max];

            for (int i = 0; i < max; i++)
                snakes[i] = Snake.Create();

            while (true)
            {
                for (int i = 0; i < max; i++)
                    snakes[i].Step();
                Thread.Sleep(100);
            }


            //20мин
            //int count = 100;
            //while (--count > 0)
            //{
            //    Snake snake = Snake.Create();
            //    snake.Step();
            //}
            





            Console.ReadLine();
        }
    }
}
