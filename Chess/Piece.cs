using System;

namespace Games.Chess
{
    class Piece
    {
        private string _name;
        private int _val;
        public Players Owner { get; set; }
        public bool Selected = false;

        public Piece(string name, int val, Players owner)
        {
            this._name = name;
            this._val = val;
            this.Owner = owner;
        }

        public override string ToString() => this._name;
    }
}
