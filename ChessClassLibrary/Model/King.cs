using ChessClassLibrary.Model;

namespace ChessClassLibrary
{
    class King : IChessPiece
    {
        private bool _isWhite;

        public King(bool isWhite)
        {
            _isWhite = isWhite;
        }

        public string Icon()
        {
            return "K";
        }

        public bool IsWhite()
        {
            return _isWhite;
        }


        public bool CheckMove(Game game, int x1, int y1, int x2, int y2)
        {

            for (int i = y1 - 1; i < y1 + 2; i++)
            {
                for (int j = x1 - 1; j < x1 + 2; j++)
                {
                    if (y2 == j && x2 == i)
                    {
                        if (game.Board[j, i] != null)
                        {
                            if (game.Board[j, i].IsWhite() == IsWhite())
                            {
                                return false;
                            }
                            else return true;
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
