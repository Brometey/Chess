using System;
using ChessLibrary;

namespace ChessDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessLibrary.Chess chess = new ChessLibrary.Chess();
            while (true)
            {
                Console.WriteLine(chess.Fen);
                string move = Console.ReadLine();
                if (move == "") break;
                chess = chess.Move(move);
            }

        }
    }
}
