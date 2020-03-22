using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessClassLibrary.Model
{
    class Rook : IChessPiece
    {
        private bool _isWhite;

        public Rook(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {


            /*
            bool res = false;
            // Brætfelt F3 (x1, y1) husk det er 0 indekseret
            if (x1 == x2 || y1 == y2)
            {
                if (x2 > x1)
                {
                    for (int i = x1; i < 8; i++)
                    {
                        if (i != x2)
                        {
                            if (game.Board[i, y1] != null)
                            {
                                res = false;
                            }
                        }
                        else
                        {
                            if (game.Board[i, y1] != null)
                            {
                                if (game.Board[i, y1].IsWhite() == IsWhite())
                                {
                                    res = false;
                                }
                                else res = true;
                            }
                        }
                    }
                }

                if (x2 < x1)
                {
                    for (int i = x1; i > -1; i--)
                    {
                        if (i != x2)
                        {
                            if (game.Board[i, y1] != null)
                            {
                                res = false;
                            }
                        }
                        else
                        {
                            if (game.Board[i, y1] != null)
                            {
                                if (game.Board[i, y1].IsWhite() == IsWhite())
                                {
                                    res = false;
                                }
                                else res = true;
                            }
                        }
                    }
                }

                if (y2 > y1)
                {
                    for (int i = y1; i < 8; i++)
                    {
                        if (i != y2)
                        {
                            if (game.Board[x1, i] != null)
                            {
                                res = false;
                            }
                        }
                        else
                        {
                            if (game.Board[x1, i] != null)
                            {
                                if (game.Board[x1, i].IsWhite() == IsWhite())
                                {
                                    res = false;
                                }
                                else res = true;
                            }
                        }
                    }
                }

                if (y2 < -1)
                {
                    for (int i = y1; i > -1; i--)
                    {
                        if (i != y2)
                        {
                            if (game.Board[x1, i] != null)
                            {
                                res = false;
                            }
                        }
                        else
                        {
                            if (game.Board[x1, i] != null)
                            {
                                if (game.Board[x1, i].IsWhite() == IsWhite())
                                {
                                    res = false;
                                }
                                else res = true;
                            }
                        }
                    }
                }
            }
            else res = false;

            return res;
            */

            return true;
        }

        public string Icon()
        {
            return $"{(IsWhite() ? "■" : "□")}" + " ";
        }

        public bool IsWhite()
        {
            return _isWhite;
        }
    }
}
