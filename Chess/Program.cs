using System;
using System.Text.RegularExpressions;

namespace Games.Chess
{
    class Program
    {
        public static Players Player = Players.White;

        static void Main()
        {
            Board board = new Board();

            while (true)
            {
                Console.WriteLine($"It's {Enum.GetName(typeof(Players), Program.Player).ToUpper()}'s turn!\n");
                Regex regex = new Regex(@"^[a-h][0-8]$");

                board.Draw();
                Piece from = board.GetInput("> Input house on RowCol format: ", regex, false);
                Console.Clear();
                board.Draw();
                Piece to = board.GetInput("> Input house to land selected piece on: ", regex, true, false);
                Board.CheckAndPlay(from, to);

                Program.Player = Program.Player == Players.White ? Players.Black : Players.White;
                Console.Clear();
            }
        }

        public static void SetConsoleColors(Piece piece)
        {
            (int row, int col) position = Piece.GetPosition(piece);

            Console.ForegroundColor = piece.Owner == 0 ? ConsoleColor.DarkMagenta : ConsoleColor.DarkRed;
            Console.BackgroundColor = piece.Selected ? ConsoleColor.Yellow : position.row % 2 == 0 ? (position.col % 2 == 0 ? ConsoleColor.Gray : ConsoleColor.DarkGray) : (position.col % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray);
        }
    }
}
