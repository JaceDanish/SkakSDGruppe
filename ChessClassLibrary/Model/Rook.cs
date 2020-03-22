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

		public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
		{
			int xVect = CreateVector(x2 - x1);
			int yVect = CreateVector(y2 - y1);

			int x = x1;
			int y = y1;

			while (x != x2 || y != y2)
			{
				x = x + xVect;
				y = y + yVect;
				//Console.WriteLine($"\nChecking {x} , {y}\nChessPiece: {game.Board[x, y]}");
				//Console.ReadKey();
				if (x == x2 && y == y2) return true;
				if (game.Board[x, y] != null) return false;
			}

			return true;


			//for (int i = x1 + xVect ; i != x2 ; i = i + xVect)
			//{
			// for (int j = y1 + yVect; i != x2; i = i + yVect)
			// {
			//  Console.WriteLine("x: " + i + " y: " + j);
			//  Console.ReadKey();
			//  if (game.Board[i, j] != null) return false;
			// }

			//}
			// return true;


			//int xDist = x2 - x1;
			//int yDist = y2 - y1;


			//Console.WriteLine("xVect: " + xVect + "\nyVect: " + yVect);


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