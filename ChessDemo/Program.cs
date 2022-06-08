using System;
using System.Collections.Generic;
using ChessLibrary;

namespace ChessDemo
{
    internal class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            ChessLibrary.Chess chess = new ChessLibrary.Chess("rnbqkbnr/pppppppp/8/8/8/8/1PP11PPP/RNBQKBNR w KQkq - 0 1");
            List<string> list;
            while (true)
            {
                list = chess.GetAllMoves();
                Console.WriteLine(chess.Fen);
                Console.WriteLine(ChessToAscii(chess));
                foreach (string moves in list)
                    Console.Write(moves + "\t");
                Console.WriteLine();
                Console.Write("> ");
                string move = Console.ReadLine();
                if (move == "q") break;
                if (move == "") move = list[rnd.Next(list.Count)];

                chess = chess.Move(move);
            }

        }
        static string ChessToAscii(ChessLibrary.Chess chess)
        {
            string text = "  +-----------------+\n";
            for (int y=7;y>=0;y--)
            {
                text += y + 1;
                text += " | ";
                for (int x = 0; x < 8; x++) 
                {
                    text += chess.GetFigureAt(x, y) + " ";
                }
                text += "|\n";
            }
            text += "  +-----------------+\n";
            text += "    a b c d e f g h\n";
            return text;

        }
    }
}
