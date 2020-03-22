using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Bishop : IChessPiece
    {
        private bool _isWhite;

        public Bishop(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {
            if (Math.Abs(x1 - y1) != Math.Abs(x2 - y2))
            {
                if (x1 + y1 != x2 + y2)
                {
                    return false;
                }
            }
            if (x1 > x2 && y1 > y2)
            {
                for (int i = x1 - 1, j = y1 - 1; (i >= x2 || j >= y2); i--, j--)
                {
                    if (!BishopCanMove(i, j, y2, x2, game))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (x1 > x2 && y2 > y1)
            {
                for (int i = x1-1, j = y1+1; (i >= x2 || j <= y2); i--, j++)
                {
                    if (!BishopCanMove(i, j, y2, x2, game))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (y1 > y2 && x2 > x1)
            {
                for (int i = x1+1, j = y1-1; (i <= x2 || j >= y2); i++, j--)
                {
                    if (!BishopCanMove(i, j, y2, x2, game))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (x2 > x1 && y2 > y1)
            {
                for (int i = x1+1, j = y1+1; (i <= x2 || j <= y2); i++, j++)
                {
                    if (!BishopCanMove(i, j, y2, x2, game))
                    {
                        return false;
                    }
                }
                return true;
            }

            Console.WriteLine("Bishop error");
            return false;
        }

        public string Icon()
        {
            return $"{(IsWhite() ? "▲" : "∆")}" + " ";
        }

        public bool IsWhite()
        {
            return _isWhite;
        }

        private bool BishopCanMove(int i, int j, int y2, int x2, Game game)
        {
            if (i < 0 || i > 7 || j < 0 || j > 7)
                return false;

            if (game.Board[i, j] != null)
            {
                if (game.Board[i, j].IsWhite() == _isWhite)
                    return false;
            }

            if (game.Board[i, j] != null && i != x2 && j != y2 && game.Board[i, j].IsWhite() != _isWhite)
            {
                return false;
            }

            return true;
        }
    }
}
