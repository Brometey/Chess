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
                case Figure.whiteRook:
                case Figure.blackRook:
                    return (fm.SignX == 0 || fm.SignY == 0) &&
                         CanStraightMove();
                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return (fm.SignX != 0 || fm.SignY != 0) &&
                         CanStraightMove();
                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();
                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();
                default: return false;
            }
        }

        bool CanPawnMove()
        {
            if (fm.From.Y < 1 || fm.From.Y >6)
                return false;
            int stepY = fm.Figure.GetColor() == Color.white ? 1 : -1;
            return
                CanPawnGo(stepY) ||
                CanPawnJump(stepY) ||
                CanPawnEat(stepY);
        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.To) == Figure.none)
                if (fm.DeltaX == 0)
                    if(fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanPawnJump(int stepY)
        {
            if (board.GetFigureAt(fm.To) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == 2 * stepY)
                        if (fm.From.Y == 1 || fm.From.Y == 6)
                            if (board.GetFigureAt(new Square(fm.From.X, fm.From.Y + stepY)) == Figure.none)
                                return true;
            return false;
        }

        private bool CanPawnEat(int stepY)
        {
            if (board.GetFigureAt(fm.To) != Figure.none)
                if (fm.AbsDeltaX == 1)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
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
                fm.From != fm.To &&
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
