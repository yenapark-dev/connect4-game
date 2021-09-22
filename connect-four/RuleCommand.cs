using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    interface RuleCommand
    {
        public bool gameOver();
        public int[] moveAI();
    }
}
