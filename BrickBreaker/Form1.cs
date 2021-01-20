using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        int ballX = 160;
        int ballY = 260;
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


        public brickBreaker()
        {
            InitializeComponent();
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

            // Top wall collision
            if (ballY < 0)
            {
                ballYspeed *= -1;

            }

            if (ballY > this.Height - ballHeight)
            {
                playerScore--;
                playerLives--;
                ballX = 160;
                ballY = 260;

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

            if (playerRec.IntersectsWith(ballRec))
            {
                ballYspeed *= -1;
                ballY = playerPaddley - paddleHeight - 1;
            }

            if (ballRec.IntersectsWith(redRec))
            {
                ballYspeed *= -1;
                ballY = redBricky + brickHeight + 1;
            }
            
            if (ballRec.IntersectsWith(blueRec))
            {
                ballYspeed *= -1;
                ballY = blueBricky + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(greenRec))
            {
                ballYspeed *= -1;
                ballY = greenBricky + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(orangeRec))
            {
                ballYspeed *= -1;
                ballY = orangeBricky + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(goldRec))
            {
                ballYspeed *= -1;
                ballY = goldBricky + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(red2Rec))
            {
                ballYspeed *= -1;
                ballY = redBrick2y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(blue2Rec))
            {
                ballYspeed *= -1;
                ballY = blueBrick2y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(green2Rec))
            {
                ballYspeed *= -1;
                ballY = greenBrick2y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(orange2Rec))
            {
                ballYspeed *= -1;
                ballY = orangeBrick2y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(gold2Rec))
            {
                ballYspeed *= -1;
                ballY = goldBrick2y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(red3Rec))
            {
                ballYspeed *= -1;
                ballY = redBrick3y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(blue3Rec))
            {
                ballYspeed *= -1;
                ballY = blueBrick3y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(green3Rec))
            {
                ballYspeed *= -1;
                ballY = greenBrick3y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(orange3Rec))
            {
                ballYspeed *= -1;
                ballY = orangeBrick3y + brickHeight + 1;
            }

            if (ballRec.IntersectsWith(gold3Rec))
            {
                ballYspeed *= -1;
                ballY = goldBrick3y + brickHeight + 1;
            }


            if (playerLives == 0)
            {
                brickBreakertimer.Enabled = false;
            }

            Refresh();
        }

        private void brickBreaker_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, playerPaddlex, playerPaddley, paddleWidth, paddleHeight);

            e.Graphics.FillRectangle(redBrush, redBrickx, redBricky, brickWidth, brickHeight);

            e.Graphics.FillRectangle(blueBrush, blueBrickx, blueBricky, brickWidth, brickHeight);

            e.Graphics.FillRectangle(greenBrush, greenBrickx, greenBricky, brickWidth, brickHeight);

            e.Graphics.FillRectangle(orangeBrush, orangeBrickx, orangeBricky, brickWidth, brickHeight);

            e.Graphics.FillRectangle(goldBrush, goldBrickx, goldBricky, brickWidth, brickHeight);

            e.Graphics.FillEllipse(whiteBrush, ballX, ballY, ballWidth, ballHeight);

            e.Graphics.DrawString($"Score: {playerScore}", screenFont, whiteBrush, 10, 10);

            e.Graphics.DrawString($"Lives: {playerLives}", screenFont, whiteBrush, 220, 10);

            e.Graphics.FillRectangle(redBrush, redBrick2x, redBrick2y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(blueBrush, blueBrick2x, blueBrick2y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(greenBrush, greenBrick2x, greenBrick2y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(orangeBrush, orangeBrick2x, orangeBrick2y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(goldBrush, goldBrick2x, goldBrick2y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(redBrush, redBrick3x, redBrick3y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(blueBrush, blueBrick3x, blueBrick3y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(greenBrush, greenBrick3x, greenBrick3y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(orangeBrush, orangeBrick3x, orangeBrick3y, brickWidth, brickHeight);

            e.Graphics.FillRectangle(goldBrush, goldBrick3x, goldBrick3y, brickWidth, brickHeight);
        }
    }
}
