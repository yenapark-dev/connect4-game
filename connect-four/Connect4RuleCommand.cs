using System;
namespace ConnectFour
{
    class Connect4RuleCommand : RuleCommand
    {
        private Connect4RuleReceiver connect4Rule;

        public Connect4RuleCommand(Connect4RuleReceiver connect4Rule)
        {
            this.connect4Rule = connect4Rule;
        }

        public bool gameOver()
        {
            return connect4Rule.hasWon(GivenSetting.Instance().player);//
        }

        public int[] moveAI()
        {
            return connect4Rule.setAIMovementRule(GivenSetting.Instance().gameLevel);//
        }
    }
}
