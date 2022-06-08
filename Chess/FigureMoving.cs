using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    class FigureMoving
    {
        // Фигура.
        public Figure Figure { get; private set; }
        // Откуда.
        public Square From { get;private set; }
        // Куда.
        public Square To { get; private set; }
        // Во что превращается, если это пешка.
        public Figure Promotion { get; private set; }

        public FigureMoving(FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            Figure = fs.Figure;
            From = fs.Square;
            To = to;
            Promotion = promotion;
        }
        
        /// <summary>
        /// Конструктор , принимающий ход.
        /// </summary>
        /// <param name="move"> экземпляр хода </param>
        public FigureMoving(string move)
        {
            Figure = (Figure)move[0];
            From = new Square(move.Substring(1, 2));
            To = new Square(move.Substring(3, 2));
            Promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none; 
        }

        public int DeltaX { get { return To.X - From.X; } }
        public int DeltaY { get { return To.Y - From.Y; } }

        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }
        public int SignX{ get { return Math.Sign(DeltaX); } }
        public int SignY { get { return Math.Sign(DeltaY); } }
    }
}
