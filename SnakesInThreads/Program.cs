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
            //  -> 

            Program program = new Program();
            //program.Start();
            program.StartTwo();
        }

        private void Start()
        {
            Snake.InitScreen();
            Snake.AddEat();

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
        }

        private void StartTwo()
        {
            Snake.InitScreen();
            Snake.AddEat();

            int max = 10;
            Snake[] snakes = new Snake[max];
            Thread[] threads = new Thread[max]; 

            // Каждый в своем потоке 
            for (int i = 0; i < max; i++)
            {
                snakes[i] = Snake.Create();
                threads[i] = new Thread(snakes[i].Run);
                threads[i].IsBackground = true; // поток делаем фоновым 
                threads[i].Start();

                //threads[i].Join(); Ожидает окончания работы предыдущего потока
            }
            Console.ReadKey();
        }
    }
}
