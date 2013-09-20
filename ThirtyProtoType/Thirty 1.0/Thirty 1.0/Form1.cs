using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer;
using ModelLayer;

namespace Thirty_1._0
{
    public partial class Form1 : Form
    {
        public GameCtr gameCtr { get; set; }
        public IDictionary<int, Image> DiceImages { get; set; }
        public IDictionary<PictureBox, Dice> DicePicBox{ get; set; }

        public Form1()
        {
            InitializeComponent();
            gameCtr = new GameCtr();
            DiceImages = new Dictionary<int, Image>();
            DicePicBox = new Dictionary<PictureBox, Dice>();
            SetupGame();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            pnlDiceTable.Visible = true;
            lblP1Score.Visible = true;
            lblP2Score.Visible = true;
            textBoxP1Score.Visible = true;
            textBoxP2Score.Visible = true;

            AddPlayer();
            if (gameCtr.PlayersInGame.Count == 2)
            {
                gameCtr.StartGame();

                DiceImages.Add(1, Properties.Resources.Dice1);
                DiceImages.Add(2, Properties.Resources.Dice2);
                DiceImages.Add(3, Properties.Resources.Dice3);
                DiceImages.Add(4, Properties.Resources.Dice4);
                DiceImages.Add(5, Properties.Resources.Dice5);
                DiceImages.Add(6, Properties.Resources.Dice6);
               
                DicePicBox.Add(pictureBoxDice1, gameCtr.DicesInGame[0]);
                DicePicBox.Add(pictureBoxDice2, gameCtr.DicesInGame[1]);
                DicePicBox.Add(pictureBoxDice3, gameCtr.DicesInGame[2]);
                DicePicBox.Add(pictureBoxDice4, gameCtr.DicesInGame[3]);
                DicePicBox.Add(pictureBoxDice5, gameCtr.DicesInGame[4]);
                DicePicBox.Add(pictureBoxDice6, gameCtr.DicesInGame[5]);

                DisplayDices();
                btnStartGame.Dispose();
            }
            else
            {
                textBoxMsg.Text = "error in adding players";
            }

            SetupTurn();

            DiceClickSetup();
        }

        private void SetupGame()
        {
            pictureBoxP1.Image = Properties.Resources.PlayerNo1;
            pictureBoxP2.Image = Properties.Resources.PlayerNo2;
            pictureBoxDiceMat.Image = Properties.Resources.Table;

            pnlDiceTable.Visible = false;
            lblP1Score.Visible = false;
            lblP2Score.Visible = false;
            textBoxP1Score.Visible = false;
            textBoxP2Score.Visible = false;
        }

        private void AddPlayer()
        {
            string nameP1 = textBoxP1Name.Text;
            string nameP2 = textBoxP2Name.Text;

            gameCtr.AddPlayer(nameP1, "Human");
            gameCtr.AddPlayer(nameP2, "Human");

            textBoxP1Name.Enabled = false;
            textBoxP2Name.Enabled = false;
        }

        private void DisplayDices()
        {
            gameCtr.TrowDices();
            foreach(Dice d in gameCtr.DicesInGame)
            {
                if(d.IsActive == true)
                switch (d.Id)
                {
                    case 1:
                        if(d.IsActive == true)
                        pictureBoxDice1.Image = DiceImages[d.Number];
                        break;
                    case 2:
                        pictureBoxDice2.Image = DiceImages[d.Number];
                        break;
                    case 3:
                        pictureBoxDice3.Image = DiceImages[d.Number];
                        break;
                    case 4:
                        pictureBoxDice4.Image = DiceImages[d.Number];
                        break;
                    case 5:
                        pictureBoxDice5.Image = DiceImages[d.Number];
                        break;
                    case 6:
                        pictureBoxDice6.Image = DiceImages[d.Number];
                        break;
                    default: textBoxMsg.Text = "error in diceImage switch";
                        break;
                }
            }
            
        }

        private void RollingTheDices(int dicePic)
        {
          
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            DisplayDices();
        }

        private void SetupTurn()
        {
            int playerTurn = gameCtr.game.Turn;

            switch (playerTurn)
            {
                case 1:
                    panelTurnP1.BackColor = Color.Red;
                    break;
                case 2:
                    panelTurnP2.BackColor = Color.Yellow;
                    break;
                default:
                    textBoxMsg.Text = "error in playerTurn Setup";
                    break;
            }
        }

        private void buttonFinishTurn_Click(object sender, EventArgs e)
        {
            textBoxMsg.Text = "player done";
        }

        private void OnDiceClick(object sender, EventArgs e)
        {
            int tableScore = gameCtr.game.TableScore;

            if (gameCtr.game._gameState == State.thirty)
            {
                //game is in thirty mode
                textBoxMsg.Text = "Thirty mode banking";
            }
            else
            {
                if (tableScore == 30 || tableScore > 30)
                {
                    textBoxMsg.Text = "Finish your Turn";
                }
                else
                {
                    
                    PictureBox picBox = (PictureBox)sender;
                    Dice d = DicePicBox[picBox];

                    tableScore = tableScore + d.Number;
                    gameCtr.game.TableScore = tableScore;
                    textBoxTableScore.Text = tableScore.ToString();
                    
                    d.IsActive = false;
                    picBox.Visible = false;

                } 
            }
        }

        private void DiceClickSetup()
        {
            pictureBoxDice1.Click += OnDiceClick;
            pictureBoxDice2.Click += OnDiceClick;
            pictureBoxDice3.Click += OnDiceClick;
            pictureBoxDice4.Click += OnDiceClick;
            pictureBoxDice5.Click += OnDiceClick;
            pictureBoxDice6.Click += OnDiceClick;
        }
    }
}
