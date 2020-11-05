using System;

namespace Games.Chess
{
    class Program
    {
        // Current player
        public static Players Player = Players.White;

        static void Main()
        {
            Board board = new Board();
            Console.WriteLine("'RowCol format' means two integers representing the row and col numbers respectively (both 1 based), like so: 15 = row 1 and col 5.\n");

            while (true)
            {
                Console.WriteLine($"{(Program.Player == Players.White ? "It's WHITE's turn!" : "It's BLACK's turn!")}\n");
                board.Draw();

                //if (Program.Player == 0)
                //{
                    (int r, int c) chosen = board.GetInput("> Select a piece in RowCol format: ");
                    board.Draw();
                    board.Play(chosen);
                //}
                //else AI.Play(board);

                // Shifting current player
                Program.Player = Program.Player == Players.White ? Players.Black : Players.White;

                Console.Clear();
            }
        }
    }
}
