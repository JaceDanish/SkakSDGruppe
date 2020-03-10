using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Queen : IChessPiece
    {
        private bool _iswhite;

        public Queen(bool iswhite)
        {
            _iswhite = iswhite;
        }


        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
        }

        public string Icon()
        {
            return "Q";
        }

        public bool IsWhite()
        {
            return _iswhite;
        }
    }
}
