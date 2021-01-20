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
        int playerPaddlex = 200;
        int playerPaddley = 430;
        int playerScore = 0;
        int playerLives = 3;

        int paddleWidth = 60;
        int paddleHeight = 10;
        int paddleSpeed = 9;

        int ballX = 250;
        int ballY = 200;
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

        int brickWidth = 50;
        int brickHeight = 20;

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
                ballX = 250;
                ballY = 200;

                playerPaddlex = 200;
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

            e.Graphics.DrawString($"Score: {playerScore}", screenFont, whiteBrush, 80, 10);

            e.Graphics.DrawString($"Lives: {playerLives}", screenFont, whiteBrush, 320, 10);
        }
    }
}
