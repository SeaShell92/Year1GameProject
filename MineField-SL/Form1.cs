using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace MineField_SL
{
    public partial class Form1 : Form
    {
        //specify size of grid.
        const int rows = 15;
        const int cols = 30;

        //to count how long the trail lingers before disappearing.
        const int trailIncrements = 30;

        //set up count-down time in seconds to show the clouds (for a "quick peek").
        const int ShowDuration = 2;
        int secs = 0;

        //to count the overall time the game has been running.
        int seconds = 0;

        //set start location of sprite and then update it to be the current location of the sprite.
        int atCol = 0;
        int atRow = 14;

        //define an array to store the trail location.
        int[,] trail = new int[rows, cols];

        //define an array of labels for the playing field.
        Label[,] labels = new Label[rows, cols];

        //define an array to store mine locations.
        bool[,] mines = new bool[rows, cols];

        //a place to hold sound effects used in game.
        Dictionary<string, SoundPlayer> sounds = new Dictionary<string, SoundPlayer>();

        public Form1()
        {
            InitializeComponent();
            
            //generates all the labels for the playing field.
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int labelId = j + i * cols;
                    Label label = new Label();

                    label.BackColor = Color.DarkOrchid;
                    label.Location = new Point(j * 20, i * 20);
                    label.Name = "label" + labelId.ToString();
                    label.Size = new Size(20, 20);
                    label.TabIndex = labelId;

                    labels[i, j] = label;
                    this.panel1.Controls.Add(label);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showSpriteAt(atRow, atCol);
            labels[0, cols - 1].Image = Properties.Resources.ingots;
            labels[0, cols - 1].BackColor = Color.LightYellow;
            plantMines(30);
            lblNearMines.Text = "Clouds Nearby: " + mineCheck(atRow, atCol);
            TimerOverall.Start();
            TimerTrail.Start();
            //add sounds to the dictionary of sounds.
            sounds["victory"] = new SoundPlayer(Properties.Resources.victory); 
            sounds["fail"] = new SoundPlayer(Properties.Resources.game_over_voice);
            sounds["move"] = new SoundPlayer(Properties.Resources.wing_flapping);            
        }

        //function to return the Label at a specific Row and Column in the grid.
        private Label getLabel(int atRow, int atCol)
        {
            return labels[atRow, atCol];
        }

        //function to set mines in random locations.
        private void plantMines(int toBeSet)
        {
            Random r = new Random(); //create the random number generator.

            int tryRow, tryCol;
            int setSoFar = 0;

            //clear the mines array.
            Array.Clear(mines, 0, mines.Length);

            //loop to place desired number of mines.
            do
            {
                tryRow = r.Next(0, rows);
                tryCol = r.Next(0, cols);

                //don't place mines in the same location.
                if (mines[tryRow, tryCol] == true)
                    continue;
                //don't place mines on the sprite.
                if (tryRow == atRow && tryCol == atCol)
                    continue;
                //don't place mines above the sprite.
                if (tryRow == rows - 2 && tryCol == 0)
                    continue;
                //don't place mines right of the sprite.
                if (tryRow == rows - 1 && tryCol == 1)
                    continue;
                //don't place mines on the goal.
                if (tryRow == 0 && tryCol == cols - 1)
                    continue;
                //don't place mines left of the goal.
                if (tryRow == 0 && tryCol == cols - 2)
                    continue;
                //don't place mines below the goal.
                if (tryRow == 1 && tryCol == cols - 1)
                    continue;

                mines[tryRow, tryCol] = true;
                setSoFar++;

            } while (setSoFar < toBeSet);

        }

        //functions to set the colour/image of the labels depending on if there is a mine (cloud) there or not.
        private void showMines() => setMineColor(Color.LimeGreen, Properties.Resources.cloudy);
        private void hideMines() => setMineColor(Color.DarkOrchid, null);

        private void setMineColor(Color backColor, Image img)
        {
            Label grabbed;
            for (int atR = 0; atR < rows; atR++)
            {
                for (int atC = 0; atC < cols; atC++)
                {
                    grabbed = getLabel(atR, atC);
                    if (mines[atR, atC])
                    {
                        grabbed.BackColor = backColor;
                        grabbed.Image = img;
                    }
                }
            }
        }

        //function to determine what colour the trail should be as it fades from blue to purple.
        private void trailFade()
        {
            Label grabbed;
            for (int atR = 0; atR < rows; atR++)
            {
                for (int atC = 0; atC < cols; atC++)
                {
                    grabbed = getLabel(atR, atC);
                    if (trail[atR, atC] > 0)
                    {
                        trail[atR, atC] = trail[atR, atC] - 1;

                        Color x = Color.DarkOrchid;
                        Color y = Color.SkyBlue;

                        grabbed.BackColor = Color.FromArgb(
                            (y.R - x.R) * trail[atR, atC] / trailIncrements + x.R,
                            (y.G - x.G) * trail[atR, atC] / trailIncrements + x.G,
                            (y.B - x.B) * trail[atR, atC] / trailIncrements + x.B
                            );
                    }
                }
            }
        }

        //function to check for mines around sprite.
        //not checking the co-ordinates of the mine but checking above/below etc.
        private int mineCheck(int atR, int atC)
        {
            int counted = 0;
            if (atR > 0)
            {
                if (mines[atR - 1, atC]) //check for mines above.
                    counted++;
            }
            if (atR < rows - 1)
            {
                if (mines[atR + 1, atC]) //check for mines below.
                    counted++;
            }
            if (atC > 0)
            {
                if (mines[atR, atC - 1]) //check for mines left.
                    counted++;
            }
            if (atC < cols - 1)
            {
                if (mines[atR, atC + 1]) //check for mines right.
                    counted++;
            }

            return counted;
        }

        //checking conditions to see if it is game over, victory or still playing the game.
        private void amIDead(int atR, int atC)
        {
            if (mines[atR, atC]) //died to mines.
            {
                this.BackColor = Color.OrangeRed;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnShow.Enabled = false;
                TimerShow.Stop();
                TimerOverall.Stop();
                TimerTrail.Stop();
                sounds["fail"].Play();
                showMines();
                lblNearMines.Text = "!! You Hit a Poisonous Cloud :( !!";
            }

            else if (trail[atR, atC] != 0) //died to trail.
            {
                this.BackColor = Color.OrangeRed;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnShow.Enabled = false;
                Label grabbed = getLabel(atRow, atCol);
                grabbed.BackColor = Color.Red;
                TimerShow.Stop();
                TimerOverall.Stop();
                TimerTrail.Stop();
                sounds["fail"].Play();
                showMines();
                lblNearMines.Text = "!! You Crashed :( !!";
                lblHint.Visible = true;
            }

            else if (atRow == 0 && atCol == cols - 1) //got to goal.
            {
                this.BackColor = Color.DarkGoldenrod;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
                btnShow.Enabled = false;
                TimerShow.Stop();
                TimerOverall.Stop();
                TimerTrail.Stop();
                sounds["victory"].Play();
                showMines();
                lblNearMines.Text = "!! You Got The Gold :) !!";
            }
            else //still playing.
            {
                lblNearMines.Text = "Clouds Nearby: " + mineCheck(atRow, atCol);
            }
        }

        //functions to show and hide the sprite at a location.
        private void showSpriteAt(int atRow, int atCol)
        {
            Label grabbed = getLabel(atRow, atCol);         //get the label.
            grabbed.BackColor = Color.LightSkyBlue;         //set the backcolour.
            grabbed.Image = Properties.Resources.flyingdragon; //set the image.
        }

        private void hideSpriteAt(int atRow, int atCol)
        {
            Label grabbed = getLabel(atRow, atCol);      //get the label.
            grabbed.Image = null;                       //remove the image but keep the colour to make a trail.
        }

        //function to check if sprite can move and then move accordingly.
        private void moveTo(int toRow, int toCol)
        {
            if (toRow < 0) return; //these statements stop you moving outside of the playing field.
            if (toRow >= rows) return;
            if (toCol < 0) return;
            if (toCol >= cols) return;
                        
            trail[atRow, atCol] = trailIncrements; //adding a trail to the tile sprite leaves.         
            hideSpriteAt(atRow, atCol); //delete sprite at current location.
            atRow = toRow; //atRow becomes toRow so the sprite knows where to move to.
            atCol = toCol; //move in a direction.
            showSpriteAt(atRow, atCol); //show sprite at new location.
            sounds["move"].Play(); //play the movement sound.
            amIDead(atRow, atCol); //check if dead and play death (or victory) sound after movement sound.
        }
        
        //show the clouds (mines) but only for a set amount of time.        
        private void showMinesTime()
        {
            showMines();
            secs = ShowDuration;
            TimerShow.Start();
            lblShow.Text = "Showing Clouds for " + secs.ToString() + " seconds";
            btnShow.Enabled = false;
        }

        //dispose of the form and create a new one to reset the game.        
        private void reset()
        {
            Form1 NewGame = new Form1();
            NewGame.Show();
            this.Dispose(false);
        }

        //functions to move that can be used by both mouse controls and keyboard controls.
        private void moveUp() => moveTo(atRow - 1, atCol); //move up a row.
        private void moveDown() => moveTo(atRow + 1, atCol); //move down a row.
        private void moveLeft() => moveTo(atRow, atCol - 1); //move over a col (left).
        private void moveRight() => moveTo(atRow, atCol + 1); //move over a col (right).

        //mouse controls.
        private void btnUp_Click(object sender, EventArgs e) => moveUp();
        private void btnDown_Click(object sender, EventArgs e) => moveDown();
        private void btnLeft_Click(object sender, EventArgs e) => moveLeft();
        private void btnRight_Click(object sender, EventArgs e) => moveRight();

        //keyboard controls but sprite can only move if the buttons can be clicked.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnUp.Enabled == true)
            {
                if (e.KeyCode == Keys.W)
                {
                    moveUp();
                }
                if (e.KeyCode == Keys.S)
                {
                    moveDown();
                }
                if (e.KeyCode == Keys.A)
                {
                    moveLeft();
                }
                if (e.KeyCode == Keys.D)
                {
                    moveRight();
                }

                if (e.KeyCode == Keys.E) //press a button to show mines.
                {
                    showMinesTime();
                }
            }

            if (e.KeyCode == Keys.R) //press a button to restart the game.
            {
                reset();
            }

            if (e.KeyCode == Keys.Escape) //press a button to quit.
            {
                Application.Exit();
            }
        }

        //call the function to show mines for a duration.
        private void btnShow_Click(object sender, EventArgs e) => showMinesTime();

        //using "application" to ensure all instances of the form close and not just the newest (reset) one.
        private void btnQuit_Click(object sender, EventArgs e) => Application.Exit();

        //call the function to restart the game.
        private void btnRestart_Click(object sender, EventArgs e) => reset();

        //the amount of time the clouds (mines) can be shown for.
        private void TimerShow_Tick(object sender, EventArgs e)
        {
            secs--;
            lblShow.Text = "Showing Clouds for " + secs.ToString() + " seconds";
            if (secs == 0)
            {
                TimerShow.Stop();
                hideMines();
                btnShow.Enabled = true;
            }
        }

        //a timer for the trail so it fades over time.
        private void TimerTrail_Tick(object sender, EventArgs e) => trailFade();        

        //time to count how long the player has been playing.
        private void TimerOverall_Tick(object sender, EventArgs e)
        {
            seconds++;
            lblTimeTaken.Text = "Time elapsed: " + seconds.ToString();
        }
    }
}

