using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            Snake snake = new Snake();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'w':
                            snake.Move(Directions.Up);
                            break;

                        case 'a':
                            snake.Move(Directions.Left);
                            break;

                        case 's':
                            snake.Move(Directions.Down);
                            break;

                        case 'd':
                            snake.Move(Directions.Right);
                            break;
                    }
                }

                Console.Clear();
                snake.Move(snake.HeadDirection);
                snake.Draw();
                Thread.Sleep(snake.FrameRate);
            }
        }
    }
}

