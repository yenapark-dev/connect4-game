using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class AIPlayer : Player
    {
        public override int setPlayMode()
        {
            PlayMode = 2;

            return PlayMode;
        }

        public override string setPlayerName()
        {
            PlayerName = "AI";

            return PlayerName;
        }
    }
}
