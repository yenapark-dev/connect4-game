using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Linq;

namespace ConnectFour
{
    class Player
    {
        public int PlayMode { get; set; }
        public string PlayerName { get; set; }
        public int GameLevel { get; set; }
        public int GameStatus { get; set; }

        public virtual int setPlayMode()
        {
            WriteLine("Please select the play mode. \n");
            WriteLine("Press 1 to play with another human. Press 2 to play with AI. >> ");
            PlayMode = Convert.ToInt32(ReadLine());

            // Check and allow a user to re-enter if a value is invalid
            while (PlayMode != 1 && PlayMode != 2)
            {
                WriteLine("Invalid value - Number must be 1 or 2.");
                WriteLine("Please select the play mode. \nPress 0 to play with another human. Press 1 to play with AI. >> ");
                PlayMode = Convert.ToInt32(ReadLine());
            }
            return PlayMode;
        }

        // Set the player name
        public virtual string setPlayerName()
        {
            WriteLine("Enter your name. >> ");
            PlayerName = ReadLine();

            return PlayerName;
        }

        // Set the game level when a user plays with AI
        public int setGameLevel()
        {
            WriteLine("Please select the game level. \n");
            WriteLine("Press 1 for easy. Press 2 for normal. >> ");
            GameLevel = Convert.ToInt32(ReadLine());

            // Check and allow a user to re-enter if a value is invalid
            while (GameLevel != 1 && GameLevel != 2)
            {
                WriteLine("Invalid value - Number must be 1 or 2.");
                WriteLine("Please select the game level. \nPress 1 for easy. Press 2 for normal. >> ");
                GameLevel = Convert.ToInt32(ReadLine());
            }
            return GameLevel;
        }
    }
}
