using System;
using System.Text.RegularExpressions;

namespace Games.Chess
{
    class Board
    {
        // Default board
        private Piece[,] _board = new Piece[8, 8]
        {
            { new Piece(Pieces.Rook, Players.White, (0, 0)), new Piece(Pieces.Cnight, Players.White, (0, 1)), new Piece(Pieces.Bishop, Players.White, (0, 2)), new Piece(Pieces.Queen, Players.White, (0, 3)), new Piece(Pieces.King, Players.White, (0, 4)), new Piece(Pieces.Bishop, Players.White, (0, 5)), new Piece(Pieces.Cnight, Players.White, (0, 6)), new Piece(Pieces.Rook, Players.White, (0, 7)) },
            { new Piece(Pieces.Pawn, Players.White, (1, 0)), new Piece(Pieces.Pawn, Players.White, (1, 1)), new Piece(Pieces.Pawn, Players.White, (1, 2)), new Piece(Pieces.Pawn, Players.White, (1, 3)), new Piece(Pieces.Pawn, Players.White, (1, 4)), new Piece(Pieces.Pawn, Players.White, (1, 5)), new Piece(Pieces.Pawn, Players.White, (1, 6)), new Piece(Pieces.Pawn, Players.White, (1, 7)) },
            { new Piece(Pieces.Empty, Players.Empty, (2, 0)), new Piece(Pieces.Empty, Players.Empty, (2, 1)), new Piece(Pieces.Empty, Players.Empty, (2, 2)), new Piece(Pieces.Empty, Players.Empty, (2, 3)), new Piece(Pieces.Empty, Players.Empty, (2, 4)), new Piece(Pieces.Empty, Players.Empty, (2, 5)), new Piece(Pieces.Empty, Players.Empty, (2, 6)), new Piece(Pieces.Empty, Players.Empty, (2, 7)) },
            { new Piece(Pieces.Empty, Players.Empty, (3, 0)), new Piece(Pieces.Empty, Players.Empty, (3, 1)), new Piece(Pieces.Empty, Players.Empty, (3, 2)), new Piece(Pieces.Empty, Players.Empty, (3, 3)), new Piece(Pieces.Empty, Players.Empty, (3, 4)), new Piece(Pieces.Empty, Players.Empty, (3, 5)), new Piece(Pieces.Empty, Players.Empty, (3, 6)), new Piece(Pieces.Empty, Players.Empty, (3, 7)) },
            { new Piece(Pieces.Empty, Players.Empty, (4, 0)), new Piece(Pieces.Empty, Players.Empty, (4, 1)), new Piece(Pieces.Empty, Players.Empty, (4, 2)), new Piece(Pieces.Empty, Players.Empty, (4, 3)), new Piece(Pieces.Empty, Players.Empty, (4, 4)), new Piece(Pieces.Empty, Players.Empty, (4, 5)), new Piece(Pieces.Empty, Players.Empty, (4, 6)), new Piece(Pieces.Empty, Players.Empty, (4, 7)) },
            { new Piece(Pieces.Empty, Players.Empty, (5, 0)), new Piece(Pieces.Empty, Players.Empty, (5, 1)), new Piece(Pieces.Empty, Players.Empty, (5, 2)), new Piece(Pieces.Empty, Players.Empty, (5, 3)), new Piece(Pieces.Empty, Players.Empty, (5, 4)), new Piece(Pieces.Empty, Players.Empty, (5, 5)), new Piece(Pieces.Empty, Players.Empty, (5, 6)), new Piece(Pieces.Empty, Players.Empty, (5, 7)) },
            { new Piece(Pieces.Pawn, Players.Black, (6, 0)), new Piece(Pieces.Pawn, Players.Black, (6, 1)), new Piece(Pieces.Pawn, Players.Black, (6, 2)), new Piece(Pieces.Pawn, Players.Black, (6, 3)), new Piece(Pieces.Pawn, Players.Black, (6, 4)), new Piece(Pieces.Pawn, Players.Black, (6, 5)), new Piece(Pieces.Pawn, Players.Black, (6, 6)), new Piece(Pieces.Pawn, Players.Black, (6, 7)) },
            { new Piece(Pieces.Rook, Players.Black, (7, 0)), new Piece(Pieces.Cnight, Players.Black, (7, 1)), new Piece(Pieces.Bishop, Players.Black, (7, 2)), new Piece(Pieces.King, Players.Black, (7, 3)), new Piece(Pieces.Queen, Players.Black, (7, 4)), new Piece(Pieces.Bishop, Players.Black, (7, 5)), new Piece(Pieces.Cnight, Players.Black, (7, 6)), new Piece(Pieces.Rook, Players.Black, (7, 7)) }
        };

        public void Draw()
        {
            // Drawing house-number horizontal indicators
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  1   2   3   4   5   6   7   8");

            for (int r = 0; r < 8; r++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n|---|---|---|---|---|---|---|---|\n|");

                for (int c = 0; c < 8; c++)
                {
                    Board.SetColors(this[r, c], r, c);
                    Console.Write($" {this[r, c]} ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write("|");
                }

                // Drawing house-number vertical indicators
                Console.Write($"    {r + 1}");
            }

            Console.WriteLine("\n|---|---|---|---|---|---|---|---|\n");
        }


        public static void SetColors(Piece p, int row, int col)
        {
            // The character color (foreground) depends on owner player
            // The default background color is white/ black
            //      however, if the piece is selected, draw it in yellow
            Console.ForegroundColor = (ConsoleColor)p.Owner;
            Console.BackgroundColor = row % 2 == 0 ? (col % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.DarkGray) : (col % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray);
            Console.BackgroundColor = p.Selected ? ConsoleColor.Yellow : Console.BackgroundColor;
        }

        public static bool IsEmpty((int r, int c) coord, Board b) => b[coord.r, coord.c].Owner == Players.Empty;

        public (int, int) GetInput(string prompt, bool allowEmptyHouses = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string rowcol = Console.ReadLine();
                if (new Regex(@"^[0-9][0-9]$").Matches(rowcol).Count == 0)
                {
                    Console.WriteLine("Please, enter the requested data on the correct format");
                    continue;
                }

                char[] rc = rowcol.ToCharArray();
                (int r, int c) res = (Convert.ToInt32(rc[0].ToString()) - 1, Convert.ToInt32(rc[1].ToString()) - 1);

                if(res.r > 7 || res.c > 7 || (!allowEmptyHouses && Board.IsEmpty(res, this)) || (this[res.r, res.c].Owner != Program.Player && this[res.r, res.c].Owner != Players.Empty))
                {
                    Console.WriteLine("Please, enter the coordinates of a playable house.");
                    continue;
                }

                if(!allowEmptyHouses)
                    this[res.r, res.c].Selected = true;

                return res;
            }
        }

        public void Play((int r, int c) from)
        {
            while (true)
            {
                (int r, int c) to = this.GetInput("> Select a house to move the selected piece (in yellow) to in RowCol format: ", true);
                Piece sel = this[from.r, from.c];

                if (!sel.CanMoveTo(to, this))
                {
                    Console.WriteLine("Please, enter the coordinates of a house where the piece can land.");
                    continue;
                }

                sel.Move(to, this);
                sel.Selected = false;
                return;
            }
        }

        public Piece this[int r, int c]
        {
            get => this._board[r, c];
            set => this._board[r, c] = value;
        }
    }
}
