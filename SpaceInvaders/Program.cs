using System;
using System.Threading;


namespace Games.SpaceInvaders
{
    class Program
    {
        private static ulong FRAMES = 0;
        private static int Score = 0;
        public static int Unit = 1 + (2 - 1) * (Console.WindowHeight - 1) / (Console.WindowWidth - 1);

        static void Main()
        {
            new Invader();
            new Invader();
            new Invader();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'a':
                            Player.Move(Directions.Left);
                            break;

                        case 'd':
                            Player.Move(Directions.Right);
                            break;

                        case ' ':
                            Player.Shoot();
                            break;
                    }
                }

                Console.Clear();
                Player.Draw();
                Invader.Draw();
                Bullet.Draw();

                if (Program.FRAMES % 250 == 0)
                {
                    Program.DrawScore();
                    Bullet.Move();
                    Invader.Shoot();
                    Invader.Move();
                }

                if (Program.FRAMES % 1000 == 0)
                    new Invader();

                Console.SetCursorPosition(0, 0);
                Program.FRAMES++;

                Thread.Sleep(1);
            }
        }

        public static void DrawScore()
        {
            Console.SetCursorPosition((int)(Console.WindowWidth * 0.99) - Program.Score.ToString().Length, (int)(Console.WindowHeight * 0.01));
            Console.Write(Program.Score);
        }

        public static void AddToScore() => Program.Score++;
    }
}
