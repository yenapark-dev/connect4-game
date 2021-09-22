using System;
using System.Linq;
using System.Collections;

namespace ConnectFour
{

    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player();
            p.setPlayMode();
            p.setPlayerName();

            GivenSetting.Instance().playMode = p.PlayMode;
            GivenSetting.Instance().player1Name = p.PlayerName;

            // Play with another human
            if (p.PlayMode == 1)
            {
                HumanPlayer player2 = new HumanPlayer();
                GivenSetting.Instance().player2Name = player2.setPlayerName();
                GivenSetting.Instance().player1Name = p.PlayerName;
            }

            // Play with AI (Not implemented)
            else
            {
                AIPlayer ai = new AIPlayer();
                ai.setPlayerName();
                p.setGameLevel();

                GivenSetting.Instance().player2Name = ai.PlayerName;
                GivenSetting.Instance().gameLevel = p.GameLevel;
            }

            // Run game
            Connect4GameReceiver receiver = new Connect4GameReceiver();
            GameCommand cmd = new Connect4GameCommand(receiver);
            GameInvoker game = new GameInvoker();
            game.setCommand(cmd);
            game.start();

        }
    }
}

    