using System;

namespace Games.SpaceInvaders
{
    static class Player
    {
        private static int X = Console.WindowWidth / 2;
        public static int Y = (int)(Console.WindowHeight * 0.9);

        public static void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Player.X, Player.Y);
            Console.Write('■');
            Console.SetCursorPosition(Player.X + Program.Unit, Player.Y);
            Console.Write('■');
            Console.SetCursorPosition(Player.X - Program.Unit, Player.Y);
            Console.Write('■');
            Console.SetCursorPosition(Player.X + 2 * Program.Unit, Player.Y);
            Console.Write('■');
            Console.SetCursorPosition(Player.X - 2 * Program.Unit, Player.Y);
            Console.Write('■');
        }

        public static void Move(Directions direction) => Player.X += (int)direction;
        public static void Shoot() => new Bullet((Player.X, Player.Y - Program.Unit));
        public static bool WasHit((int X, int Y) coordinates) => (coordinates.X == Player.X || coordinates.X == Player.X - 1 || coordinates.X == Player.X - 2 || coordinates.X == Player.X + 1 || coordinates.X == Player.X + 2) && coordinates.Y == Player.Y;
    }
}
