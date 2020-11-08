using System;
using System.Collections.Generic;

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

        public static (int row, int col) GetPosition(Piece piece) => (piece.Position.x, Array.FindIndex(Program.Cols, 0, 8, l => l == piece.Position.y));

        public Piece[] CanGoTo()
        {
            List<Piece> houses = new List<Piece>();
            (int x, int y) position = (this.Position.x, Array.FindIndex(Program.Cols, 0, 8, l => l == this.Position.y));
            int unit = (int)this.Owner;

            switch (this.Type)
            {
                case Pieces.P:
                    // Checking house ahead & both diagonals
                    (int x, string y) nextHouse = (position.x + unit, Program.Cols[position.y]);
                    (int x, string y)[] nextDiagonalHouse = position.y == 0 ? new (int x, string y)[] { (position.x + unit, Program.Cols[position.y + 1]) } : position.y == 7 ? new (int x, string y)[] { (position.x + unit, Program.Cols[position.y - 1]) } : new (int x, string y)[] { (position.x + unit, Program.Cols[position.y + 1]), (position.x + unit, Program.Cols[position.y - 1]) };

                    if (Board.IsEmpty(nextHouse))
                        houses.Add(Board.GetPiece(nextHouse));

                    foreach ((int x, string y) _nextDiagonalHouse in nextDiagonalHouse)
                    {
                        if (Board.Owner(_nextDiagonalHouse) == this.Owner || Board.Owner(_nextDiagonalHouse) == Players.Empty) continue;
                        houses.Add(Board.GetPiece(_nextDiagonalHouse));
                    }

                    break;

                case Pieces.R:
                    break;

                case Pieces.N:
                    break;

                case Pieces.B:
                    break;

                case Pieces.Q:
                    break;

                case Pieces.K:
                    break;
            }

            return houses.ToArray();
        }

        public void Capture(Piece captured)
        {
            captured.Owner = this.Owner;
            captured.Type = this.Type;

            this.Selected = false;
            this.Owner = Players.Empty;
            this.Type = Pieces.E;
        }

        public override string ToString() => this.Type == Pieces.E ? " " : Enum.GetName(typeof(Pieces), this.Type);
    }
}
