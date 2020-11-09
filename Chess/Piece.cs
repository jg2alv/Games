using System;
using System.Linq;
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
            Piece availableHouse;
            List<Piece> houses = new List<Piece>();
            (int x, string y) availableHousePosition;
            (int x, int y) position = (this.Position.x, Array.FindIndex(Program.Cols, 0, 8, l => l == this.Position.y));
            (int x, int y)[] positions;
            int unit = (int)this.Owner;
            void Rook()
            {
                int counter = 1;
                bool previousHouseWasntEmpty = false;

                // Same row, going to the right on columns
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x, Program.Cols[position.y + counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Same row, going to the left on columns
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x, Program.Cols[position.y - counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Going to the bottom on rows, same column
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x + counter, Program.Cols[position.y]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Going to the top on rows, same column
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x - counter, Program.Cols[position.y]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

            };

            void Bishop()
            {
                int counter = 1;
                bool previousHouseWasntEmpty = false;

                // Upper left diagonal
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x - counter, Program.Cols[position.y - counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Lower left diagonal
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x + counter, Program.Cols[position.y - counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Upper right diagonal
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x - counter, Program.Cols[position.y + counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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

                // Lower right diagonal
                while (true)
                {
                    try
                    {
                        availableHousePosition = (position.x + counter, Program.Cols[position.y + counter]);
                        availableHouse = Board.GetPiece(availableHousePosition);

                        if (!Board.IsEmpty(availableHousePosition))
                        {
                            if (availableHouse.Owner == this.Owner || previousHouseWasntEmpty) break;
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
            };


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
                        if (Board.GetPiece(nextDiagonalHouse).Owner == this.Owner || Board.GetPiece(nextDiagonalHouse).Owner == Players.Empty) continue;
                        houses.Add(Board.GetPiece(nextDiagonalHouse));
                    }

                    break;

                case Pieces.R:
                    Rook();
                    break;

                case Pieces.N:
                    positions = new (int x, int y)[]
                    {
                        (2, -1), // Top left
                        (2, 1), // Top right
                        (1, -2), // Left top
                        (-1, -2), // Left bottom
                        (1, 2), // Right top
                        (-1, 2), // Right bottom
                        (-2, -1), // Bottom left
                        (-2, 1) // Bottom right
                    };

                    foreach ((int x, int y) pos in positions)
                    {
                        try
                        {
                            availableHousePosition = (position.x + pos.x, Program.Cols[position.y + pos.y]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (availableHouse.Owner == this.Owner) continue;
                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        { }
                    }

                    break;

                case Pieces.B:
                    Bishop();
                    break;

                case Pieces.Q:
                    Rook();
                    Bishop();
                    break;

                case Pieces.K:
                    positions = new (int x, int y)[]
                    {
                        (1, -1), // Top left
                        (1, 0), // Top middle
                        (1, 1), // Top right
                        (0, -1), // Left middle
                        (0, 1), // Right middle
                        (-1, -1), // Bottom left
                        (-1, 0), // Bottom middle
                        (-1, 1) // Bottom right
                    };

                    foreach ((int x, int y) pos in positions)
                    {
                        try
                        {
                            availableHousePosition = (position.x + pos.x, Program.Cols[position.y + pos.y]);
                            availableHouse = Board.GetPiece(availableHousePosition);

                            if (availableHouse.Owner == this.Owner) continue;
                            houses.Add(availableHouse);
                        }
                        catch (Exception)
                        { }
                    }

                    break;
            }

            return houses.FindAll(p => p is Piece).Distinct().ToArray();
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
