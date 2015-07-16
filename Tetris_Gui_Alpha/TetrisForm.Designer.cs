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
            this.dropDownTimer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.previewShapePanel = new System.Windows.Forms.Panel();
            this.nextShapeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.previewShapePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tetrisPanel
            // 
            this.tetrisPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tetrisPanel.Location = new System.Drawing.Point(12, 12);
            this.tetrisPanel.Name = "tetrisPanel";
            this.tetrisPanel.Size = new System.Drawing.Size(281, 617);
            this.tetrisPanel.TabIndex = 0;
            this.tetrisPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tetrisPanel_Paint);
            // 
            // dropDownTimer
            // 
            this.dropDownTimer.Interval = 750;
            this.dropDownTimer.Tick += new System.EventHandler(this.dropDownTimer_Tick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(12, 635);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(124, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.stopButton.Enabled = false;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(169, 635);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(124, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pointsLabel
            // 
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pointsLabel.Location = new System.Drawing.Point(4, 32);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(186, 32);
            this.pointsLabel.TabIndex = 11;
            this.pointsLabel.Text = "0";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // previewShapePanel
            // 
            this.previewShapePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewShapePanel.Controls.Add(this.nextShapeLabel);
            this.previewShapePanel.Location = new System.Drawing.Point(322, 396);
            this.previewShapePanel.Name = "previewShapePanel";
            this.previewShapePanel.Size = new System.Drawing.Size(143, 161);
            this.previewShapePanel.TabIndex = 12;
            this.previewShapePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.previewShapePanel_Paint);
            // 
            // nextShapeLabel
            // 
            this.nextShapeLabel.AutoSize = true;
            this.nextShapeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextShapeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nextShapeLabel.Location = new System.Drawing.Point(11, 0);
            this.nextShapeLabel.Name = "nextShapeLabel";
            this.nextShapeLabel.Size = new System.Drawing.Size(119, 24);
            this.nextShapeLabel.TabIndex = 13;
            this.nextShapeLabel.Text = "Next Shape";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.levelLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(322, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 83);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Level";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.linesLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(322, 244);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 83);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lines";
            // 
            // levelLabel
            // 
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.Location = new System.Drawing.Point(17, 32);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(109, 32);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "0";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linesLabel
            // 
            this.linesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linesLabel.Location = new System.Drawing.Point(17, 32);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(109, 32);
            this.linesLabel.TabIndex = 1;
            this.linesLabel.Text = "0";
            this.linesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.pointsLabel);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(299, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 83);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Points";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(439, 645);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Controls...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Tetris_Gui_Alpha.Properties.Resources.tetris_wallpaper_pattern_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 667);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.previewShapePanel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.tetrisPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "TetrisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Definitely Not Tetris";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TetrisForm_KeyPress);
            this.previewShapePanel.ResumeLayout(false);
            this.previewShapePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel tetrisPanel;
        private System.Windows.Forms.Timer dropDownTimer;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Panel previewShapePanel;
        private System.Windows.Forms.Label nextShapeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

