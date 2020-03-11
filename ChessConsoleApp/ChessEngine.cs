using ChessClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
				PlayGame();
			}
		}

		void PlayGame()
		{
			game.PrintBoard();
			Console.WriteLine($"\n\nPlayer {(whitesMove ? "white" : "black")}, move:");
			while (!ReadMove())
			{
				ReadMove();
			}
		}

		public bool ReadMove()
		{
			string input = Console.ReadLine();
			if (!checkLength(input))
			{
				return false;
			}

			int[] intArray = ConvertToIntArray(input);
			
			if (!TestMove())
			{
				return false;
			}
			return true;
		}

		private bool checkLength(string str) //Length of input MUST be exactly 4 ie. LetterNumberLetterNumber
		{
			if (str.Length != 4)
			{
				return false;
			}
			return true;
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

		public bool TestBorders()
		{
			return true;
		}

		public bool TestMove()
		{

			game.PrintBoard();
			game.Board[1, 0] = null;
			game.Board[1, 1] = null;
			game.Board[1, 2] = null;
			game.Board[1, 3] = null;
			game.Board[1, 4] = null;
			game.Board[1, 5] = null;
			game.Board[1, 6] = null;
			game.Board[1, 7] = null;

			bool res = game.Board[0, 3].CheckMove(game, 0, 3, 5, 5);

			Console.WriteLine($"konge move {res}");
			return false;
		}
	}

}
