using System;
using System.Linq;
using System.Collections.Generic;

namespace Games.Hangman
{
    class Hangman
    {
        private string _word;
        private char[] _board;
        private List<char> _guessed_chars = new List<char>();
        private int _fails = 0;

        public Hangman(string word)
        {
            this._word = word.ToUpper();
            this._board = new char[word.Length];
            this._fails = 0;
            char[] hiddenChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            for (int i = 0; i < word.Length; i++)
                this._board[i] = Array.IndexOf(hiddenChars, word[i].ToString().ToUpper()[0]) == -1 ? word[i] : '_';
        }

        public void Draw()
        {
            if (this._guessed_chars.Count > 0)
            {
                Console.Write("Guessed characters: ");
                foreach (char c in this._guessed_chars)
                    Console.Write($" {c.ToString().ToUpper()}");

                Console.WriteLine("\n");
            }

            Console.WriteLine("=======");
            Console.Write("|");
            if (this._fails >= 1)
                Console.Write("     0");
            Console.WriteLine();
            Console.Write("|");
            if (this._fails >= 2)
                Console.Write("    \\");
            if (this._fails >= 3)
                Console.Write("|");
            if (this._fails >= 4)
                Console.Write("/");
            Console.WriteLine();
            Console.Write("|");
            if (this._fails >= 5)
                Console.Write("     |");
            Console.WriteLine();
            Console.Write("|");
            if (this._fails >= 6)
                Console.Write("    /");
            if (this._fails >= 7)
                Console.Write(" \\");
            Console.WriteLine();
            Console.Write("|\n|    ");

            for (int i = 0; i < this._board.Length; i++)
            {
                char c = this._board[i];
                Console.Write(this._board.ElementAtOrDefault(i - 1) != '_' && this._board.ElementAtOrDefault(i) != '_' && this._board.ElementAtOrDefault(i + 1) != '_' ? $"{c.ToString().ToUpper()}" : $" {c.ToString().ToUpper()}");
            }
        }

        public void Guess(char guess)
        {
            guess = guess.ToString().ToUpper()[0];

            if (this._word.IndexOf(guess) > -1)
            {
                for (int i = 0; i < this._board.Length; i++)
                    if (this._word[i] == guess)
                        this._board[i] = guess;
            }
            else
            {
                this._guessed_chars.Add(guess);
                this._fails++;
            }

            if (this._word == string.Join("", this._board))
            {
                Console.WriteLine("\n\nCongrats, you won!");
                Environment.Exit(0);
            }
        }

        public bool Lost() => this._fails == 7;
    }
}