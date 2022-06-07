﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    /// <summary>
    /// Клетка
    /// </summary>
    struct Square
    {
        // Пустая клетка.
        public static Square none = new Square(-1,-1);
        // Координата по иксам (буквенная часть)
        public int X { get; private set; }
        // Координата по игреку (цифра)
        public int Y { get; private set; }

        public Square (int x, int y)
        {
            X = x;
            Y= y;   
        }
        /// <summary>
        /// Конструктор, принимающий клетку в 
        /// строчном виде.
        /// </summary>
        /// <param name="e2"></param>
        public Square(string e2)
        {

            if (e2.Length==2 &&
                e2[0] >= 'a' && e2[0] <= 'h' &&
                e2[1] >= '1' && e2[1] <= '8')
            {
                X = e2[0] - 'a';
                Y = e2[1] - '1';
            }
            else
                this = none;
        }
        /// <summary>
        /// Проверка на нахождение клетки на доске
        /// </summary>
        /// <returns></returns>
        public bool OnBoard()
        {
            return X>=0 && X<8 && Y>=0 && Y<8;
        }
    }
}
