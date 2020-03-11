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
		private bool gameOver = false;
		private Game game = new Game();

		public void Start()
		{
			while (!gameOver)
			{
				game.PrintBoard();
				ReadMove();
				whitesMove = !whitesMove;
			}
		}

		public int[] ReadMove()
		{
			int[] intArray;// = new int[4];
								//if (!checkLength(input))
			do
			{
				Console.WriteLine($"\n\nPlayer {(whitesMove ? "white" : "black")}, move:");
				string input = Console.ReadLine();
				intArray = ConvertToIntArray(input);

			} while (!CheckMove(intArray));
			return intArray;

		}
		
		private int[] ConvertToIntArray(string input)
		{
			input = input.ToLower();
			char[] inputArray = input.ToCharArray();
			int[] intArray = new int[4];
			intArray[1] = ((int)inputArray[0] - 97);
			intArray[0] = ((int)inputArray[1] - 47);
			intArray[3] = ((int)inputArray[2] - 97);
			intArray[2] = ((int)inputArray[3] - 47);
			return intArray;
		}

		public bool CheckMove(int[] intArray)
		{
			if (!CheckLength(intArray)) return false;
			if (!CheckBorders(intArray)) return false;
			if (NoChessPiece(intArray)) return false;
			if (WrongColor(intArray)) return false;
			if (TakingWrongColorPiece(intArray)) return false;
			if (!ChessPieceCheckMove(intArray)) return false;
			return true;
		}

		private bool TakingWrongColorPiece(int[] intArray) //return true if trying to take a piece of the opposite color
		{
			return game.Board[intArray[2], intArray[3]].IsWhite() == whitesMove;
		}

		private bool ChessPieceCheckMove(int[] intArray)  //return true if selected piece can make an illegal move
		{
			return game.Board[intArray[0], intArray[1]].CheckMove(game, intArray[0], intArray[1], intArray[2], intArray[3]);
		}

		private bool WrongColor(int[] intArray) //returning true if trying to move wrong color piece
		{
			return game.Board[intArray[0], intArray[1]].IsWhite() != whitesMove;
		}

		private bool NoChessPiece(int[] intArray) //returning true if there is no chess piece on the square 
		{
			return game.Board[intArray[0], intArray[1]] == null ? true : false;
		}

		private bool CheckLength(int[] intArray) //Length of input MUST be exactly 4 ie. LetterNumberLetterNumber 
		{
			if (intArray.Length != 4)
			{
				return false;
			}
			return true;
		}
		
		private bool CheckBorders(int[] intArray)// intArray must be between 0 and 7 
		{
			for (int i = 0; i < 5; i++)
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
		}
	}

}
