using System;
using System.Collections.Generic;

namespace Games.TicTacToe
{
    class TicTacToe
    {
        public enum Players
        {
            Player1 = 'X',
            Player2 = 'O'
        };

        private char[,] _board = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        public Players Winner { get; private set; }
        private Players _turn = Players.Player1;

        public void Play(int row, int col)
        {
            this[row, col] = (char)this._turn;
            this._turn = this._turn == Players.Player1 ? Players.Player2 : Players.Player1;
        }

        public List<char> Draw()
        {
            List<char> res = new List<char>();
            Console.WriteLine($"It's {(char)this._turn}'s turn!\n");

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine("-------------");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"| {this._board[row, col]} {(col == 2 ? "|" : "")}");
                    if (this._board[row, col] != 'X' && this._board[row, col] != 'O')
                        res.Add(this._board[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("-------------");
            return res;
        }

        public bool CheckWin()
        {
            bool rowOne = false,
                rowTwo = false,
                rowThree = false,
                colOne = false,
                colTwo = false,
                colThree = false,
                transOne = false,
                transTwo = false;

            if (this._board[0, 0] == this._board[0, 1] && this._board[0, 0] == this._board[0, 2])
            {
                rowOne = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[1, 0] == this._board[1, 1] && this._board[1, 0] == this._board[1, 2])
            {
                rowTwo = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[2, 0] == this._board[2, 1] && this._board[2, 0] == this._board[2, 2])
            {
                rowThree = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[0, 0] == this._board[1, 0] && this._board[0, 0] == this._board[2, 0])
            {
                colOne = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[0, 1] == this._board[1, 1] && this._board[0, 1] == this._board[2, 1])
            {
                colTwo = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[0, 2] == this._board[1, 2] && this._board[0, 2] == this._board[2, 2])
            {
                colThree = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[0, 0] == this._board[1, 1] && this._board[0, 0] == this._board[2, 2])
            {
                transOne = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 0]));
            }
            else if (this._board[0, 2] == this._board[1, 1] && this._board[0, 2] == this._board[2, 0])
            {
                transTwo = true;
                this.Winner = (TicTacToe.Players)Enum.Parse(typeof(TicTacToe.Players), Enum.GetName(typeof(TicTacToe.Players), this._board[0, 2]));
            }

            return rowOne || rowTwo || rowThree || colOne || colTwo || colThree || transOne || transTwo;
        }

        public char this[int row, int col]
        {
            get => this._board[row, col];
            private set => this._board[row, col] = value;
        }
    }
}
