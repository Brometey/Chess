using System;

namespace ChessLibrary
{
    class Board
    {
        public string Fen { get; private set; }
        Figure[,] figures;
        public Color MoveColor { get; private set; } // Чей ход.
        public int MoveNumber { get; private set; } // Количество сделанных ходов?

        public Board(string fen)
        {
            Fen = fen;
            figures = new Figure[8, 8];
            MoveColor = Color.white;
            Init();

        }

        void Init()
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing);
            SetFigureAt(new Square("h8"), Figure.blackKing);
        }

        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
                return figures[square.X, square.Y];
            return Figure.none;
        }

        void SetFigureAt(Square square, Figure figure)
        {
            if (square.OnBoard())
                figures[square.X, square.Y] = figure;
        }

        public Board Move(FigureMoving fm)
        {
            Board next = new Board(Fen);
            next.SetFigureAt(fm.From, Figure.none);
            next.SetFigureAt(fm.To, fm.Promotion == Figure.none ? fm.Figure : fm.Promotion);
            if (MoveColor == Color.black)
                next.MoveNumber++;
            next.MoveColor = MoveColor.FlipColor();
            return next;
        }
    }
}
