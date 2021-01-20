
namespace BrickBreaker
{
    partial class brickBreaker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.brickBreakertimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // brickBreakertimer
            // 
            this.brickBreakertimer.Enabled = true;
            this.brickBreakertimer.Interval = 20;
            this.brickBreakertimer.Tick += new System.EventHandler(this.brickBreakertimer_Tick);
            // 
            // brickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(698, 684);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "brickBreaker";
            this.Text = "BrickBreaker";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.brickBreaker_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.brickBreaker_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.brickBreaker_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer brickBreakertimer;
    }
}

