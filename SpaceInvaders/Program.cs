using System;
using System.Threading;


namespace Games.SpaceInvaders
{
    class Program
    {
        public static int FrameRate = 500;
        public static int Unit = 1 + (2 - 1) * (Console.WindowHeight - 1) / (Console.WindowWidth - 1);

        static void Main()
        {
            Player player = new Player();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'a':
                            player.Move(Directions.Left);
                            break;

                        case 'd':
                            player.Move(Directions.Right);
                            break;

                        case ' ':
                            player.Shoot();
                            break;
                    }
                }

                Console.Clear();
                player.Draw();
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(Program.FrameRate);
            }
        }
    }
}
