using ChessClassLibrary.Model;

namespace ChessClassLibrary
{
    public class King : IChessPiece
    {
        private bool _isWhite;

        public King(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public string Icon()
        {
            return $"{(IsWhite() ? "╋" : "╬")}" + " ";
        }

        public bool IsWhite()
        {
            return _isWhite;
        }


        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {

            for (int i = x1 - 1; i < x1 + 2; i++)
            {
                for (int j = y1 - 1; j < y1 + 2; j++)
                {
                    if (x2 == i && y2 == j)
                    {
                        if (game.Board[i, j] != null)
                        {
                            if (game.Board[i, j].IsWhite() == IsWhite())
                            {
                                return false;
                            }
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
