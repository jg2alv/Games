using System;
using System.Collections.Generic;

namespace Games.TicTacToe
{
    class Program
    {
        static void Main()
        {
            TicTacToe game = new TicTacToe();
            while (true)
            {
                int slot = Program.GetInput(game);
                var (x, y) = Program.Get2DCoordinate(--slot);
                game.Play(x, y);
                if (game.CheckWin())
                {
                    game.Draw();
                    Program.AnnounceWinner((char)game.Winner);
                }
            }
        }

        static int GetInput(TicTacToe game)
        {
            List<char> slots = game.Draw();
            void GetInput() => Console.Write($"\nChoose a number between {string.Join(", ", slots)}\n> Your choice: ");

            if (slots.Count < 2)
                Program.AnnounceWinner('-', "Draw");

            GetInput();

            while (true)
            {
                char res = Console.ReadLine()[0];
                Console.WriteLine();
                if (slots.IndexOf(res) == -1)
                {
                    GetInput();
                    continue;
                }

                return (int)char.GetNumericValue(res);
            }
        }

        static (int, int) Get2DCoordinate(int slot) => (slot / 3, slot % 3);

        static void AnnounceWinner(char winner, string status = "Won")
        {
            Console.WriteLine($"\n\n==== GAME OVER! ====\nWinner: {winner}\nMatch status: {status}");
            Environment.Exit(0);
        }
    }
}
