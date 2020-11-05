using System;

namespace Games.Chess
{
    class Program
    {
        // Current player. It shifts from 0 to 1, back and forth
        private static int Player = 0;

        static void Main()
        {
            Board board = new Board();

            while(true)
            {
                Console.WriteLine(Program.Player == 0 ? "It's WHITE's turn!" : "It's BLACK's turn!");
                board.Draw();
                board.Play(board.GetInput("> Select a piece in RowCol format (e.g 15 = row 1 and col 5): "));

                // Shifting current player
                Program.Player ^= 1;
            }
        }
    }
}
