using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class GameState
    {
        public int i, j;
        public string[,] history;
        public int[,] redo = new int[1, 4];
        public int[,] score = new int[2, 1];

        private static GameState instance;
        private GameState()
        {
        }

        public static GameState Instance()
        {
            if (instance == null)
                instance = new GameState();
            return instance;
        }
    }
}
