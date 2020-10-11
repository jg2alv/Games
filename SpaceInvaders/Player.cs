using System;

namespace Games.SpaceInvaders
{
    static class Player
    {
        private static int X = Console.WindowWidth / 2;

        public static void Draw()
        {
            Console.SetCursorPosition(Player.X, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(Player.X + Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(Player.X - Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(Player.X + 2 * Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(Player.X - 2 * Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
        }

        public static void Move(Directions direction)
        {
            Player.X += (int)direction;
        }

        public static void Shoot()
        {
            Bullet bullet = new Bullet((Player.X, (int)(Console.WindowHeight * 0.9) - Program.Unit));
        }
    }
}
