using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    public class Game
    {
        private IChessPiece[,] _board;

        public Game()
        {
            _board = new IChessPiece[8, 8];

        }

        public IChessPiece[,] Board
        {
            get; set;
        }




    }
}
