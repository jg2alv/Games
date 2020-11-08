using System;
using System.Text.RegularExpressions;

namespace Games.Chess
{
    class Program
    {
        public static Players Player = Players.White;
        public static int[] Rows = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
        public static string[] Cols = new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };

        static void Main()
        {
            Board.BuildBoard();

            while (true)
            {
                Console.WriteLine($"It's {Enum.GetName(typeof(Players), Program.Player).ToUpper()}'s turn!\n");
                Regex regex = new Regex(@"^[a-h][0-8]$");

                Board.Draw();
                Piece from = Board.GetInput("> Input house on RowCol format: ", regex, false);
                Console.Clear();
                Board.Draw();
                while (true)
                {
                    Piece to = Board.GetInput("> Input house to land selected piece on: ", regex, true, false);
                    if (Board.Play(from, to)) break;
                    Console.WriteLine("Please, selected a playable piece/ house.");
                }



                Program.Player = Program.Player == Players.White ? Players.Black : Players.White;
                Console.Clear();
            }
        }

        public static void SetConsoleColors(Piece piece)
        {
            (int row, int col) position = Piece.GetPosition(piece);

            Console.ForegroundColor = piece.Owner == Players.White ? ConsoleColor.DarkMagenta : ConsoleColor.DarkRed;
            Console.BackgroundColor = piece.Selected ? ConsoleColor.Yellow : position.row % 2 == 0 ? (position.col % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.DarkGray) : (position.col % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray);
        }
    }
}
