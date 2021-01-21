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

namespace BrickBreaker
{
    public partial class brickBreaker : Form
    {
        int playerPaddlex = 130;
        int playerPaddley = 430;
        int playerScore = 0;
        int playerLives = 3;

        int paddleWidth = 60;
        int paddleHeight = 10;
        int paddleSpeed = 9;

        int ballX = 150;
        int ballY = 270;
        int ballXspeed = 7;
        int ballYspeed = -7;
        int ballHeight = 10;
        int ballWidth = 10;

        int redBrickx = 10;
        int redBricky = 100;

        int blueBrickx = 70;
        int blueBricky = 100;

        int greenBrickx = 130;
        int greenBricky = 100;

        int orangeBrickx = 190;
        int orangeBricky = 100;

        int goldBrickx = 250;
        int goldBricky = 100;

        int redBrick2x = 130;
        int redBrick2y = 140;

        int blueBrick2x = 190;
        int blueBrick2y = 140;

        int greenBrick2x = 10;
        int greenBrick2y = 140;

        int orangeBrick2x = 250;
        int orangeBrick2y = 140;

        int goldBrick2x = 70;
        int goldBrick2y = 140;

        int redBrick3x = 250;
        int redBrick3y = 180;

        int blueBrick3x = 10;
        int blueBrick3y = 180;

        int greenBrick3x = 70;
        int greenBrick3y = 180;

        int orangeBrick3x = 130;
        int orangeBrick3y = 180;

        int goldBrick3x = 190;
        int goldBrick3y = 180;

        int redBrick4x = 70;
        int redBrick4y = 220;

        int blueBrick4x = 190;
        int blueBrick4y = 220;

        int greenBrick4x = 250;
        int greenBrick4y = 220;

        int orangeBrick4x = 10;
        int orangeBrick4y = 220;

        int goldBrick4x = 130;
        int goldBrick4y = 220;

        int brickWidth = 50;
        int brickHeight = 30;

        bool leftDown = false;
        bool rightDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Font screenFont = new Font("Consolas", 12);
        Pen pen = new Pen(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);

        SoundPlayer strikerHit = new SoundPlayer(Properties.Resources.PaddleHit);
        SoundPlayer brickBreak = new SoundPlayer(Properties.Resources.BrickBreak);
        SoundPlayer gameOver = new SoundPlayer(Properties.Resources.GameOver);
        SoundPlayer lifeLose = new SoundPlayer(Properties.Resources.LoseLife);

        string gameState = "waiting";

        public brickBreaker()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            titleLabel.Text = "";
            subTitle.Text = "";
            titleLabel.Visible = false;
            subTitle.Visible = false;

            brickBreakertimer.Enabled = true;
            gameState = "running";
            playerLives = 3;
            playerScore = 0;
            ballX = 150;
            ballY = 270;
            ballXspeed = 7;
            ballYspeed = -7;

            playerPaddlex = this.Width / 2 - paddleWidth / 2;
            playerPaddley = 430;
        }

        private void brickBreaker_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true; 
                    break;
                case Keys.Right:
                    rightDown = true; 
                    break;
                case Keys.Enter:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void brickBreaker_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void brickBreakertimer_Tick(object sender, EventArgs e)
        {
            ballX -= ballXspeed;
            ballY -= ballYspeed;

            if (leftDown == true && playerPaddlex > 0)
            {
                playerPaddlex -= paddleSpeed;
            }

            if (rightDown == true && playerPaddlex < this.Width - paddleWidth)
            {
                playerPaddlex += paddleSpeed;
            }

            // Top collision
            if (ballY < 0)
            {
                ballYspeed *= -1;
            }

            // bottom collision
            if (ballY > this.Height - ballHeight)
            {
                lifeLose.Play();
                playerScore--;
                playerLives--;
                ballX = 150;
                ballY = 270;

                playerPaddlex = 130;
                playerPaddley = 430;
            }

            // left and right wall collision
            if (ballX < 0 || ballX > this.Width - ballWidth)
            {
                ballXspeed *= -1;
            }

            Rectangle playerRec = new Rectangle(playerPaddlex, playerPaddley, paddleWidth, paddleHeight);
            Rectangle ballRec = new Rectangle(ballX, ballY, ballWidth, ballHeight);
            Rectangle redRec = new Rectangle(redBrickx, redBricky, brickWidth, brickHeight);
            Rectangle blueRec = new Rectangle(blueBrickx, blueBricky, brickWidth, brickHeight);
            Rectangle greenRec = new Rectangle(greenBrickx, greenBricky, brickWidth, brickHeight);
            Rectangle orangeRec = new Rectangle(orangeBrickx, orangeBricky, brickWidth, brickHeight);
            Rectangle goldRec = new Rectangle(goldBrickx, goldBricky, brickWidth, brickHeight);
            Rectangle red2Rec = new Rectangle(redBrick2x, redBrick2y, brickWidth, brickHeight);
            Rectangle blue2Rec = new Rectangle(blueBrick2x, blueBrick2y, brickWidth, brickHeight);
            Rectangle green2Rec = new Rectangle(greenBrick2x, greenBrick2y, brickWidth, brickHeight);
            Rectangle orange2Rec = new Rectangle(orangeBrick2x, orangeBrick2y, brickWidth, brickHeight);
            Rectangle gold2Rec = new Rectangle(goldBrick2x, goldBrick2y, brickWidth, brickHeight);
            Rectangle red3Rec = new Rectangle(redBrick3x, redBrick3y, brickWidth, brickHeight);
            Rectangle blue3Rec = new Rectangle(blueBrick3x, blueBrick3y, brickWidth, brickHeight);
            Rectangle green3Rec = new Rectangle(greenBrick3x, greenBrick3y, brickWidth, brickHeight);
            Rectangle orange3Rec = new Rectangle(orangeBrick3x, orangeBrick3y, brickWidth, brickHeight);
            Rectangle gold3Rec = new Rectangle(goldBrick3x, goldBrick3y, brickWidth, brickHeight);
            Rectangle red4Rec = new Rectangle(redBrick4x, redBrick4y, brickWidth, brickHeight);
            Rectangle blue4Rec = new Rectangle(blueBrick4x, blueBrick4y, brickWidth, brickHeight);
            Rectangle green4Rec = new Rectangle(greenBrick4x, greenBrick4y, brickWidth, brickHeight);
            Rectangle orange4Rec = new Rectangle(orangeBrick4x, orangeBrick4y, brickWidth, brickHeight);
            Rectangle gold4Rec = new Rectangle(goldBrick4x, goldBrick4y, brickWidth, brickHeight);

            if (playerRec.IntersectsWith(ballRec))
            {
                strikerHit.Play();
                ballYspeed *= -1;
                ballY = playerPaddley - paddleHeight - 1;
            }

            if (ballRec.IntersectsWith(redRec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = redBricky + brickHeight + 1;
                playerScore += 2;

                redBrickx = 10;
                redBricky = -100;
            }
            
            if (ballRec.IntersectsWith(blueRec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = blueBricky + brickHeight + 1;
                playerScore += 2;

                blueBrickx = 10;
                blueBricky = -100;
            }

            if (ballRec.IntersectsWith(greenRec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = greenBricky + brickHeight + 1;
                playerScore += 5;

                greenBrickx = 10;
                greenBricky = -100;
            }

            if (ballRec.IntersectsWith(orangeRec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = orangeBricky + brickHeight + 1;
                playerScore += 5;

                orangeBrickx = 10;
                orangeBricky = -100;
            }

            if (ballRec.IntersectsWith(goldRec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = goldBricky + brickHeight + 1;
                playerScore += 10;

                goldBrickx = 10;
                goldBricky = -100;
            }

            if (ballRec.IntersectsWith(red2Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = redBrick2y + brickHeight + 1;
                playerScore += 2;

                redBrick2x = 10;
                redBrick2y = -100;
            }

            if (ballRec.IntersectsWith(blue2Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = blueBrick2y + brickHeight + 1;
                playerScore += 2;

                blueBrick2x = 10;
                blueBrick2y = -100;
            }

            if (ballRec.IntersectsWith(green2Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = greenBrick2y + brickHeight + 1;
                playerScore += 5;

                greenBrick2x = 10;
                greenBrick2y = -100;
            }

            if (ballRec.IntersectsWith(orange2Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = orangeBrick2y + brickHeight + 1;
                playerScore += 5;

                orangeBrick2x = 10;
                orangeBrick2y = -100;
            }

            if (ballRec.IntersectsWith(gold2Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = goldBrick2y + brickHeight + 1;
                playerScore += 10;

                goldBrick2x = 10;
                goldBrick2y = -100;
            }

            if (ballRec.IntersectsWith(red3Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = redBrick3y + brickHeight + 1;
                playerScore += 2;

                redBrick3x = 10;
                redBrick3y = -100;
            }

            if (ballRec.IntersectsWith(blue3Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = blueBrick3y + brickHeight + 1;
                playerScore += 2;

                blueBrick3x = 10;
                blueBrick3y = -100;
            }

            if (ballRec.IntersectsWith(green3Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = greenBrick3y + brickHeight + 1;
                playerScore += 5;

                greenBrick3x = 10;
                greenBrick3y = -100;
            }

            if (ballRec.IntersectsWith(orange3Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = orangeBrick3y + brickHeight + 1;
                playerScore += 5;

                orangeBrick3x = 10;
                orangeBrick3y = -100;
            }

            if (ballRec.IntersectsWith(gold3Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = goldBrick3y + brickHeight + 1;
                playerScore += 10;

                goldBrick3x = 10;
                goldBrick3y = -100;
            }

            if (ballRec.IntersectsWith(red4Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = redBrick4y + brickHeight + 1;
                playerScore += 2;

                redBrick4x = 10;
                redBrick4y = -100;
            }

            if (ballRec.IntersectsWith(blue4Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = blueBrick4y + brickHeight + 1;
                playerScore += 2;

                blueBrick4x = 10;
                blueBrick4y = -100;
            }

            if (ballRec.IntersectsWith(green4Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = greenBrick4y + brickHeight + 1;
                playerScore += 5;

                greenBrick4x = 10;
                greenBrick4y = -100;
            }

            if (ballRec.IntersectsWith(orange4Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = orangeBrick4y + brickHeight + 1;
                playerScore += 5;

                orangeBrick4x = 10;
                orangeBrick4y = -100;
            }

            if (ballRec.IntersectsWith(gold4Rec))
            {
                brickBreak.Play();
                ballYspeed *= -1;
                ballY = goldBrick4y + brickHeight + 1;
                playerScore += 10;

                goldBrick4x = 10;
                goldBrick4y = -100;
            }

            if (playerScore >= 93)
            {
                brickBreakertimer.Enabled = false;
                gameState = "over";
            }

            // if no lives remain, stop program
            if (playerLives == 0)
            {
                brickBreakertimer.Enabled = false;
                gameState = "over";
            }

            Refresh();
        }

        private void brickBreaker_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                titleLabel.Text = "BRICK BREAKER";
                subTitle.Text = "Press Enter to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                // create paddle 
                e.Graphics.FillRectangle(whiteBrush, playerPaddlex, playerPaddley, paddleWidth, paddleHeight);

                //create ball
                e.Graphics.FillEllipse(whiteBrush, ballX, ballY, ballWidth, ballHeight);

                // show player score 
                e.Graphics.DrawString($"Score: {playerScore}", screenFont, whiteBrush, 10, 10);

                // show amount of lives remaining
                e.Graphics.DrawString($"Lives: {playerLives}", screenFont, whiteBrush, 220, 10);

                // first layer of bricks
                e.Graphics.FillRectangle(redBrush, redBrickx, redBricky, brickWidth, brickHeight);
                e.Graphics.FillRectangle(blueBrush, blueBrickx, blueBricky, brickWidth, brickHeight);
                e.Graphics.FillRectangle(greenBrush, greenBrickx, greenBricky, brickWidth, brickHeight);
                e.Graphics.FillRectangle(orangeBrush, orangeBrickx, orangeBricky, brickWidth, brickHeight);
                e.Graphics.FillRectangle(goldBrush, goldBrickx, goldBricky, brickWidth, brickHeight);

                // second layer of bricks
                e.Graphics.FillRectangle(redBrush, redBrick2x, redBrick2y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(blueBrush, blueBrick2x, blueBrick2y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(greenBrush, greenBrick2x, greenBrick2y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(orangeBrush, orangeBrick2x, orangeBrick2y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(goldBrush, goldBrick2x, goldBrick2y, brickWidth, brickHeight);

                // third layer of bricks
                e.Graphics.FillRectangle(redBrush, redBrick3x, redBrick3y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(blueBrush, blueBrick3x, blueBrick3y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(greenBrush, greenBrick3x, greenBrick3y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(orangeBrush, orangeBrick3x, orangeBrick3y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(goldBrush, goldBrick3x, goldBrick3y, brickWidth, brickHeight);

                // fourth layer of bricks
                e.Graphics.FillRectangle(redBrush, redBrick4x, redBrick4y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(blueBrush, blueBrick4x, blueBrick4y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(greenBrush, greenBrick4x, greenBrick4y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(orangeBrush, orangeBrick4x, orangeBrick4y, brickWidth, brickHeight);
                e.Graphics.FillRectangle(goldBrush, goldBrick4x, goldBrick4y, brickWidth, brickHeight);
            }
            else if (gameState == "over")
            {
                gameOver.Play();
                titleLabel.Visible = true;
                subTitle.Visible = true;
                titleLabel.Text = "GAME OVER! \n Thank You For Playing";

                subTitle.Text = $"Your final score was {playerScore} \n Press The Escape Button to Exit";
            }


        }
    }
}
