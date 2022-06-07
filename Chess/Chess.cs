using System;

namespace ChessLibrary
{
    /// <summary>
    /// Состояние шахматной партии.
    /// </summary>
    public class Chess
    {
        public string Fen { get; private set; }
        Board board;
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            Fen = fen; 
            board = new Board(fen);
        }

        Chess(Board board)
        {
            this.board = board;
            Fen = board.Fen;     
        }

        /// <summary>
        /// Ход
        /// </summary>
        /// <param name="move"> запись хода </param>
        /// <returns> новое состояние партии </returns>
        public Chess Move(string move)
        {
            // Сгенерировать ход.
            FigureMoving fm = new FigureMoving(move);
            // Создать новую доску после выполнения хода.
            Board nextBoard = board.Move(fm);
            // Новый объект шахмат после новой доски.
            Chess nextChess = new Chess(nextBoard);

            return nextChess;
        }

        /// <summary>
        /// Метод для получения фигуры.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public char GetFigureAt(int x, int y)
        {
            // Сама клетка ,в которой находится фигура.
            Square square = new Square(x, y);
            // Получить фигуру по данным координатам.
            Figure f = board.GetFigureAt(square);
            // Вернуть точку, если клетка пустая,
            // Вернуть фигуру, если нет.
            return f == Figure.none ? '.' : (char)f;
        }
    }
}
