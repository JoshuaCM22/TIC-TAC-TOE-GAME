using System;
using System.Collections.Generic;
using static System.Console;

namespace TIC_TAC_TOE_GAME
{

    class Game
    {

        static bool closeRequested = false;
        static bool matchOver = false;
        static bool playerTurn = true;
        static readonly Random random = new Random();
        static char[,] board;
        static int yourScore = 0;
        static int aIScore = 0;
        static char gameStatus = 'N';

        public static void StartNewGame()
        {

            while (!closeRequested)
            {
                board = new char[3, 3]
                {
                { ' ', ' ', ' ', },
                { ' ', ' ', ' ', },
                { ' ', ' ', ' ', },
                };
                matchOver = false;
                while (!matchOver && !closeRequested)
                {
                    if (playerTurn)
                    {
                        #region Player Turn

                        var (row, column) = (0, 0);
                        bool moved = false;
                        while (!moved && !matchOver && !closeRequested)
                        {
                            Clear();
                            RenderBoard();

                            SetCursorPosition(column * 6 + 1, row * 4 + 1);
                            WriteLine("__");

                            switch (ReadKey(true).Key)
                            {
                                case ConsoleKey.UpArrow: row = row <= 0 ? 2 : row - 1; break;
                                case ConsoleKey.DownArrow: row = row >= 2 ? 0 : row + 1; break;
                                case ConsoleKey.LeftArrow: column = column <= 0 ? 2 : column - 1; break;
                                case ConsoleKey.RightArrow: column = column >= 2 ? 0 : column + 1; break;
                                case ConsoleKey.Enter:
                                    if (board[row, column] != ' ')
                                    {
                                        break;
                                    }
                                    board[row, column] = 'X';
                                    moved = true;
                                    break;
                                case ConsoleKey.Escape:
                                    Clear();
                                    closeRequested = true;
                                    break;
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        #region Computer Move

                        var possibleMoves = new List<(int X, int Y)>();
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (board[i, j] == ' ')
                                {
                                    possibleMoves.Add((i, j));
                                }
                            }
                        }
                        int index = random.Next(0, possibleMoves.Count);
                        var (X, Y) = possibleMoves[index];
                        board[X, Y] = 'O';

                        #endregion
                    }
                    playerTurn = !playerTurn;

                    #region Check Board State

                    if (CheckForThree('X'))
                    {
                        Clear();
                        gameStatus = 'W';
                        RenderBoard();
                        WriteLine();
                        yourScore++;
                        matchOver = true;
                    }
                    else if (CheckForThree('O'))
                    {
                        Clear();
                        gameStatus = 'L';
                        RenderBoard();
                        WriteLine();
                        aIScore++;
                        matchOver = true;
                    }
                    else if (CheckForFullBoard())
                    {
                        Clear();
                        gameStatus = 'D';
                        RenderBoard();
                        WriteLine();
                        matchOver = true;
                    }

                    #endregion
                }

                #region Play Again Check

                if (!closeRequested)
                {
                    Clear();
                    RenderBoard();
                    WriteLine();
                    WriteLine("Press ENTER to play again or ESC to exit the game");
                GetInput:
                    switch (ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            gameStatus = 'N';
                            break;
                        case ConsoleKey.Escape:
                            closeRequested = true;
                            Clear();
                            ForegroundColor = ConsoleColor.White;
                            break;
                        default: goto GetInput;
                    }
                }

                #endregion
            }
        }

        static bool CheckForThree(char c) =>
            board[0, 0] == c && board[1, 0] == c && board[2, 0] == c ||
            board[0, 1] == c && board[1, 1] == c && board[2, 1] == c ||
            board[0, 2] == c && board[1, 2] == c && board[2, 2] == c ||
            board[0, 0] == c && board[0, 1] == c && board[0, 2] == c ||
            board[1, 0] == c && board[1, 1] == c && board[1, 2] == c ||
            board[2, 0] == c && board[2, 1] == c && board[2, 2] == c ||
            board[0, 0] == c && board[1, 1] == c && board[2, 2] == c ||
            board[2, 0] == c && board[1, 1] == c && board[0, 2] == c;

        static bool CheckForFullBoard() =>
            board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' &&
            board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ' &&
            board[0, 2] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ';

        static void RenderBoard()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine();
            WriteLine($" {board[0, 0]}  ║  {board[0, 1]}   ║  {board[0, 2]}");
            WriteLine("    ║      ║");
            WriteLine("════╬══════╬════");
            WriteLine("    ║      ║");
            WriteLine($" {board[1, 0]}  ║  {board[1, 1]}   ║  {board[1, 2]}");
            WriteLine("    ║      ║");
            WriteLine("════╬══════╬════");
            WriteLine("    ║      ║");
            WriteLine($" {board[2, 0]}  ║  {board[2, 1]}   ║  {board[2, 2]}");

            ForegroundColor = ConsoleColor.White;
            WriteLine("Choose a valid position and press ENTER.");
            WriteLine();
            WriteLine();
            WriteLine("YOU = X vs AI = O");
            WriteLine();
            ShowScores();
            WriteLine();

            if (gameStatus != 'N')
            {
                ShowResult();
            }

        }

        static void ShowScores()
        {
            WriteLine("SCORE = " + yourScore + "  SCORE = " + aIScore);
        }

        static void ShowResult()
        {

            if (gameStatus == 'W')
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("RESULT: YOU WIN");
            }

            else if (gameStatus == 'L')
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("RESULT: YOU LOSE");
            }

            else if (gameStatus == 'D')
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("RESULT: DRAW");

            }

        }
    }
}