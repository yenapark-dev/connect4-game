using System;
namespace ConnectFour
{
    class RuleInvoker
    {
        private RuleCommand command;

        public void setCommand(RuleCommand command)
        {
            this.command = command;
        }

        public bool checkGameOver()
        {
            return command.gameOver();
        }

        public int[] moveAI()
        {
            return command.moveAI();
        }
    }
}
