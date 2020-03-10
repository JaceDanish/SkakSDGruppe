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
		public void Start()
		{
			TestMove();
			//while (!ReadMove())
			//{
			//	ReadMove();
			//}
		}

		public bool ReadMove()
		{
			string input = Console.ReadLine();

			if (input.Length != 4)
			{
				return false;
			}

			input = input.ToLower();

			char[] inputArray = input.ToCharArray();


			//a: -97
			//1: - 49
			
			int[] coorInput = new int[4];
			coorInput[1] = ((int)inputArray[0] - 97);
			coorInput[0] = ((int)inputArray[1] - 47);
			coorInput[3] = ((int)inputArray[2] - 97);
			coorInput[2] = ((int)inputArray[3] - 47);



			return false;
		}

		public bool TestBorders()
		{
			return true;
		}

		public bool TestMove()
		{
			
			Game game = new Game();
			game.PrintBoard();
			game.Board[1, 0] = null;
			game.Board[1, 1] = null;
			game.Board[1, 2] = null;
			game.Board[1, 3] = null;
			game.Board[1, 4] = null;
			game.Board[1, 5] = null;
			game.Board[1, 6] = null;
			game.Board[1, 7] = null;

			bool res = game.Board[0, 3].CheckMove(game, 0,3,5,5);

			Console.WriteLine($"konge move {res}");
			return false;
		}
	}

}
