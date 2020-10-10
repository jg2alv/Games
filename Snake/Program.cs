using System;
using System.Threading;

namespace Games.Snake
{
    class Program
    {
        static void Main()
        {
            Snake snake = new Snake();
            Food.GenerateFood();

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

                        case 'g':
                            snake.Grow();
                            break;

                        case 'f':
                            Food.GenerateFood();
                            break;
                    }
                }

                Console.Clear();
                snake.Move(snake.Direction, true);
                snake.Draw();
                Food.Draw();
                Thread.Sleep(snake.FrameRate);
            }
        }

        public static void Quit(string msg)
        {
            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(msg);
            Environment.Exit(0);
        }
    }
}

