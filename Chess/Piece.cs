using System;
using System.Collections.Generic;
using System.Linq;

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
                    (int x, string y)[] nextDiagonalHouses = position.y == 0 ? new (int x, string y)[] { (position.x + unit, Program.Cols[position.y + 1]) } : position.y == 7 ? new (int x, string y)[] { (position.x + unit, Program.Cols[position.y - 1]) } : new (int x, string y)[] { (position.x + unit, Program.Cols[position.y + 1]), (position.x + unit, Program.Cols[position.y - 1]) };

                    // The pawn can go forward only if the next house is empty
                    if (Board.IsEmpty(nextHouse))
                        houses.Add(Board.GetPiece(nextHouse));

                    foreach ((int x, string y) nextDiagonalHouse in nextDiagonalHouses)
                    {
                        // The pawn can only go diagonally if there's an "enemy piece"
                        if (Board.Owner(nextDiagonalHouse) == this.Owner || Board.Owner(nextDiagonalHouse) == Players.Empty) continue;
                        houses.Add(Board.GetPiece(nextDiagonalHouse));
                    }

                    break;

                case Pieces.R:
                    int counter = 1;
                    bool previousHouseWasntEmpty = false;
                    (int x, string y) availableHousePosition;
                    Piece availableHouse;

                    while (true)
                    {
                        try
                        {
                            availableHousePosition = (position.x, Program.Cols[position.y + counter]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (!Board.IsEmpty(availableHousePosition))
                            {
                                if(availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
                                previousHouseWasntEmpty = true;
                            }

                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        counter++;
                    }

                    counter = 1;
                    availableHousePosition = (0, "");
                    availableHouse = null;
                    previousHouseWasntEmpty = false;

                    while (true)
                    {
                        try
                        {
                            availableHousePosition = (position.x, Program.Cols[position.y - counter]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (!Board.IsEmpty(availableHousePosition))
                            {
                                if(availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
                                previousHouseWasntEmpty = true;
                            }

                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        counter++;
                    }

                    counter = 1;
                    availableHousePosition = (0, "");
                    availableHouse = null;
                    previousHouseWasntEmpty = false;

                    while (true)
                    {
                        try
                        {
                            availableHousePosition = (position.x + counter, Program.Cols[position.y]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (!Board.IsEmpty(availableHousePosition))
                            {
                                if(availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
                                previousHouseWasntEmpty = true;
                            }

                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        counter++;
                    }

                    counter = 1;
                    availableHousePosition = (0, "");
                    availableHouse = null;
                    previousHouseWasntEmpty = false;

                    while (true)
                    {
                        try
                        {
                            availableHousePosition = (position.x - counter, Program.Cols[position.y]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (!Board.IsEmpty(availableHousePosition))
                            {
                                if(availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
                                previousHouseWasntEmpty = true;
                            }
                            
                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        counter++;
                    }

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

            return houses.FindAll(p => p is Piece).ToArray();
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
