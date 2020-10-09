using System;
using System.Collections.Generic;

namespace Snake
{
    enum Directions
    {
        Up = 1,
        Down = -1,
        Left = 2,
        Right = -2
    }

    class Snake
    {
        private (int X, int Y) _coordinates = (1, 0);
        public int Size
        {
            get => this._body.Count;
            private set
            {
                if (value < this._body.Count) return;
                value = value - this._body.Count;
                for (int i = 0; i < value; i++)
                    this.Grow();
            }
        }
        public readonly int FrameRate = 250;
        private readonly List<Node> _body;
        public Directions HeadDirection
        {
            get => this._body.Count < 1 ? Directions.Right : this._body[0].Direction;
            private set => this._body[0].Direction = value;
        }

        public Snake()
        {
            this._coordinates = (Console.WindowWidth / 2, Console.WindowHeight / 2);
            this._body = new List<Node>();
            this.Size = 3;
        }

        public void Move(Directions direction)
        {
            if (this.HeadDirection == direction || (int)this.HeadDirection + (int)direction == 0) return;

            this.HeadDirection = direction;
            int d = (int)this.HeadDirection;

            if (d % 2 != 0)
                this._coordinates.Y -= d;
            else
                this._coordinates.X -= d == 2 ? 1 : -1;

            this._body.ForEach(n =>
            {
                n.ChangeDirCoord = n.Direction != direction ? (this._coordinates, direction) : n.ChangeDirCoord;
                if (d % 2 != 0)
                    n.Coordinates.Y -= d;
                else
                    n.Coordinates.X -= d == 2 ? 1 : -1;

                n.Move();
            });
        }

        public void Draw()
        {
            Console.SetCursorPosition(this._coordinates.X, this._coordinates.Y);
            Console.Write(this);
        }

        private void Grow()
        {
            Node node = new Node(this.HeadDirection);
            this._body.Add(node);
        }

        public override string ToString()
        {
            return "".PadLeft(this.Size, '⬛');
        }
    }
}
