using System;
using System.Collections.Generic;

namespace Games.SpaceInvaders
{
    class Bullet
    {
        private (int X, int Y) _coordinates;
        private Spaceship _shooter;
        private static List<Bullet> BulletList = new List<Bullet>();

        public Bullet((int X, int Y) coordinates, Spaceship shooter = Spaceship.Player)
        {
            this._coordinates = coordinates;
            this._shooter = shooter;
            Bullet.BulletList.Add(this);
        }

        public static void Move()
        {
            Bullet.GarbageCollection();
            Bullet.BulletList.ForEach(b => b._coordinates.Y += b._shooter == Spaceship.Player ? -Program.Unit : Program.Unit);
        }

        public static void Draw()
        {
            Bullet.BulletList.ForEach(b =>
            {
                Console.SetCursorPosition(b._coordinates.X, b._coordinates.Y);
                Console.ForegroundColor = b._shooter == Spaceship.Invader ? ConsoleColor.Green : Console.ForegroundColor;
                Console.Write('▮');
                Console.ForegroundColor = b._shooter == Spaceship.Invader ? ConsoleColor.Green : Console.ForegroundColor;
            });
        }

        public static void GarbageCollection() => Bullet.BulletList
                                                    .FindAll(b => b._coordinates.Y <= 0 || b._coordinates.Y >= Console.WindowHeight || Bullet.WasHitInvoker(b))
                                                    .ForEach(b => Bullet.BulletList.Remove(b));

        private static bool WasHitInvoker(Bullet b) => b._shooter != Spaceship.Invader ? Invader.WasHit((b._coordinates.X, b._coordinates.Y)) : Player.WasHit((b._coordinates.X, b._coordinates.Y));
    }
}
