using System;
namespace ConnectFour
{
    // Singletone
    class GivenSetting
    {
        public static int BOARD_HEIGHT = 6;
        public static int BOARD_WIDTH = 7;
        public char EMPTY = ' ';
        public char[,] state;
        public int pieceCnt;
        public char player;
        public int playMode;
        public string player1Name;
        public string player2Name;
        //public int gameStatus;
        public int gameLevel;

        private static GivenSetting instance;
        private GivenSetting()
        {
        }

        public static GivenSetting Instance()
        {
            if (instance == null)
                instance = new GivenSetting();
            return instance;
        }
    }
}
