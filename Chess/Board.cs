using System;
using System.Text.RegularExpressions;

namespace Games.Chess
{
    class Board
    {
        // Default board
        private Piece[,] _board = new Piece[8, 8]
        {
            { new Piece("R", 2, Players.White), new Piece("K", 3, Players.White), new Piece("B", 3, Players.White), new Piece("Q", 4, Players.White), new Piece("K", 5, Players.White), new Piece("B", 3, Players.White), new Piece("K", 3, Players.White), new Piece("R", 2, Players.White) },
            { new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White), new Piece("P", 1, Players.White) },
            { new Piece(" ", 2, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 4, Players.Empty), new Piece(" ", 5, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 2, Players.Empty) },
            { new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty), new Piece(" ", 1, Players.Empty) },
            { new Piece(" ", 2, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 4, Players.Empty), new Piece(" ", 5, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 3, Players.Empty), new Piece(" ", 2, Players.Empty) },
            { new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White), new Piece(" ", 1, Players.White) },
            { new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black), new Piece("P", 1, Players.Black) },
            { new Piece("R", 2, Players.Black), new Piece("K", 3, Players.Black), new Piece("B", 3, Players.Black), new Piece("K", 5, Players.Black), new Piece("Q", 4, Players.Black), new Piece("B", 3, Players.Black), new Piece("K", 3, Players.Black), new Piece("R", 2, Players.Black) }
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

            Console.WriteLine("\n|---|---|---|---|---|---|---|---|");
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

        public bool IsPlayable((int r, int c) coord) => this[coord.r, coord.c].Owner == Players.Empty;

        public (int, int) GetInput(string prompt, bool checkIfHouseIsEmpty = true)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string rowcol = Console.ReadLine();
                if (new Regex(@"^[0-9][0-9]$").Matches(rowcol).Count == 0)
                {
                    Console.WriteLine("Please, enter the requested data on the correct format");
                    continue;
                }

                char[] rc = rowcol.ToCharArray();
                (int r, int c) res = (Convert.ToInt32(rc[0]), Convert.ToInt32(rc[1]));

                if(checkIfHouseIsEmpty && !this.IsPlayable(res))
                {
                    Console.WriteLine("Please, enter the coordinates of a playable house.");
                    continue;
                }

                return res;
            }
        }

        public void Play((int r, int c) from)
        {
            (int r, int c) to = this.GetInput("> Select a house to move the selected piece (in yellow) to in RowCol format (e.g 15 = row 1 and col 5): ", false);
        }

        public Piece this[int r, int c]
        {
            get => this._board[r, c];
            private set => this._board[r, c] = value;
        }
    }
}
