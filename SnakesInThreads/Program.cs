using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            
            int count = 100;
            while(--count >  0)
                Snake.AddEat();

            Snake snake = Snake.Create();
            
            Console.ReadLine();
        }
    }
}
