using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class HumanPlayer : Player
    {
        public override int setPlayMode()
        {
            PlayMode = 1;
            return PlayMode;
        }

        public override string setPlayerName()
        {
            PlayerName = "Human";

            return PlayerName;
        }
    }
}
