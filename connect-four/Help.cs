using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConnectFour
{
    class Help
    {
        public void printRule()
        {
            WriteLine("Connect 4 is a two player turn based game.");
            WriteLine("Players are represented with a unique signature.");
            WriteLine("Player 1 = 'O',   Player 2 = 'X'");
            WriteLine("The first player to score four signatures in a row is the winner.");
        }

    }
}
