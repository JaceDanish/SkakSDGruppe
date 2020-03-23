using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
	public class Game
	{
		public IChessPiece[,] Board;
		public bool _gameOver;

		public Game()
		{
			Board = new IChessPiece[8,8];
			Board = FillBoard();
			
		}

		public bool GameOver
        {
            get { return _gameOver; }
			set { _gameOver = value; }
        }

		//public IChessPiece[,] Board { get; set; }

		private IChessPiece[,] FillBoard()
		{
			IChessPiece[,] board = new IChessPiece[8, 8];

			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
				{
					switch (i)
					{
						case 0:
						case 7:
							{
								switch (j)
								{
									case 0:
									case 7:
										board[i, j] = new Rook(i == 0 ? true : false);
										break;
									case 1:
									case 6:
										board[i, j] = new Knight(i == 0 ? true : false);
										break;
									case 2:
									case 5:
										board[i, j] = new Bishop(i == 0 ? true : false);
										break;
									case 3:
										board[i, j] = new Queen(i == 0 ? true : false);
										break;
									case 4:
										board[i, j] = new King(i == 0 ? true : false);
										break;
								}
							}
							break;
						case 1:
						case 6:
							board[i, j] = new Pawn(i == 1 ? true : false);
							break;
						default:
							board[i, j] = null;
							break;
					}
				}

			return board;
		}

		public void PrintBoard()
		{
			
			Console.Clear();
			for (int i = -1; i < 8; i++)
			{
				Console.WriteLine();
				for (int j = -1; j < 8; j++)
				{
					if (i == -1 && j == -1)
					{
						Console.Write("");
					}
					else if (i == -1)
					{
						Console.Write("  " + (char)(j + 65));
					}
					else if (j == -1)
					{
						Console.Write(i + 1);
					}
					else if (Board[i, j] != null)
					{
						Console.Write(" " + Board[i, j].Icon());
					}
					else
					{
						Console.Write(" . ");
					}
				}

			}
		}
	}
}
