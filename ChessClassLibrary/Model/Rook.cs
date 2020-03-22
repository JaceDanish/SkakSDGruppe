using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessClassLibrary.Model
{
	class Rook : IChessPiece
	{
		private bool _isWhite;

		public Rook(bool isWhite)
		{
			_isWhite = isWhite;
		}

		//public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
		//{
		//	int xVect = CreateVector(x2 - x1);
		//	int yVect = CreateVector(y2 - y1);

		//	int x = x1;
		//	int y = y1;

		//	while (x != x2 || y != y2)
		//	{
		//		x = x + xVect;
		//		y = y + yVect;
		//		//Console.WriteLine($"\nChecking {x} , {y}\nChessPiece: {game.Board[x, y]}");
		//		//Console.ReadKey();
		//		if (x == x2 && y == y2) return true;
		//		if (game.Board[x, y] != null) return false;
		//	}
		//	return true;
		//}

			public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
			{
				if (x1 != x2 && y1 != y2)
					return false;

				int xDir = 0, yDir = 0;

				if (x1 < x2)
					xDir = 1;
				else if (x1 > x2)
					xDir = -1;
				else if (y1 < y2)
					yDir = 1;
				else
					yDir = -1;

				for (int i = x1 + xDir, j = y1 + yDir; (i != x2 || j != y2); i += xDir, j += yDir)
				{
					if (game.Board[i, j] != null && (i != x2 || j != y2))
						return false;
				}

				return true;
			}

		public int CreateVector(int dist)
		{
			int vect = 0;
			if (dist != 0) vect = dist / Math.Abs(dist);
			return vect;
		}

		public string Icon()
		{
			return $"{(IsWhite() ? "■" : "□")}" + " ";
		}

		public bool IsWhite()
		{
			return _isWhite;
		}
	}
}