using System;
using System.Text.RegularExpressions;

namespace Games.Chess
{
    class Board
    {
        // Default board
        private Piece[] _board = new Piece[64];

        public Board()
        {
            int[] rows = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            string[] cols = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            Pieces?[] pieces = new Pieces?[64];
            Players?[] players = new Players?[64];

            for (int i = 0; i < 8; i++)
            {
                // Second and second-to-last rows respectively
                pieces[8 + i] = Pieces.P;
                pieces[48 + i] = Pieces.P;

                // First, second, second-to-last and last rows respectively
                players[i] = Players.Black;
                players[8 + i] = Players.Black;
                players[48 + i] = Players.White;
                players[56 + i] = Players.White;
            }

            // First & last rows
            pieces[0] = pieces[56] = Pieces.R;
            pieces[1] = pieces[57] = Pieces.N;
            pieces[2] = pieces[58] = Pieces.B;
            pieces[3] = pieces[59] = Pieces.Q;
            pieces[4] = pieces[60] = Pieces.K;
            pieces[5] = pieces[61] = Pieces.B;
            pieces[6] = pieces[62] = Pieces.N;
            pieces[7] = pieces[63] = Pieces.R;

            foreach (int x in rows)
            {
                foreach (string y in cols)
                {
                    int linearPosition = Array.FindIndex(cols, 0, 8, n => n == y) + 8 * x;
                    this._board[linearPosition] = new Piece(pieces[linearPosition] ?? Pieces.E, players[linearPosition] ?? Players.Empty, (x, y));
                }
            }
        }

        public void Draw()
        {
            int[] rows = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            string[] cols = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
            void DrawVerticalDivision(bool lineBreak = false, string n = "")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (n.Length > 0 && !lineBreak)
                    Console.Write($"   {n}    ");

                Console.Write("|");

                if (lineBreak && n.Length > 0)
                    Console.Write($"    {n}\n");
                else if (lineBreak && n.Length == 0)
                    Console.Write("\n");

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("          a   b   c   d   e   f   g   h\n");

            foreach (int x in rows)
            {
                string col = Math.Abs(Array.FindIndex(rows, 0, 8, r => r == x) - 8).ToString();
                Console.WriteLine("        |---|---|---|---|---|---|---|---|");

                foreach (string y in cols)
                {
                    if (y == "a")
                        DrawVerticalDivision(false, col);
                    else
                        DrawVerticalDivision();

                    Piece curr = Array.Find(this._board, p => p.Position == (x, y));
                    Program.SetConsoleColors(curr);
                    Console.Write($" {curr} ");
                    Console.ResetColor();
                }

                DrawVerticalDivision(true, col);
            }

            Console.WriteLine("        |---|---|---|---|---|---|---|---|\n\n          a   b   c   d   e   f   g   h\n");
            Console.ResetColor();
        }

        public Piece GetInput(string prompt, Regex regex, bool allowEmptyHouses, bool markAsSelected = true)
        {
            Piece piece;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (regex.Matches(input).Count == 0)
                {
                    Console.WriteLine("Please enter the information on the correct format");
                    continue;
                }

                char[] cInput = input.ToCharArray();
                piece = Array.Find(this._board, p => p.Position == (Math.Abs(Convert.ToInt32(cInput[1].ToString()) - 8), cInput[0].ToString()));

                if (!allowEmptyHouses && (piece.Owner == Players.Empty || piece.Owner != Program.Player))
                {
                    Console.WriteLine("Please, selected a playable piece/ house.");
                    continue;
                }

                piece.Selected = true && markAsSelected;
                break;
            }

            return piece;
        }

        public static void CheckAndPlay(Piece from, Piece to)
        {
            switch (from.Type)
            {
                case Pieces.P:
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
        }
    }
}
