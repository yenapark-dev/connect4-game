using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;
using System.Linq;
using System.Collections;

namespace ConnectFour
{
    class Connect4GameReceiver
    {
        int[] dropChoice = new int[2];
        private int count = 0;
        private int menuChoice = 0;
        //int[] dropChoice = new int[2];

        public void runGame()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Board b = new Board();

            GivenSetting.Instance().player = '1';
            Piece.Instance().currentPlayer = 1;
            int column;
            Connect4RuleReceiver r = new Connect4RuleReceiver();

            bool gameLoop = true;
            bool inputLoop;

            while (gameLoop)
            {

                System.Console.Clear();
                b.drawBoard();

                do
                {
                    inputLoop = true;

                    Help help = new Help();
                    WriteLine("Please press 1 to continue the game. 2 to refresh the game. 3 to end the game. 4 to see the rule. 5 to undo. 6 to redo. >> ");

                    menuChoice = Convert.ToInt32(ReadLine());

                    while (menuChoice != 1 && menuChoice != 2 && menuChoice != 3 && menuChoice != 4 && menuChoice != 5 && menuChoice != 6)
                    {
                        Write("Invalid value -");
                        WriteLine("Number must be between 1 to 6.");
                        menuChoice = Convert.ToInt32(ReadLine());
                    }

                    if (menuChoice == 2) refresh(b);
                    else if (menuChoice == 3) break;
                    else if (menuChoice == 4) help.printRule();
                    //else if (menuChoice == 5) undo(board);
                    //else if (menuChoice == 6) redo(board);

                    Console.WriteLine("Please enter the column number.");
                    Console.Write("\nPlayer ");
                    Console.Write(GivenSetting.Instance().player);
                    Console.Write(": ");

                    if (Int32.TryParse(Console.ReadLine(), out column))
                    {
                        if (1 <= column && column <= 7)
                        {
                            if (dropPiece(GivenSetting.Instance().player, column))
                            {
                                inputLoop = false;
                            }
                            else
                            {
                                System.Console.Clear();
                                b.drawBoard();
                                Console.WriteLine("\nThis column is full.");
                            }
                        }
                        else
                        {
                            System.Console.Clear();
                            b.drawBoard();
                            Console.WriteLine("\nNumber must be between 1 and 7.");
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        b.drawBoard();
                        Console.WriteLine("\nPlease enter an integer.");
                    }
                } while (inputLoop);

                int[] saveDropChoice = setDropChoice();

                saveHistory(Piece.Instance().historyNum, count, saveDropChoice[0], saveDropChoice[1]);
                count++;
                Piece.Instance().historyNum++;

                GameState.Instance().i = saveDropChoice[0];
                GameState.Instance().i = saveDropChoice[1];


                if (r.hasWon(GivenSetting.Instance().player))
                {
                    System.Console.Clear();
                    b.drawBoard();
                    Console.Write("\nPlayer ");
                    Console.Write(GivenSetting.Instance().player);
                    Console.Write(" has won!\n");
                    printScore();
                    Console.WriteLine("\nPress enter to quit.");
                    gameLoop = false;
                }
                else if (r.isBoardFull())
                {
                    System.Console.Clear();
                    b.drawBoard();
                    Console.WriteLine("\nDraw!");
                    Console.WriteLine("\nPress enter to quit.");
                    gameLoop = false;
                }
                else
                {
                    // Change turn
                    if (GivenSetting.Instance().player == '1')
                    {
                        GivenSetting.Instance().player = '2';
                        Piece.Instance().currentPlayer = 2;
                    }
                    else
                    {
                        GivenSetting.Instance().player = '1';
                        Piece.Instance().currentPlayer = 1;
                    }
                   
                }
            }

            Console.ReadKey();

        }

        // Returns true if the piece can be dropped in that column.
        public bool dropPiece(char player, int column)
        {
            column--;

            if (GivenSetting.Instance().state[0, column] != GivenSetting.Instance().EMPTY)
                return false;

            for (int y = 0; y < GivenSetting.BOARD_HEIGHT; y++)
            {
                if ((y == GivenSetting.BOARD_HEIGHT - 1) || (GivenSetting.Instance().state[y + 1, column] != GivenSetting.Instance().EMPTY))
                {
                    GivenSetting.Instance().state[y, column] = player;
                    break;
                }
            }

            GivenSetting.Instance().pieceCnt++;
            return true;
        }

        public void refresh(Board b)
        {

            for (int i = 0; i < GivenSetting.BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < GivenSetting.BOARD_WIDTH; j++)
                {
                    GivenSetting.Instance().state[i, j] = GivenSetting.Instance().EMPTY;
                }
            }
            b.drawBoard();
            Piece.Instance().currentPlayer = 1;
            GivenSetting.Instance().player = '1';
        }

        public void undo(Board board)
        {
            int row = GameState.Instance().redo[0, 1];
            int col = GameState.Instance().redo[0, 2];
            GivenSetting.Instance().state[row, col] = GivenSetting.Instance().EMPTY;
            board.drawBoard();
            runGame();
        }

        public void redo(Board board)
        {
            int row = GameState.Instance().redo[0, 1];
            int col = GameState.Instance().redo[0, 2];
            int dropChoice = GameState.Instance().redo[0, 3];
            GivenSetting.Instance().state[row, col] = GivenSetting.Instance().player;
            board.drawBoard();
            runGame();
        }

        public void saveHistory(int historyNum, int count, int row, int col)
        {
            const char DELIM = ',';
            const string FILENAME = "History.txt";
            string[] fields;
            int lastListNum;

            var lines = File.ReadAllLines(FILENAME);
            if (lines.Count() > 1)
            {
                string lastLine = lines.Last();
                fields = lastLine.Split(DELIM);

                for (int i = 0; i < lines.Count(); i++)
                {
                    if (lines.Contains("NEW GAME"))
                    {
                        if (i == 0)
                        {
                            lastLine = lines[i];

                        }
                        else
                        {
                            lastLine = lines[i - 1];
                        }

                        fields = lastLine.Split(DELIM);
                        break;
                    }
                }

                if (fields.Length == 1)
                {
                    lastListNum = 0;
                }
                else
                {
                    lastListNum = Convert.ToInt32(fields[0]);
                }
                Piece.Instance().historyNum = lastListNum + 1;

            }

            StreamWriter writer = File.AppendText(FILENAME);

            if (count == 0)
            {
                writer.WriteLine("NEW GAME");
            }

            if (Piece.Instance().currentPlayer == 1)
            {
                writer.WriteLine(Piece.Instance().historyNum + "," + GivenSetting.Instance().player1Name + "," + System.DateTime.Now.ToString() + "," + GivenSetting.Instance().playMode + "," + row + "," + col + "," + GivenSetting.Instance().state[row, col] + "," + Piece.Instance().currentPlayer + "," + count);
            }

            else
            {
                writer.WriteLine(Piece.Instance().historyNum + "," + GivenSetting.Instance().player2Name + "," + System.DateTime.Now.ToString() + "," + GivenSetting.Instance().playMode + "," + row + "," + col + "," + GivenSetting.Instance().state[row, col] + "," + Piece.Instance().currentPlayer + "," + count);
            }
            writer.Close();
        }

        //public void loadGame()
        //{
        //    int listNum = GivenSetting.Instance().gameStatus;

        //    //if(GameState.Instance().history[listNum, ])
        //}


        public int[] setDropChoice()
        {
            GameState.Instance().redo[0, 0] = Piece.Instance().currentPlayer;
            GameState.Instance().redo[0, 1] = Piece.Instance().row;
            GameState.Instance().redo[0, 2] = Piece.Instance().col;
            GameState.Instance().redo[0, 3] = GivenSetting.Instance().state[Piece.Instance().row, Piece.Instance().col];

            dropChoice[0] = Piece.Instance().row;
            dropChoice[1] = Piece.Instance().col;

            GameState.Instance().i = dropChoice[0];
            GameState.Instance().j = dropChoice[1];

            return dropChoice;
        }


        public void printScore()
        {
            Score score = new Score();
            score.setScore();
            WriteLine("<Score> \nPlayer1 : Player2");
            WriteLine(GameState.Instance().score[0, 0] + " : " + GameState.Instance().score[1, 0]);
        }
    }
}
