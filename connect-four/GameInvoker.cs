using System;
namespace ConnectFour
{
    class GameInvoker
    {
        private GameCommand command;

        public void setCommand(GameCommand command)
        {
            this.command = command;
        }

        public void start()
        {
            command.execute();
        }

        public void load()
        {
            command.load();
        }
    }
}
