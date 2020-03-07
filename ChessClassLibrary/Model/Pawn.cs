using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ChessClassLibrary.Model
{
	class Pawn : IChessPiece
	{
		private bool _isWhite;

		public Pawn(bool isWhite)
		{
			_isWhite = isWhite;
		}

		public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
		{
			
			return false;
		}

		public bool IsWhite()
		{
			return _isWhite;
		}

		public string Icon()
		{
			throw new NotImplementedException();
		}
	}
}
