using System;
using System.Threading;


namespace Games.SpaceInvaders
{
    class Program
    {
        public static int FrameRate = 1;
        public static int Unit = 1 + (2 - 1) * (Console.WindowHeight - 1) / (Console.WindowWidth - 1);
        private static ulong FRAMES = 0;

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

                if (Program.FRAMES % 250 == 0)
                    Bullet.Move();

                Bullet.Draw();
                Console.SetCursorPosition(0, 0);
                Program.FRAMES++;

                Thread.Sleep(Program.FrameRate);
            }
        }
    }
}
