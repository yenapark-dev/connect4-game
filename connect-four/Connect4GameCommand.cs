using System;
namespace ConnectFour
{
    class Connect4GameCommand : GameCommand
    {
        private Connect4GameReceiver connect4Game;

        public Connect4GameCommand(Connect4GameReceiver connect4Game)
        {
            this.connect4Game = connect4Game;
        }

        public void execute()
        {
            Board board = new Board();
            connect4Game.runGame();
        }

        public void load()
        {
            //connect4Game.loadGame();
        }
    }
}
