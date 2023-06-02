using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//main
namespace Car_Racing_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        int roadSpeed;                           // Variable to store the speed of the road
        int trafficSpeed;                        // Variable to store the speed of the AI-controlled cars
        int playerSpeed = 12;                    // Variable to store the speed of the player's car
        int score;                               // Variable to store the player's score
        int carImage;                            // Variable to store the image index for AI-controlled cars

        Random rand = new Random();              // Random object to generate random values
        Random carPosition = new Random();       // Random object to generate random car positions

        bool goleft, goright;                    // Flags to track if the player is moving left or right


        private Thread playerThread;
        private Thread car1Thread;
        private Thread car2Thread;


        public Form1()
        {
            InitializeComponent();
            ResetGame();                         // Call the method to reset the game state
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;                   // Set the goleft flag to true when the left arrow key is pressed
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;                  // Set the goright flag to true when the right arrow key is pressed
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;                  // Set the goleft flag to false when the left arrow key is released
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;                 // Set the goright flag to false when the right arrow key is released
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
           
           

            Invoke((MethodInvoker)delegate
            {
                txtScore.Text = "Score: " + score;
            });

            
            score++;                             // Increment the score

            if (goleft && player.Left > 10)
            {
                player.Invoke((MethodInvoker)delegate
                {
                    player.Left -= playerSpeed;
                });
            }
            if (goright && player.Left < 415)
            {
                player.Invoke((MethodInvoker)delegate
                {
                    player.Left += playerSpeed;
                });
            }

            roadTrack1.Invoke((MethodInvoker)delegate
            {
                roadTrack1.Top += roadSpeed;
            });

            roadTrack2.Invoke((MethodInvoker)delegate
            {
                roadTrack2.Top += roadSpeed;
            });

            if (roadTrack2.Top > 519)
            {
                roadTrack2.Invoke((MethodInvoker)delegate
                {
                    roadTrack2.Top = -519;
                });
            }
            if (roadTrack1.Top > 519)
            {
                roadTrack1.Invoke((MethodInvoker)delegate
                {
                    roadTrack1.Top = -519;
                });
            }

            Car1.Invoke((MethodInvoker)delegate
            {
                Car1.Top += trafficSpeed;
            });

            Car2.Invoke((MethodInvoker)delegate
            {
                Car2.Top += trafficSpeed;
            });

            if (Car1.Top > 530)
            {
                changeAIcars(Car1);
            }

            if (Car2.Top > 530)
            {
                changeAIcars(Car2);
            }

            if (player.Bounds.IntersectsWith(Car1.Bounds) || player.Bounds.IntersectsWith(Car2.Bounds))
            {
                gameOver();
            }

            if (score > 40 && score < 500)
            {
                award.Image = Properties.Resources.bronze;   // Set the award image to bronze if the score is between 40 and 500
            }

            if (score > 500 && score < 2000)
            {
                award.Image = Properties.Resources.silver;   // Set the award image to silver if the score is between 500 and 2000
                roadSpeed = 20;                              // Increase the road speed
                trafficSpeed = 22;                           // Increase the AI-controlled car speed
            }

            if (score > 2000)
            {
                award.Image = Properties.Resources.gold;     // Set the award image to gold if the score is above 2000
                trafficSpeed = 27;                           // Increase the AI-controlled car speed
                roadSpeed = 25;                              // Increase the road speed
            }
        }

        private void changeAIcars(PictureBox tempCar)
        {
            int carImageIndex = rand.Next(1, 9);

            Image carImage = null;

            switch (carImageIndex)
            {
                case 1:
                    carImage = Properties.Resources.ambulance;
                    break;
                case 2:
                    carImage = Properties.Resources.carGreen;
                    break;
                case 3:
                    carImage = Properties.Resources.carGrey;
                    break;
                case 4:
                    carImage = Properties.Resources.carOrange;
                    break;
                case 5:
                    carImage = Properties.Resources.carPink;
                    break;
                case 6:
                    carImage = Properties.Resources.CarRed;
                    break;
                case 7:
                    carImage = Properties.Resources.carYellow;
                    break;
                case 8:
                    carImage = Properties.Resources.TruckBlue;
                    break;
                case 9:
                    carImage = Properties.Resources.TruckWhite;
                    break;
            }

            int carPositionTop = carPosition.Next(100, 400) * -1;
            int carPositionLeft = 0;

            if ((string)tempCar.Tag == "carLeft")
            {
                carPositionLeft = carPosition.Next(5, 200);
            }
            else if ((string)tempCar.Tag == "carRight")
            {
                carPositionLeft = carPosition.Next(245, 422);
            }

            tempCar.Invoke((MethodInvoker)delegate
            {
                tempCar.Image = carImage;
                tempCar.Top = carPositionTop;
                tempCar.Left = carPositionLeft;
            });
        }
        private void gameOver()
        {
            playSound();                                           // Call the method to play a crash sound effect
            gameTimer.Stop();                                      // Stop the game timer
            explosion.Visible = true;                              // Show the explosion animation
            player.Controls.Add(explosion);                        // Add the explosion animation as a child control of the player's car
            explosion.Location = new Point(-8, 5);                 // Set the position of the explosion animation
            explosion.BackColor = Color.Transparent;               // Set the background color of the explosion animation to transparent

            award.Visible = true;                                  // Show the award image
            award.BringToFront();                                  // Bring the award image to the front

            btnStart.Enabled = true;                               // Enable the restart button
        }

        private void ResetGame()
        {
            btnStart.Enabled = false;                              // Disable the restart button
            explosion.Visible = false;                             // Hide the explosion animation
            award.Visible = false;                                 // Hide the award image
            goleft = false;                                        // Reset the goleft flag
            goright = false;                                       // Reset the goright flag
            score = 0;                                             // Reset the score
            award.Image = Properties.Resources.bronze;             // Set the award image to bronze

            roadSpeed = 12;                                        // Set the road speed
            trafficSpeed = 15;                                     // Set the AI-controlled car speed

            Car1.Top = carPosition.Next(200, 500) * -1;              // Set the initial position of the first AI-controlled car
            Car1.Left = carPosition.Next(5, 200);                    // Set the initial position of the first AI-controlled car

            Car2.Top = carPosition.Next(200, 500) * -1;              // Set the initial position of the second AI-controlled car
            Car2.Left = carPosition.Next(245, 422);                  // Set the initial position of the second AI-controlled car

            // Start the car threads
            car1Thread = new Thread(() => changeAIcars(Car1));
            car1Thread.Start();
            car2Thread = new Thread(() => changeAIcars(Car2));
            car2Thread.Start();


            gameTimer.Start();                                     // Start the game timer
        }

        private void restartGame(object sender, EventArgs e)
        {
            ResetGame();                                            // Call the method to reset the game state
        }

        private void roadTrack2_Click(object sender, EventArgs e)
        {

        }

        private void AI1_Click(object sender, EventArgs e)
        {

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void playSound()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            playCrash.Play();                                      // Play the crash sound effect
        }
    }
}
