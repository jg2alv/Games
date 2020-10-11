using System;

namespace Games.SpaceInvaders
{
    class Player
    {
        private int _x = Console.WindowWidth / 2;

        public void Draw()
        {
            Console.SetCursorPosition(this._x, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(this._x + Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(this._x - Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(this._x + 2 * Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
            Console.SetCursorPosition(this._x - 2 * Program.Unit, (int)(Console.WindowHeight * 0.9));
            Console.Write('■');
        }

        public void Move(Directions direction)
        {

        }

        public void Shoot()
        {

        }
    }
}
