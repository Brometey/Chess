using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    /// <summary>
    /// Класс, описывающий фигуру с клеткой, 
    /// в которой она находится.
    /// </summary>
    class FigureOnSquare
    {
        // Фигура.
        public Figure Figure { get; private set; }
        // Клетка, в которой находится фигура.
        public Square Square { get; private set; }

        /// <summary>
        /// Конструктор для фигуры в клетке.
        /// </summary>
        /// <param name="figure"> фигура </param>
        /// <param name="square"> клетка </param>
        public FigureOnSquare(Figure figure, Square square)
        {
            Figure = figure;
            Square = square;
        }

    }
}
