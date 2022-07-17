using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment4
{
    /// <summary>
    /// Tic Tac Toe Class
    /// Rules of the game (Checking wins, ties)
    /// </summary>
    public class clsTicTacToe
    {
        #region Attributes
        /// <summary>
        /// Multi string array
        /// </summary>
        public string[,] saGameBoard;
        /// <summary>
        /// Number of wins for player 1 (X's)
        /// </summary>
        public int iplayer1Wins = 0;
        /// <summary>
        /// Number of wins for player 2 (O's)
        /// </summary>
        public int iplayer2Wins = 0;
        /// <summary>
        /// The player going first is player 1. This variable is used to switch players
        /// </summary>
        public int player = 1;
        /// <summary>
        /// Number of ties 
        /// </summary>
        public int iTies = 0;
        /// <summary>
        /// Keeping count of turns to use with ties
        /// </summary>
        public int iNumofTurns = 0;
        /// <summary>
        /// Help store the winning move
        /// </summary>
        private WinningMove eWinMove;

        /// <summary>
        /// The types of wins that can occur
        /// </summary>
        private enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        #endregion


        #region Methods
        /// <summary>
        /// Method used to switch between player 1 and player 2
        /// </summary>
        public void PlayerTurn()
        {
            if (player == 1)
            {
                player++;
            }
            else
            {
                player--;
            }
        }

        /// <summary>
        /// Checks the vertical, horizontal, and diagonal wins
        /// passes in the gameboard and label to help determine the win
        /// Number of turns goes back to 0 if a win occurs
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="myLabel"></param>
        /// <returns></returns>
        public bool isWinMove(string[,] gameBoard, string myLabel)
        {
            if (isVertWin(gameBoard, myLabel))
            {
                iNumofTurns = 0;
                return true;
            }
            else if (isHortWin(gameBoard, myLabel))
            {
                iNumofTurns = 0;
                return true;
            }
            else if (isDiagonalWin(gameBoard, myLabel))
            {
                iNumofTurns = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a Horizontal win happens
        /// goes through each row with a for loop
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="myLabel"></param>
        /// <returns></returns>
        private bool isHortWin(string[,] gameBoard, string myLabel)
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[i, 0] == myLabel && gameBoard[i, 1] == myLabel && gameBoard[i, 2] == myLabel)
                {
                    if (i == 0)
                    {
                        eWinMove = WinningMove.Row1;
                        return true;
                    }
                    else if (i == 1)
                    {
                        eWinMove = WinningMove.Row2;
                        return true;
                    }
                    else if (i == 2)
                    {
                        eWinMove = WinningMove.Row3;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks any vertical wins
        /// The for loop helps go through each columns
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="myLabel"></param>
        /// <returns></returns>
        private bool isVertWin(string[,] gameBoard, string myLabel)
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameBoard[0, i] == myLabel && gameBoard[1, i] == myLabel && gameBoard[2, i] == myLabel)
                {
                    if (i == 0)
                    {
                        eWinMove = WinningMove.Col1;
                        return true;
                    }
                    else if (i == 1)
                    {
                        eWinMove = WinningMove.Col2;

                        return true;
                    }
                    else if (i == 2)
                    {
                        eWinMove = WinningMove.Col3;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Check for a diagonal win
        /// Only 2 checks are needed 
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="myLabel"></param>
        /// <returns></returns>
        private bool isDiagonalWin(string[,] gameBoard, string myLabel)
        {
            if (gameBoard[0, 0] == myLabel && gameBoard[1, 1] == myLabel && gameBoard[2, 2] == myLabel)
            {
                eWinMove = WinningMove.Diag1;
                return true;
            }
            else if (gameBoard[2, 0] == myLabel && gameBoard[1, 1] == myLabel && gameBoard[0, 2] == myLabel)
            {
                eWinMove = WinningMove.Diag2;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Checks if the game ends up in a tie
        /// if the number of turns equals 9 and no winner has been declared than it is a tie
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <returns></returns>
        public bool isTie(string[,] gameBoard)
        {
            iNumofTurns++;
            if (iNumofTurns == 9)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
