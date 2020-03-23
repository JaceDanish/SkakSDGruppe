using ChessClassLibrary;
using ChessClassLibrary.Model;
using System;
using System.Collections.Generic;

namespace ChessConsoleApp
{
	class TestEngine
	{
		public void Start()
		{

			bool whitesTurn = true;
			bool gameFinished = false;

			Game game = new Game();

			StartScreen();

			game.PrintBoard();

			do
			{
				MovePiece(GetInput(whitesTurn, game), game);

				game.PrintBoard();

				whitesTurn = (whitesTurn ? false : true);
			}
			while (!gameFinished);
		}

		private void MovePiece(int[] inp, Game game)
		{
			game.Board[inp[2], inp[3]] = game.Board[inp[0], inp[1]];
			game.Board[inp[0], inp[1]] = null;
		}

		private int[] GetInput(bool whitesTurn, Game game)
		{
			char[] inpArray;
			do
			{
				Console.WriteLine($"\nPlayer {(whitesTurn ? "white" : "black")}, move");
				string inpStr = Console.ReadLine();
				inpStr = inpStr.ToLower();
				inpArray = inpStr.ToCharArray();
			}
			while (!CheckInput(inpArray, game, whitesTurn));

			return CharToInt(inpArray);
		}

		private bool CheckInput(char[] inpArray, Game game, bool whitesTurn)
		{
			if (inpArray.Length != 4)
			{
				Console.WriteLine("Bad input!");
				return false;
			}
			int[] intInpArray = CharToInt(inpArray);

			for (int i = 0; i < intInpArray.Length; i++)
			{
				if (intInpArray[i] < 0 || intInpArray[i] > 7)
				{
					Console.WriteLine("Bad input!");
					return false;
				}
			}
			if (game.Board[intInpArray[0], intInpArray[1]] == null || game.Board[intInpArray[0], intInpArray[1]].IsWhite() != whitesTurn)
			{
				Console.WriteLine("Illegal move!");
				return false;
			}
			//Must be changed before "rokade" can be implemented(maybe not....)
			//Rokade:
			//King is moved 2 squares left or right and Rook is moved to the other side of the king.
			if (game.Board[intInpArray[2], intInpArray[3]] != null && game.Board[intInpArray[2], intInpArray[3]].IsWhite() == whitesTurn)
			{
				Console.WriteLine("Illegal move!");
				return false;
			}
			if (!game.Board[intInpArray[0], intInpArray[1]].CheckMove(game, intInpArray[0], intInpArray[1], intInpArray[2], intInpArray[3]))
			{
				Console.WriteLine("Illegal move!");
				return false;
			}
			if (!CheckKing(game, intInpArray))
			{
				if (GameOver(game, intInpArray))
				{
					Console.WriteLine($"Game over!\n");

				}

				game.PrintBoard();
				Console.WriteLine("King in check!");
				return false;
			}
			return true;
		}

		private int[] CharToInt(char[] inpArray)
		{
			int[] intInpArray = new int[4];
			//switch x and y so it matches board array
			intInpArray[1] = ((int)inpArray[0] - 97);
			intInpArray[0] = ((int)inpArray[1] - 49);
			intInpArray[3] = ((int)inpArray[2] - 97);
			intInpArray[2] = ((int)inpArray[3] - 49);

			return intInpArray;
		}

		private bool CheckKing(Game game, int[] inp)
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
								//Console.WriteLine($"{i}, {j}");
								return false;
							}
						}
				}
			}
			return true;
		}

		bool GameOver(Game game, int[] inpArray)
		{
			(int kingX, int kingY) = GetKing(game, game.Board[inpArray[0], inpArray[1]].IsWhite());

			for (int i = kingX - 1; i < kingX + 2; i++)
				for (int j = kingY - 1; j < kingY + 2; j++)
					for (int a = 0; a < 8; a++)
						for (int b = 0; b < 8; b++)
						{
							if (game.Board[a, b] != null && game.Board[a, b].IsWhite() != game.Board[inpArray[0], inpArray[1]].IsWhite())
							{
								if (game.Board[a, b].CheckMove(game, a, b, kingX, kingY))
									return false;
							}
						}

			//List<(int, int)>enemyArray = GetPlacements(game, !game.Board[inpArray[0], inpArray[1]].IsWhite());
			List<(int, int)> playerArray = GetPlacements(game, game.Board[inpArray[0], inpArray[1]].IsWhite());

			Game testGame = new Game();

			int[] kingArray = new int[] { kingX, kingY, kingX, kingY };

			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					testGame.Board[i, j] = game.Board[i, j];

			foreach (var p in playerArray)
			{
				(int x, int y) = p;
				for (int i = 0; i < 8; i++)
					for (int j = 0; j < 8; j++)
					{
						if (testGame.Board[x, y].CheckMove(testGame, x, y, i, j))
						{
							int[] inp = new int[] { x, y, i, j };
							MovePiece(inp, testGame);
							if (CheckKing(testGame, kingArray))
								return false;
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

		private void StartScreen()
		{
			Console.WriteLine("------WELCOME!------\n    Usage: b1c1\n    White begins\nPress enter to start!");
			Console.ReadKey();
		}
	}
}
