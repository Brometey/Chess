using System;

namespace ChessLibrary
{
    enum Figure
    {
        none,

        whiteKing = 'K',
        whiteQueen = 'Q',
        whiteRock = 'R',
        whiteBishop = 'B',
        whiteKnight = 'N',
        whitePawn = 'P',

        blackKing = 'k',
        blackQueen = 'q',
        blackRock = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p',

    }

    static class FigureMethods
    {
        public static Color GetColor(this Figure figure)
        {
            if (figure == Figure.none)
                return Color.none;
            return (figure == Figure.whiteKing ||
                     figure == Figure.whiteQueen ||
                     figure == Figure.whiteRock ||
                     figure == Figure.whiteBishop ||
                     figure == Figure.whiteKnight ||
                     figure == Figure.whitePawn) ? Color.white : Color.black;
        }
    }
}
