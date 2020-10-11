using System;
using System.Collections.Generic;

namespace Games.SpaceInvaders
{
    class Invader
    {
        private Directions _direction = Directions.Right;
        public int X { get; private set; }
        public static int Y = (int)(Console.WindowHeight * 0.1);
        public static List<Invader> InvaderList = new List<Invader>();

        public Invader()
        {
            this.X = new Random().Next(3, Console.WindowWidth);
            Invader.InvaderList.Add(this);
        }

        public static void Move()
        {
            Invader.InvaderList.ForEach(i =>
            {
                if(i.X == Console.WindowWidth)
                    i._direction = Directions.Left;

                if(i.X == 0)
                    i._direction = Directions.Right;

                i.X += (int)i._direction;
            });
        }

        public static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Invader.InvaderList.ForEach(i =>
            {
                Console.SetCursorPosition(i.X, Invader.Y);
                Console.Write('■');
                Console.SetCursorPosition(i.X + Program.Unit, Invader.Y);
                Console.Write('■');
                Console.SetCursorPosition(i.X - Program.Unit, Invader.Y);
                Console.Write('■');
                Console.SetCursorPosition(i.X + 2 * Program.Unit, Invader.Y);
                Console.Write('■');
                Console.SetCursorPosition(i.X - 2 * Program.Unit, Invader.Y);
                Console.Write('■');
            });

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Shoot()
        {
            Invader.InvaderList.ForEach(i =>
            {
                if (new Random().Next(0, 10) != 0) return;
                new Bullet((i.X, Invader.Y), Spaceship.Invader);
            });
        }

        public static bool WasHit((int X, int Y) coordinates)
        {
            bool res = false;

            Invader.InvaderList
                .FindAll(i => (coordinates.X == i.X || coordinates.X == i.X - 1 || coordinates.X == i.X - 2 || coordinates.X == i.X + 1 || coordinates.X == i.X + 2) && coordinates.Y == Invader.Y)
                .ForEach(i =>
                {
                    res = true;
                    Invader.InvaderList.Remove(i);
                    Program.AddToScore();
                    new Invader();
                });

            return res;
        }
    }
}
