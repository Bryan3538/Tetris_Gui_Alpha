namespace Tetris_Gui_Alpha
{
    partial class TetrisForm
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
            this.tetrisPanel = new System.Windows.Forms.Panel();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveLeftButton = new System.Windows.Forms.Button();
            this.moveRightButton = new System.Windows.Forms.Button();
            this.rotateLeftButton = new System.Windows.Forms.Button();
            this.rotateRightButton = new System.Windows.Forms.Button();
            this.dropDownTimer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tetrisPanel
            // 
            this.tetrisPanel.Location = new System.Drawing.Point(208, 12);
            this.tetrisPanel.Name = "tetrisPanel";
            this.tetrisPanel.Size = new System.Drawing.Size(201, 441);
            this.tetrisPanel.TabIndex = 0;
            this.tetrisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tetrisPanel_Paint);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Location = new System.Drawing.Point(275, 602);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 2;
            this.moveDownButton.Text = "Down";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.Location = new System.Drawing.Point(190, 575);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(75, 23);
            this.moveLeftButton.TabIndex = 3;
            this.moveLeftButton.Text = "Left";
            this.moveLeftButton.UseVisualStyleBackColor = true;
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // moveRightButton
            // 
            this.moveRightButton.Location = new System.Drawing.Point(360, 575);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(75, 23);
            this.moveRightButton.TabIndex = 4;
            this.moveRightButton.Text = "Right";
            this.moveRightButton.UseVisualStyleBackColor = true;
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.Location = new System.Drawing.Point(190, 628);
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(75, 23);
            this.rotateLeftButton.TabIndex = 5;
            this.rotateLeftButton.Text = "Rotate Left";
            this.rotateLeftButton.UseVisualStyleBackColor = true;
            this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeftButton_Click);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.Location = new System.Drawing.Point(360, 628);
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(75, 23);
            this.rotateRightButton.TabIndex = 6;
            this.rotateRightButton.Text = "Rotate Right";
            this.rotateRightButton.UseVisualStyleBackColor = true;
            this.rotateRightButton.Click += new System.EventHandler(this.rotateRightButton_Click);
            // 
            // dropDownTimer
            // 
            this.dropDownTimer.Interval = 500;
            this.dropDownTimer.Tick += new System.EventHandler(this.dropDownTimer_Tick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(230, 673);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(311, 673);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Points: ";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(60, 12);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(13, 13);
            this.pointsLabel.TabIndex = 11;
            this.pointsLabel.Text = "0";
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 708);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.rotateRightButton);
            this.Controls.Add(this.rotateLeftButton);
            this.Controls.Add(this.moveRightButton);
            this.Controls.Add(this.moveLeftButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.tetrisPanel);
            this.KeyPreview = true;
            this.Name = "TetrisForm";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TetrisForm_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tetrisPanel;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveLeftButton;
        private System.Windows.Forms.Button moveRightButton;
        private System.Windows.Forms.Button rotateLeftButton;
        private System.Windows.Forms.Button rotateRightButton;
        private System.Windows.Forms.Timer dropDownTimer;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pointsLabel;
    }
}

