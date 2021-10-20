
namespace MineField_SL
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblNearMines = new System.Windows.Forms.Label();
            this.TimerShow = new System.Windows.Forms.Timer(this.components);
            this.lblShow = new System.Windows.Forms.Label();
            this.TimerOverall = new System.Windows.Forms.Timer(this.components);
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblRestart = new System.Windows.Forms.Label();
            this.TimerTrail = new System.Windows.Forms.Timer(this.components);
            this.lblShowKey = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Location = new System.Drawing.Point(23, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 300);
            this.panel1.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(411, 345);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(25, 29);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "W";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRight.Location = new System.Drawing.Point(442, 380);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(25, 29);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "D";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeft.Location = new System.Drawing.Point(380, 380);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(25, 29);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "A";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(411, 380);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 29);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "S";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(578, 342);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(57, 29);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblNearMines
            // 
            this.lblNearMines.AutoSize = true;
            this.lblNearMines.Font = new System.Drawing.Font("Constantia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNearMines.Location = new System.Drawing.Point(18, 337);
            this.lblNearMines.Name = "lblNearMines";
            this.lblNearMines.Size = new System.Drawing.Size(164, 26);
            this.lblNearMines.TabIndex = 6;
            this.lblNearMines.Text = "Clouds Nearby:";
            // 
            // TimerShow
            // 
            this.TimerShow.Interval = 1000;
            this.TimerShow.Tick += new System.EventHandler(this.TimerShow_Tick);
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.Font = new System.Drawing.Font("Constantia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShow.Location = new System.Drawing.Point(19, 390);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(272, 23);
            this.lblShow.TabIndex = 7;
            this.lblShow.Text = "Showing Clouds for 0 seconds";
            // 
            // TimerOverall
            // 
            this.TimerOverall.Interval = 1000;
            this.TimerOverall.Tick += new System.EventHandler(this.TimerOverall_Tick);
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.Font = new System.Drawing.Font("Constantia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeTaken.Location = new System.Drawing.Point(250, 4);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(147, 23);
            this.lblTimeTaken.TabIndex = 8;
            this.lblTimeTaken.Text = "Time elapsed: 0";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(578, 382);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(57, 29);
            this.btnQuit.TabIndex = 9;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(499, 382);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(65, 29);
            this.btnRestart.TabIndex = 10;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(19, 363);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(243, 19);
            this.lblHint.TabIndex = 11;
            this.lblHint.Text = "Tip: don\'t cross your own path!";
            this.lblHint.Visible = false;
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Font = new System.Drawing.Font("Constantia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestart.Location = new System.Drawing.Point(452, 331);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(112, 18);
            this.lblRestart.TabIndex = 12;
            this.lblRestart.Text = "hit R to restart";
            // 
            // TimerTrail
            // 
            this.TimerTrail.Tick += new System.EventHandler(this.TimerTrail_Tick);
            // 
            // lblShowKey
            // 
            this.lblShowKey.AutoSize = true;
            this.lblShowKey.Font = new System.Drawing.Font("Constantia", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowKey.Location = new System.Drawing.Point(452, 353);
            this.lblShowKey.Name = "lblShowKey";
            this.lblShowKey.Size = new System.Drawing.Size(97, 18);
            this.lblShowKey.TabIndex = 13;
            this.lblShowKey.Text = "hit E to show";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 420);
            this.ControlBox = false;
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.lblShowKey);
            this.Controls.Add(this.lblRestart);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.lblNearMines);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cloudfield";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblNearMines;
        private System.Windows.Forms.Timer TimerShow;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.Timer TimerOverall;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Timer TimerTrail;
        private System.Windows.Forms.Label lblShowKey;
    }
}

