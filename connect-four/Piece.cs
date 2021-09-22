using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Piece
    {
        public int historyNum = 1;
        public int winner;
        public int col;
        public int row;
        public int currentPlayer;

        private static Piece instance;
        private Piece()
        {
        }

        public static Piece Instance()
        {
            if (instance == null)
                instance = new Piece();
            return instance;
        }
    }
}
