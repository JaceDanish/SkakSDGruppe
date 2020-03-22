using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Knight : IChessPiece
    {
        private bool _isWhite;

        public Knight(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 || y1 == y2 || Math.Abs(Math.Abs(x1) - Math.Abs(x2)) > 2 || Math.Abs(Math.Abs(y1) - Math.Abs(y2)) > 2)
                return false;

            if (Math.Abs((Math.Abs(x1) + Math.Abs(y1)) - (Math.Abs(x2) + Math.Abs(y2))) == 3)
                return true;
            if (Math.Abs((Math.Abs(x1) + Math.Abs(y1)) - (Math.Abs(x2) + Math.Abs(y2))) == 1)
                return true;

            return false;
        }

        public bool IsWhite()
        {
            return _isWhite;
        }

        public string Icon()
        {
            return $"{(IsWhite() ? "┳┓" : "╦╗")}" + "";
        }
    }
}
