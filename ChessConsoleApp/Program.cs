using System;
using ChessClassLibrary.Model;

namespace ChessConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessEngine chessEngine = new ChessEngine();

            chessEngine.Start();
            Console.ReadLine();
        }
    }
}
