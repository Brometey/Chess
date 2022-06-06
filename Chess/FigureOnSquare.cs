﻿using System;
using System.Collections.Generic;

namespace ChessLibrary
{
    class FigureOnSquare
    {
        public Figure Figure { get; private set; }
        public Square Square { get; private set; }

        public FigureOnSquare(Figure figure, Square square)
        {
            Figure = figure;
            Square = square;
        }

    }
}
