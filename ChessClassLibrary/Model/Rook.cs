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
			//int xDist = x2 - x1;
			//int yDist = y2 - y1;

			int xVect = CreateVector(x2 - x1);
			int yVect = CreateVector(y2 - y1);

			Console.WriteLine("xVect: " + xVect + "\nyVect: " + yVect);

			int x = x1;
			int y = y1;

			while (x != x2 || y != y2)
			{
				x = x + xVect;
				y = y + yVect;
				Console.WriteLine("\nFUCK DET LORT");
				Console.WriteLine($"\nx2: {x2}\ny2: {y2}");
				Console.WriteLine($"\nChecking {x} , {y}\nChessPiece: {game.Board[x, y]}");
				Console.ReadKey();
				if (x == x2 && y == y2) return true;
				if (game.Board[x, y] != null) return false;
			}

			return true;



			//y2-y1=0
			//for (int i = x1+xVektor ; i != x2 ; i = i + xVektor)
			//{
			// for (int j = y1 + yVektor; i != x2; i = i + yVektor)
			// {
			//  Console.WriteLine("x: " + i + " y: " + j);
			//  Console.ReadKey();
			//  if (game.Board[i, j] != null) return false;
			// }
			//}
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
/*
bool res = false;
// Brætfelt F3 (x1, y1) husk det er 0 indekseret
if (x1 == x2 || y1 == y2)
{
	 if (x2 > x1)
	 {
		  for (int i = x1; i < 8; i++)
		  {
				if (i != x2)
				{
					 if (game.Board[i, y1] != null)
					 {
						  res = false;
					 }
				}
				else
				{
					 if (game.Board[i, y1] != null)
					 {
						  if (game.Board[i, y1].IsWhite() == IsWhite())
						  {
								res = false;
						  }
						  else res = true;
					 }
				}
		  }
	 }

	 if (x2 < x1)
	 {
		  for (int i = x1; i > -1; i--)
		  {
				if (i != x2)
				{
					 if (game.Board[i, y1] != null)
					 {
						  res = false;
					 }
				}
				else
				{
					 if (game.Board[i, y1] != null)
					 {
						  if (game.Board[i, y1].IsWhite() == IsWhite())
						  {
								res = false;
						  }
						  else res = true;
					 }
				}
		  }
	 }

	 if (y2 > y1)
	 {
		  for (int i = y1; i < 8; i++)
		  {
				if (i != y2)
				{
					 if (game.Board[x1, i] != null)
					 {
						  res = false;
					 }
				}
				else
				{
					 if (game.Board[x1, i] != null)
					 {
						  if (game.Board[x1, i].IsWhite() == IsWhite())
						  {
								res = false;
						  }
						  else res = true;
					 }
				}
		  }
	 }

	 if (y2 < -1)
	 {
		  for (int i = y1; i > -1; i--)
		  {
				if (i != y2)
				{
					 if (game.Board[x1, i] != null)
					 {
						  res = false;
					 }
				}
				else
				{
					 if (game.Board[x1, i] != null)
					 {
						  if (game.Board[x1, i].IsWhite() == IsWhite())
						  {
								res = false;
						  }
						  else res = true;
					 }
				}
		  }
	 }
}
else res = false;

return res;
*/


