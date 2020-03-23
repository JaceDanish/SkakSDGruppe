using ChessClassLibrary;
using ChessClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ChessConsoleApp
{
	class ChessEngine
	{
		private bool whitesMove = true;
		private Game game = new Game();

		public void Start()
		{
			
			//Nu kan vi lave tegn
			Console.OutputEncoding = Encoding.Unicode;
			int[] intArray;
			while (!game.GameOver)
			{
				game.PrintBoard();
				intArray = ReadMove();
				MovePiece(intArray, game);
				whitesMove = !whitesMove;
				
			}
			Console.WriteLine("GAME OVER");
		}

		private bool CheckKing(int[] inp, Game game)
		{
			Game testGame = new Game();

			for (int i = 0; i < 8; i++)
			for (int j = 0; j < 8; j++)
				testGame.Board[i, j] = game.Board[i, j];

			int xKing = 0, yKing = 0;

			if (!(testGame.Board[inp[0], inp[1]] is King))
			{
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						if (testGame.Board[i, j] is King && testGame.Board[i, j].IsWhite() == testGame.Board[inp[0], inp[1]].IsWhite())
						{
							xKing = i; yKing = j;
							break;
						}
					}
				}
			}
			else
			{
				xKing = inp[2];
				yKing = inp[3];
			}

			MovePiece(inp, testGame);

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (testGame.Board[i, j] != null)
						if (testGame.Board[i, j].IsWhite() != testGame.Board[xKing, yKing].IsWhite())
						{
							if (testGame.Board[i, j].CheckMove(testGame, i, j, xKing, yKing))
							{
								Console.WriteLine($"{i}, {j}");
								return false;
							}
						}
				}
			}
			return true;
		}

		public void MovePiece(int[] intArray, Game game)
		{
			game.Board[intArray[2], intArray[3]] = game.Board[intArray[0], intArray[1]];
			game.Board[intArray[0], intArray[1]] = null;
		}

		public int[] ReadMove()
		{
			int[] intArray = new int[4] {-1, -1, -1, -1};
			do
			{
				Console.WriteLine($"\n\nPlayer {(whitesMove ? "white" : "black")}, move:");
				string input = Console.ReadLine();
				if (!CheckLength(input)) continue;
				intArray = ConvertToIntArray(input);
			} while (!CheckMove(intArray, game) && !game.GameOver);
			return intArray;

		}
		
		private int[] ConvertToIntArray(string input)
		{
			input = input.ToLower();
			char[] inputArray = input.ToCharArray();
			int[] intArray = new int[4];
			intArray[1] = ((int)inputArray[0] - 97);
			intArray[0] = ((int)inputArray[1] - 49);
			intArray[3] = ((int)inputArray[2] - 97);
			intArray[2] = ((int)inputArray[3] - 49);
			//Console.WriteLine("intArray 0: " + intArray[1]);
			//Console.WriteLine("intArray 1: " + intArray[0]);
			//Console.WriteLine("intArray 2: " + intArray[3]);
			//Console.WriteLine("intArray 3: " + intArray[2]);

			return intArray;
		}

		public bool CheckMove(int[] intArray, Game game)
		{
			if (!CheckBorders(intArray, game)) return false;
			if (NoChessPiece(intArray, game)) return false;
			if (WrongColor(intArray, game)) return false;
			if (!TakingWrongColorPiece(intArray, game)) return false;
			if (!ChessPieceCheckMove(intArray, game)) return false;
			if (!CheckKing(intArray, game))
			{
				if (game.Board[intArray[0], intArray[1]].IsWhite() != whitesMove)
					if (GameOver(game, intArray[0], intArray[1]) || GameOver(game, intArray[2], intArray[3]))
					{
						game.GameOver = true;
					}

				game.PrintBoard();
				Console.WriteLine($"\nKing in check!");
				return false;
			}
			return true;
		}

		private bool TakingWrongColorPiece(int[] intArray, Game game) //returns true if trying to take a piece of the opposite color
																			//returns true if there is no chesspiece on the new square
		{
			if (game.Board[intArray[2], intArray[3]] == null) return true;
			if (game.Board[intArray[2], intArray[3]] != null)
			{
				if (game.Board[intArray[2], intArray[3]].IsWhite() != whitesMove)
				{
					return true;
				}
			}
			return false;
		}

		private bool ChessPieceCheckMove(int[] intArray, Game game)  //returns true if selected piece can make an illegal move
		{
			return game.Board[intArray[0], intArray[1]].CheckMove(game, intArray[0], intArray[1], intArray[2], intArray[3]);
		}

		private bool WrongColor(int[] intArray, Game game) //returns true if trying to move wrong color piece
		{
			return game.Board[intArray[0], intArray[1]].IsWhite() != whitesMove;
		}

		private bool NoChessPiece(int[] intArray, Game game) //returns true if there is no chess piece on the square 
		{
			return game.Board[intArray[0], intArray[1]] == null ? true : false;
		}

		private bool CheckLength(string str) //Length of input MUST be exactly 4 ie. LetterNumberLetterNumber
														 //returns true if input is exactly 4 characters
		{
			if (str.Length != 4)
			{
				return false;
			}
			return true;
		}
		
		private bool CheckBorders(int[] intArray, Game game)// intArray must be between 0 and 7. Returns true if it is
		{
			for (int i = 0; i < 4; i++)
			{
				if (intArray[i] < 0 || intArray[i] > 7)
				{
					return false;
				}
			}
			return true;
		}


		//public bool TestMove()
		//{

		//	game.PrintBoard();
		//	game.Board[1, 0] = null;
		//	game.Board[1, 1] = null;
		//	game.Board[1, 2] = null;
		//	game.Board[1, 3] = null;
		//	game.Board[1, 4] = null;
		//	game.Board[1, 5] = null;
		//	game.Board[1, 6] = null;
		//	game.Board[1, 7] = null;

		//	bool res = game.Board[0, 3].CheckMove(game, 0, 3, 5, 5);

		//	Console.WriteLine($"konge move {res}");
		//	return false;
		//}

		bool GameOver(Game game, int x, int y)
		{
			if (game.Board[x, y] != null && game.Board[x, y] is King)
			{
				(int kingX, int kingY) = GetKing(game, game.Board[x, y].IsWhite());

				for (int i = kingX - 1; i < kingX + 2; i++)
					for (int j = kingY - 1; j < kingY + 2; j++)
						for (int a = 0; a < 8; a++)
							for (int b = 0; b < 8; b++)
							{
								if (game.Board[a, b] != null && game.Board[a, b].IsWhite() != game.Board[x, y].IsWhite())
								{
									if (game.Board[a, b].CheckMove(game, a, b, kingX, kingY))
									{
										return false;
									}
								}
							}

				//List<(int, int)>enemyArray = GetPlacements(game, !game.Board[inpArray[0], inpArray[1]].White());
				List<(int, int)> playerArray = GetPlacements(game, game.Board[x, y].IsWhite());

				Game testGame = new Game();

				int[] kingArray = new int[] { kingX, kingY, kingX, kingY };

				for (int i = 0; i < 8; i++)
					for (int j = 0; j < 8; j++)
						testGame.Board[i, j] = game.Board[i, j];

				foreach (var p in playerArray)
				{
					(int a, int b) = p;
					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
						{
							if (testGame.Board[x, y].CheckMove(testGame, a, b, i, j))
							{
								int[] inp = new int[] { a, b, i, j };
								MovePiece(inp, testGame);

								if (CheckKing(kingArray, testGame))
									return false;
							}
						}
				}
			}
			return true;
		}

		(int, int) GetKing(Game game, bool kingColor)
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (game.Board[i, j] is King && game.Board[i, j].IsWhite() == kingColor)
					{
						return (i, j);
					}
				}
			}
			return (0, 0);
		}

		List<(int, int)> GetPlacements(Game game, bool placesColor)
		{
			List<(int, int)> placements = new List<(int, int)>();
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
				{
					if (game.Board[i, j] != null && game.Board[i, j].IsWhite() != placesColor)
						placements.Add((i, j));
				}
			return placements;
		}
	}

}
