using System;

namespace Games.Chess
{
    class Piece
    {
        private Pieces _piece;
        public (int r, int c) Coord { get; private set; }
        public Players Owner { get; set; }
        public bool Selected = false;

        public Piece(Pieces p, Players owner, (int r, int c) coord)
        {
            this._piece = p;
            this.Coord = coord;
            this.Owner = owner;
        }

        public bool CanMoveTo((int r, int c) to, Board b)
        {
            switch (this.ToString())
            {
                case "P":
                    return this.Owner == Players.White ? (this.Coord.c == to.c && this.Coord.r + 1 == to.r) || ((this.Coord.c + 1 == to.c || this.Coord.c - 1 == to.c) && this.Coord.r == to.r + 1 && !Board.IsEmpty(to, b)) : (this.Coord.c == to.c && this.Coord.r - 1 == to.r) || ((this.Coord.c + 1 == to.c || this.Coord.c - 1 == to.c) && this.Coord.r == to.r - 1 && !Board.IsEmpty(to, b));
                // if(this.Owner == Players.White)
                // {
                //     return (this.Coord.c == to.c && this.Coord.r + 1 == to.r) || ((this.Coord.c + 1 == to.c || this.Coord.c - 1 == to.c) && this.Coord.r == to.r + 1 && !Board.IsEmpty(to, b));
                // }
                // else
                // {
                //     return (this.Coord.c == to.c && this.Coord.r - 1 == to.r) || ((this.Coord.c + 1 == to.c || this.Coord.c - 1 == to.c) && this.Coord.r == to.r - 1 && !Board.IsEmpty(to, b));
                // }

                case "R":
                    return false;

                case "C":
                    return false;

                case "B":
                    return false;

                case "Q":
                    return false;

                case "K":
                    return false;

                default:
                    return false;
            }
        }

        public void Move((int r, int c) to, Board b)
        {
            (int r, int c) bc = this.Coord;
            Piece backupPiece = b[to.r, to.c];

            this.Coord = to;
            this.Selected = false;
            backupPiece.Selected = false;
            b[to.r, to.c] = this;
            b[bc.r, bc.c] = backupPiece;
        }

        public override string ToString() => this._piece == Pieces.Empty ? " " : Enum.GetName(typeof(Pieces), (int)this._piece)[0].ToString();
    }
}
