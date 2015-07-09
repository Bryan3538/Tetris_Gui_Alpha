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
            this.previewShapePanel = new System.Windows.Forms.Panel();
            this.nextShapeLabel = new System.Windows.Forms.Label();
            this.previewShapePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tetrisPanel
            // 
            this.tetrisPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tetrisPanel.Location = new System.Drawing.Point(208, 12);
            this.tetrisPanel.Name = "tetrisPanel";
            this.tetrisPanel.Size = new System.Drawing.Size(201, 441);
            this.tetrisPanel.TabIndex = 0;
            this.tetrisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tetrisPanel_Paint);
            // 
            // moveDownButton
            // 
            this.moveDownButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.moveDownButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.moveDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveDownButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.moveDownButton.Location = new System.Drawing.Point(275, 602);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(75, 23);
            this.moveDownButton.TabIndex = 2;
            this.moveDownButton.Text = "Down";
            this.moveDownButton.UseVisualStyleBackColor = false;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.moveLeftButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.moveLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveLeftButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.moveLeftButton.Location = new System.Drawing.Point(190, 575);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(75, 23);
            this.moveLeftButton.TabIndex = 3;
            this.moveLeftButton.Text = "Left";
            this.moveLeftButton.UseVisualStyleBackColor = false;
            this.moveLeftButton.Click += new System.EventHandler(this.moveLeftButton_Click);
            // 
            // moveRightButton
            // 
            this.moveRightButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.moveRightButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.moveRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveRightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.moveRightButton.Location = new System.Drawing.Point(360, 575);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(75, 23);
            this.moveRightButton.TabIndex = 4;
            this.moveRightButton.Text = "Right";
            this.moveRightButton.UseVisualStyleBackColor = false;
            this.moveRightButton.Click += new System.EventHandler(this.moveRightButton_Click);
            // 
            // rotateLeftButton
            // 
            this.rotateLeftButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.rotateLeftButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rotateLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotateLeftButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rotateLeftButton.Location = new System.Drawing.Point(190, 628);
            this.rotateLeftButton.Name = "rotateLeftButton";
            this.rotateLeftButton.Size = new System.Drawing.Size(75, 23);
            this.rotateLeftButton.TabIndex = 5;
            this.rotateLeftButton.Text = "Rotate Left";
            this.rotateLeftButton.UseVisualStyleBackColor = false;
            this.rotateLeftButton.Click += new System.EventHandler(this.rotateLeftButton_Click);
            // 
            // rotateRightButton
            // 
            this.rotateRightButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.rotateRightButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.rotateRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rotateRightButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rotateRightButton.Location = new System.Drawing.Point(360, 628);
            this.rotateRightButton.Name = "rotateRightButton";
            this.rotateRightButton.Size = new System.Drawing.Size(75, 23);
            this.rotateRightButton.TabIndex = 6;
            this.rotateRightButton.Text = "Rotate Right";
            this.rotateRightButton.UseVisualStyleBackColor = false;
            this.rotateRightButton.Click += new System.EventHandler(this.rotateRightButton_Click);
            // 
            // dropDownTimer
            // 
            this.dropDownTimer.Interval = 500;
            this.dropDownTimer.Tick += new System.EventHandler(this.dropDownTimer_Tick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(230, 673);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(311, 673);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tele-Marines", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Points: ";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Tele-Marines", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.pointsLabel.Location = new System.Drawing.Point(60, 30);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(19, 12);
            this.pointsLabel.TabIndex = 11;
            this.pointsLabel.Text = "0";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewShapePanel
            // 
            this.previewShapePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewShapePanel.Controls.Add(this.nextShapeLabel);
            this.previewShapePanel.Location = new System.Drawing.Point(15, 66);
            this.previewShapePanel.Name = "previewShapePanel";
            this.previewShapePanel.Size = new System.Drawing.Size(143, 161);
            this.previewShapePanel.TabIndex = 12;
            this.previewShapePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewShapePanel_Paint);
            // 
            // nextShapeLabel
            // 
            this.nextShapeLabel.AutoSize = true;
            this.nextShapeLabel.Font = new System.Drawing.Font("Tele-Marines", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextShapeLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.nextShapeLabel.Location = new System.Drawing.Point(1, 4);
            this.nextShapeLabel.Name = "nextShapeLabel";
            this.nextShapeLabel.Size = new System.Drawing.Size(139, 12);
            this.nextShapeLabel.TabIndex = 13;
            this.nextShapeLabel.Text = "Next Shape";
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(617, 709);
            this.Controls.Add(this.previewShapePanel);
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
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "TetrisForm";
            this.Text = "Definitely Not Tetris";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TetrisForm_KeyPress);
            this.previewShapePanel.ResumeLayout(false);
            this.previewShapePanel.PerformLayout();
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
        private System.Windows.Forms.Panel previewShapePanel;
        private System.Windows.Forms.Label nextShapeLabel;
    }
}

