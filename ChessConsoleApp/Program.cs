using System;

namespace ChessConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			ChessEngine chessEngine = new ChessEngine();

			chessEngine.Start();
			Console.ReadLine();

			//TestEngine testEngine = new TestEngine();
			//testEngine.Start();
		}
	}
}
