using System;
using System.Linq;
using System.Collections;

namespace ConnectFour
{
    public class Board
    {
        public Board()
        {
            GivenSetting.Instance().state = new char[GivenSetting.BOARD_HEIGHT, GivenSetting.BOARD_WIDTH];

            for (int y = 0; y < GivenSetting.BOARD_HEIGHT; y++)
                for (int x = 0; x < GivenSetting.BOARD_WIDTH; x++)
                    GivenSetting.Instance().state[y, x] = GivenSetting.Instance().EMPTY;
        }

        public void drawBoard()
        {
            var header = $"┌{string.Join("", Enumerable.Repeat("──┬", GivenSetting.BOARD_WIDTH - 1))}──┐";
            var middle = $"├{string.Join("", Enumerable.Repeat("──┼", GivenSetting.BOARD_WIDTH - 1))}──┤";
            var footer = $"└{string.Join("", Enumerable.Repeat("──┴", GivenSetting.BOARD_WIDTH - 1))}──┘";

            // First line
            Console.WriteLine(header);
            for (int y = 0; y < GivenSetting.BOARD_HEIGHT; y++)
            {
                for (int x = 0; x < GivenSetting.BOARD_WIDTH; x++)
                {
                    // Middle line, draw piece if it's not empty
                    Console.Write("│{0} ", GivenSetting.Instance().state[y, x]);
                }

                // Draw line to complete the board if it's empty
                Console.WriteLine("│");
                if (y < GivenSetting.BOARD_HEIGHT - 1)
                    Console.WriteLine(middle);
            }
            Console.WriteLine(footer);

        }
    }
}