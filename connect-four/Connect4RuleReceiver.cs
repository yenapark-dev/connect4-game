using System;

namespace ConnectFour
{
    public class Connect4RuleReceiver
    {
        public bool hasWon(char player)
        {
            // Horizontal check

            for (int y = 0; y < GivenSetting.BOARD_HEIGHT; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (GivenSetting.Instance().state[y, x] == player && GivenSetting.Instance().state[y, x + 1] == player
                        && GivenSetting.Instance().state[y, x + 2] == player && GivenSetting.Instance().state[y, x + 3] == player)
                        return true;
                }
            }

            // Vertical check

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < GivenSetting.BOARD_WIDTH; x++)
                {
                    if (GivenSetting.Instance().state[y, x] == player && GivenSetting.Instance().state[y + 1, x] == player
                        && GivenSetting.Instance().state[y + 2, x] == player && GivenSetting.Instance().state[y + 3, x] == player)
                        return true;
                }

            }


            // Diagonal check

            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < GivenSetting.BOARD_WIDTH; x++)
                {

                    if (GivenSetting.Instance().state[y, x] == player)
                    {

                        // Left diagonal
                        try
                        {
                            if (GivenSetting.Instance().state[y + 1, x - 1] == player)
                            {
                                if (GivenSetting.Instance().state[y + 2, x - 2] == player
                                    && GivenSetting.Instance().state[y + 3, x - 3] == player)
                                    return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }

                        // Right diagonal
                        try
                        {
                            if (GivenSetting.Instance().state[y + 1, x + 1] == player)
                            {
                                if (GivenSetting.Instance().state[y + 2, x + 2] == player
                                    && GivenSetting.Instance().state[y + 3, x + 3] == player)
                                    return true;
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
            }

            return false;
        }

        public bool isBoardFull()
        {
            return GivenSetting.Instance().pieceCnt >= GivenSetting.BOARD_HEIGHT * GivenSetting.BOARD_WIDTH;
        }

        public int[] setAIMovementRule(int gameLevel)
        {
            int[] dropChoice = new int[2];

            // Easy strategy
            if (gameLevel == 1)
            {
                Console.WriteLine("AI");
                Random rnd = new Random();

                dropChoice[1] = rnd.Next(1, 7);
                Piece.Instance().col = dropChoice[1];
                return dropChoice;
            }

            // Not implemented, check winning and drop 
            else
            {
                return dropChoice;
            }
        }
    }
}
