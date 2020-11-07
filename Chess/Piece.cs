using System;

namespace Games.Chess
{
    class Piece
    {
        public Pieces Type { get; set; }
        public Players Owner { get; set; }
        public (int x, string y) Position { get; set; }
        public bool Selected = false;

        public Piece(Pieces type, Players owner, (int x, string y) position)
        {
            this.Type = type;
            this.Owner = owner;
            this.Position = position;
        }

        public static (int row, int col) GetPosition(Piece piece) => (piece.Position.x, Array.FindIndex(new string[] { "a", "b", "c", "d", "e", "f", "g", "h" }, 0, 8, l => l == piece.Position.y));

        public override string ToString() => this.Type == Pieces.E ? " " : Enum.GetName(typeof(Pieces), this.Type);
    }
}
