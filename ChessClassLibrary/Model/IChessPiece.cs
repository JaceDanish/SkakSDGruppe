using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    public interface IChessPiece
    {
        bool CheckMove(Game game, int x1, int y1, int x2, int y2);

        bool IsWhite();

        string Icon();
    }
}