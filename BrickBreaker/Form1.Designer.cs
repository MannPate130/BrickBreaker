
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.subTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // brickBreakertimer
            // 
            this.brickBreakertimer.Enabled = true;
            this.brickBreakertimer.Interval = 20;
            this.brickBreakertimer.Tick += new System.EventHandler(this.brickBreakertimer_Tick);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.titleLabel.Location = new System.Drawing.Point(36, 187);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(400, 83);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "label1";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subTitle
            // 
            this.subTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subTitle.ForeColor = System.Drawing.Color.Aqua;
            this.subTitle.Location = new System.Drawing.Point(38, 298);
            this.subTitle.Name = "subTitle";
            this.subTitle.Size = new System.Drawing.Size(393, 101);
            this.subTitle.TabIndex = 1;
            this.subTitle.Text = "label1";
            this.subTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // brickBreaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(470, 684);
            this.Controls.Add(this.subTitle);
            this.Controls.Add(this.titleLabel);
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
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label subTitle;
    }
}

