using System;
using System.Collections.Generic;

namespace Games.SpaceInvaders
{
    class Bullet
    {
        private (int X, int Y) _coordinates;
        private char _char = '▮';
        private static List<Bullet> BulletList = new List<Bullet>();

        public Bullet((int X, int Y) coordinates)
        {
            this._coordinates = coordinates;
            Bullet.BulletList.Add(this);
        }

        public static void Move()
        {
            List<Bullet> toBeRemoved = new List<Bullet>();

            Bullet.BulletList.ForEach(b =>
            {
                b._coordinates.Y -= Program.Unit;

                if (b._coordinates.Y <= 0 || b._coordinates.Y >= Console.WindowHeight)
                    toBeRemoved.Add(b);
            });

            toBeRemoved.ForEach(b => Bullet.BulletList.Remove(b));
        }

        public static void Draw()
        {
            Bullet.BulletList.ForEach(b =>
            {
                Console.SetCursorPosition(b._coordinates.X, b._coordinates.Y);
                Console.Write(b._char);
            });
        }
    }
}
