using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Knight : IChessPiece
    {
        private bool _isWhite;

        public bool IsWhite()
        {
            return _isWhite;
        }

        public string Icon()
        {
            return "N";
        }

        public Knight(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            return true;
            
            //throw new NotImplementedException();
        }



        /*
        public string Icon()
        {
            throw new NotImplementedException();
        }

        public bool IsWhite()
        {
            throw new NotImplementedException();
        }
        */


    }
}
