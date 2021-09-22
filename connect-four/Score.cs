using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Score
    {
        int player1Point = 0;
        int player2Point = 0;

        public void setScore()
        {
            // Calculate the point
            if (Piece.Instance().winner == 1)
            {
                player1Point += 1;
            }
            else
            {
                player2Point += 1;
            }

            // Set the point to the score
            GameState.Instance().score[0, 0] = player1Point;
            GameState.Instance().score[1, 0] = player2Point;
        }

    }
}
