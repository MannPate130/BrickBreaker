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

        int paddleWidth = 60;
        int paddleHeight = 10;
        int paddleSpeed = 9;

        int ballX = 300;
        int ballY = 200;
        int ballXspeed = 7;
        int ballYspeed = -7;
        int ballHeight = 10;
        int ballWidth = 10;

        bool leftDown = false;
        bool rightDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);
        Font screenFont = new Font("Consolas", 12);
        Pen pen = new Pen(Color.White);
        SolidBrush redBrush = new SolidBrush(Color.Red);


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
            ballX += ballXspeed;
            ballY += ballYspeed;

            if (leftDown == true && playerPaddlex > 0)
            {
                playerPaddlex -= paddleSpeed;
            }

            if (rightDown == true && playerPaddlex < this.Width - paddleWidth)
            {
                playerPaddlex += paddleSpeed;
            }

            Rectangle playerRec = new Rectangle(playerPaddlex, playerPaddley, paddleWidth, paddleHeight);

            Refresh();
        }

        private void brickBreaker_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(whiteBrush, playerPaddlex, playerPaddley, paddleWidth, paddleHeight);
     
        }
    }
}
