using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment4
{
    /// <summary>
    /// Tic Tac Toe
    /// The UI of the game
    /// </summary>
    public partial class Form1 : Form
    {
        clsTicTacToe TicTac;
        bool isGameStarted;
        string[,] gameBoard;

        public Form1()
        {
            InitializeComponent();

            TicTac = new clsTicTacToe();
            TicTac.saGameBoard = gameBoard;
            isGameStarted = false;
        }

        /// <summary>
        /// For when the start button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartButton_Click(object sender, EventArgs e)
        {
            LoadBoard(3, 3);
            isGameStarted = true;
            lblPlayer1.Text = "Player 1 Wins: " + TicTac.iplayer1Wins;
            lblPlayer2.Text = "Player 2 Wins: " + TicTac.iplayer2Wins;
            lblTies.Text = " Ties: " + TicTac.iTies;
            GameStatusTB.Text = " Game Has Started! \n Its Player 1 turn";

            //Make sure its player 1 that moves first when the start button is clicked
            if (TicTac.player == 2)
            {
                TicTac.player = 1;
            }
        }

        /// <summary>
        /// When the players click on the board an X or O will be place
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpaceClick(object sender, EventArgs e)
        {
            //If the game hasnt start yet, return to get out of the method
            if (isGameStarted == false)
            {
                return;
            }

            //separating the tags and put it into two different integers
            Label myLabel = (Label)sender;
            string[] tag = myLabel.Tag.ToString().Split(',');
            Int32.TryParse(tag[0], out int row);
            int tag1 = row;
            Int32.TryParse(tag[1], out int col);
            int tag2 = col;

            //If the label is already taken
            if (!String.IsNullOrEmpty(gameBoard[row, col]))
            {
                return;
            }

            //Making sure the X is for player 1 and O is player 2
            if (TicTac.player == 1)
            {
                myLabel.Text = "X";
                GameStatusTB.Text = " Its Player 2 turn";
            }
            else
            {
                myLabel.Text = "O";
                GameStatusTB.Text = " Its Player 1 turn";
            }

            gameBoard[row, col] = myLabel.Text;

            //checks with the vert, hort, col, row, and diag wins
            if (TicTac.isWinMove(gameBoard, myLabel.Text))
            {
                isGameStarted = false;
                HighlightWinMove(gameBoard, myLabel.Text);
                GameStatusTB.Text = "Hooray! Player " + TicTac.player + " Wins!";
                DisplayScores();
            }
            //check with the tie
            else if (TicTac.isTie(gameBoard))
            {
                isGameStarted = false;
                GameStatusTB.Text = "Its a Tie!";
                DisplayScores();
            }
            //if no wins switch the players
            else
            {
                TicTac.PlayerTurn();
            }
        }

        /// <summary>
        /// Load the board to be a 3x3 multi array
        /// calls the clear method to make the board blank
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string[,] LoadBoard(int x, int y)
        {
            gameBoard = new string[x, y];
            clearLabels();
            ResetWinMoves();
            return gameBoard;
        }

        //clearlabels() and reset colors()method
        /// <summary>
        /// Deletes all the X's and O's from the board and set it to blank
        /// </summary>
        private void clearLabels()
        {
            lbl01.Text = "";
            lbl02.Text = "";
            lbl03.Text = "";
            lbl11.Text = "";
            lbl12.Text = "";
            lbl13.Text = "";
            lbl21.Text = "";
            lbl22.Text = "";
            lbl23.Text = "";
        }

        /// <summary>
        /// highlight the winning labels
        /// </summary>
        private void HighlightWinMove(string[,] gameBoard, string myLabel)
        {

        }

        /// <summary>
        /// Updates the scores for wins and ties
        /// </summary>
        private void DisplayScores()
        {
            //if player 1 wins and number of turn is 0 increment player win and display message of win
            if (TicTac.player == 1 && TicTac.iNumofTurns == 0)
            {
                TicTac.iplayer1Wins++;
                lblPlayer1.Text = "Player 1 Wins: " + TicTac.iplayer1Wins;
            }
            //if player 2 wins and number of turn is 0 increment player win and display message of win
            else if (TicTac.player == 2 && TicTac.iNumofTurns == 0)
            {
                TicTac.iplayer2Wins++;
                lblPlayer2.Text = "Player 2 Wins: " + TicTac.iplayer2Wins;
            }
            //if it is a tie, set number of turns to 0 and increment ties
            else
            {
                TicTac.iNumofTurns = 0;
                TicTac.iTies++;
                lblTies.Text = " Ties: " + TicTac.iTies;
            }
        }

        /// <summary>
        /// reset the highlighted labels that were display after the win
        /// </summary>
        private void ResetWinMoves()
        {

        }
    }
}
