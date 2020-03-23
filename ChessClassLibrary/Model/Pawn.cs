using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChessClassLibrary.Model
{
	class Pawn : IChessPiece
	{
		private bool _isWhite;
        private bool _moved;

		public Pawn(bool isWhite)
		{
			_isWhite = isWhite;
            _moved = false;
		}

		public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            _moved = true;

            if ((_isWhite && x1 == 1) || (!_isWhite && x1 == 6))
                _moved = false;

            if (IsWhite() && x2 <= x1)
                return false;
            if (!IsWhite() && x1 <= x2)
                return false;
            if (_moved && (Math.Abs(x1 - x2) > 1 || Math.Abs(x2 - x1) > 1))
                return false;
            if (!_moved && (Math.Abs(x1 - x2) > 2 || Math.Abs(x2 - x1) > 2))
                return false;
            if (y1 != y2)
            {
                if (Math.Abs(y1 - y2) != 1 || Math.Abs(x1 - x2) != 1)
                    return false;
                if (game.Board[x2, y2] == null)
                    return false;
            }
            else if (game.Board[x2, y2] != null)
                return false;

            return true;
        }

        public bool IsWhite()
		{
			return _isWhite;
		}

		public string Icon()
		{
            return $"{(IsWhite() ? "☻" : "☺")}" + " ";
            //return $"{(IsWhite() ? "P" : "p")}" + " ";
        }
	}
}
