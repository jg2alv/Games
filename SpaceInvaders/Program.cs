using System;
using System.Threading;


namespace Games.SpaceInvaders
{
    class Program
    {
        private static ulong FRAMES = 0;
        public static int Unit = 1 + (2 - 1) * (Console.WindowHeight - 1) / (Console.WindowWidth - 1);
        public static int Score = 0;

        static void Main()
        {
            int score = Program.Score;

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

                if (Program.FRAMES % 250 == 0)
                    Bullet.Move();

                if (score != Program.Score)
                    Program.UpdateScore(ref score);

                Bullet.Draw();
                Console.SetCursorPosition(0, 0);
                Program.FRAMES++;

                Thread.Sleep(1);
            }
        }

        public static void UpdateScore(ref int score)
        {
            Console.SetCursorPosition((int)(Console.WindowWidth * 0.99) - Program.Score.ToString().Length, (int)(Console.WindowHeight * 0.01));
            Console.Write(Program.Score);

            score = Program.Score;
        }
    }
}
