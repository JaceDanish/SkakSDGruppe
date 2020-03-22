using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Queen : IChessPiece
    {
        private bool _iswhite;
        private Rook _rook;
        private Bishop _bishop;
        

        public Queen(bool isWhite)
        {
            _iswhite = isWhite;
            _rook = new Rook(isWhite);
            _bishop = new Bishop(isWhite);
        }


        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            if (_rook.CheckMove(game, x1, y1, x2, y2))
            {
                return true;
            }
            else if (_bishop.CheckMove(game, x1, y1, x2, y2))
            {
                return true;
            }
            return false;
        }

        
        public string Icon()
        {
            return $"{(IsWhite() ? "•♀" : "○♀")}" + "";
        }


        public bool IsWhite()
        {
            return _iswhite;
        }
    }
}
