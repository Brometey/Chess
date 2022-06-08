using System;


namespace ChessLibrary
{
    class Moves
    {
        FigureMoving fm;
        Board board;

        public Moves(Board board)
        {
            this.board = board;
        }

        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return
                CanMoveFrom() &&
                CanMoveTo() &&
                CanFigureMove();
        }

        private bool CanFigureMove()
        {
            switch (fm.Figure)
            {
                case Figure.whiteKing:
                case Figure.blackKing:
                    return CanKingMove();
                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return CanStraightMove();
                case Figure.whiteRock:
                case Figure.blackRock:
                   return false;
                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return false;
                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();
                case Figure.whitePawn:
                case Figure.blackPawn:
                    return false;
                default: return false;
            }
        }

        private bool CanStraightMove()
        {
            Square at = fm.From;
            do
            {
                at = new Square(at.X + fm.SignX, at.Y + fm.SignY);
                if (at == fm.To)
                    return true;
            } while (at.OnBoard() && board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanMoveTo()
        {
            return fm.To.OnBoard() &&
                fm.From!= fm.To &&
                board.GetFigureAt(fm.To).GetColor() != board.MoveColor;
        }

        bool CanMoveFrom()
        {
            return fm.From.OnBoard() &&
                fm.Figure.GetColor() == board.MoveColor;
        }      
        /// <summary>
        /// Метод для ограничения перемещения Короля.
        /// </summary>
        /// <returns> может ли король ходить </returns>
        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }
        /// <summary>
        /// Метод для ограничения перемещения Коня
        /// </summary>
        /// <returns>может ли конь так перемещаться</returns>
        private bool CanKnightMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
        }
    }
}
