using System.Collections.Generic;

namespace Games.Snake
{
    class Node
    {
        public List<((int X, int Y) Coordinates, Directions direction)> Change = new List<((int X, int Y) Coordinates, Directions direction)>();
        private static List<Node> NodeList = new List<Node>();
        public Directions Direction { get; private set; }
        public (int X, int Y) Coordinates;
        public char Char
        {
            get => this.Direction == Directions.Left || this.Direction == Directions.Right ? '▬' : '▮';
        }

        public Node(Directions direction, (int X, int Y) coordinates)
        {
            this.Direction = direction;
            this.Coordinates = coordinates;

            Node.NodeList.Add(this);
        }

        public void Move()
        {
            this.Direction = this.GetNewDirection() ?? this.Direction;

            if (this.Direction == Directions.Up)
                this.Coordinates.Y -= Program.Unit;
            else if (this.Direction == Directions.Down)
                this.Coordinates.Y += Program.Unit;
            else if (this.Direction == Directions.Left)
                this.Coordinates.X -= Program.Unit;
            else
                this.Coordinates.X += Program.Unit;
        }

        private Directions? GetNewDirection()
        {
            int idx;

            if (this.Direction == Directions.Up || this.Direction == Directions.Down)
                idx = this.Change.FindIndex((((int X, int Y) Coordinates, Directions direction) change) => (change.Coordinates.Y == this.Coordinates.Y));
            else
                idx = this.Change.FindIndex((((int X, int Y) Coordinates, Directions direction) change) => (change.Coordinates.X == this.Coordinates.X));

            if (idx > -1)
            {
                Directions direction = this.Change[idx].direction;
                this.Change.RemoveAt(idx);
                return direction;
            };

            return null;
        }

        public static bool IsThereANodeHere((int X, int Y) coordinates) => Node.NodeList.Exists(n => n.Coordinates.X == coordinates.X && n.Coordinates.Y == coordinates.Y);
    }
}
