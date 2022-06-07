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
            // rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            // 0                                           1 2    3 4 5
            string[] parts = Fen.Split();
            if (parts.Length != 6) return;
            InitFigures(parts[0]);
            MoveColor = (parts[1] == "b") ? Color.black : Color.white; 
            MoveNumber = int.Parse(parts[5]);
 
        }

        private void InitFigures(string data)
        {
            for (int j = 8; j >= 2; j--)
            {
                data = data.Replace(j.ToString(),(j-1).ToString() + "1");
            }
            data = data.Replace("1", ".");
            string[] lines = data.Split('/');
            for (int y = 7; y >= 0; y--)
                for (int x = 0; x < 8; x++)
                    figures[x, y] = (Figure)lines[7 - y][x];
            
            
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
