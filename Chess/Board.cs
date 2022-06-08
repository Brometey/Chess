using System;
using System.Collections.Generic;
using System.Text;

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
            string [] parts  = Fen.Split();
            if (parts.Length != 6) return;
            InitFigures(parts[0]);
            MoveColor =( parts[1] == "b")? Color.black : Color.white;
            MoveNumber = int.Parse(parts[5]);

        }

        private void InitFigures(string data)
        {
            for (int j = 8; j >= 2; j--)
                data = data.Replace(j.ToString(), (j - 1).ToString() + "1");
            data = data.Replace("1", ".");
            string[] lines = data.Split('/');
            for (int y = 7; y >= 0; y--)
                for (int x = 0; x < 8; x++)
                    figures[x, y] = lines[7-y][x] == '.' ? Figure.none:(Figure)lines[7 - y][x];
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
            next.GenerateFen();
            return next;
        }

        public IEnumerable<FigureOnSquare> YieldFigures()
        {
            foreach (Square square in Square.YieldSquares())
                if (GetFigureAt(square).GetColor() == MoveColor)
                    yield return new FigureOnSquare(GetFigureAt(square), square);
        }

        private void GenerateFen()
        {
            Fen =  FenFigures() + " " +
                   (MoveColor == Color.white ? "w" : "b") +
                   " - - 0 " + MoveNumber.ToString();
        }

        private string FenFigures()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                    sb.Append(figures[x, y] == Figure.none ? '1' : (char)figures[x, y]);
                if (y > 0)
                    sb.Append('/');
            }
            string eight = "11111111";
            for (int j = 8; j >= 2; j--)
                sb.Replace(eight.Substring(0, j), j.ToString());
            return sb.ToString();   
        }
    }
}
