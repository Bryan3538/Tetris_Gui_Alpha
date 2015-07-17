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
            this.levelLabel = new System.Windows.Forms.Label();
            this.linesLabel = new System.Windows.Forms.Label();
            this.controlsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pointsPanel = new System.Windows.Forms.Panel();
            this.pointsDescriptionLabel = new System.Windows.Forms.Label();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.levelDescriptionLabel = new System.Windows.Forms.Label();
            this.linesPanel = new System.Windows.Forms.Panel();
            this.linesDescriptionLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.muteCheckBox = new System.Windows.Forms.CheckBox();
            this.previewShapePanel.SuspendLayout();
            this.pointsPanel.SuspendLayout();
            this.levelPanel.SuspendLayout();
            this.linesPanel.SuspendLayout();
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
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Location = new System.Drawing.Point(12, 635);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(87, 23);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.stopButton.Enabled = false;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Location = new System.Drawing.Point(206, 635);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 23);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // pointsLabel
            // 
            this.pointsLabel.BackColor = System.Drawing.Color.Transparent;
            this.pointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pointsLabel.Location = new System.Drawing.Point(4, 32);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(186, 32);
            this.pointsLabel.TabIndex = 11;
            this.pointsLabel.Text = "0";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewShapePanel
            // 
            this.previewShapePanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.nextShapeLabel.BackColor = System.Drawing.Color.Transparent;
            this.nextShapeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextShapeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.nextShapeLabel.Location = new System.Drawing.Point(11, 0);
            this.nextShapeLabel.Name = "nextShapeLabel";
            this.nextShapeLabel.Size = new System.Drawing.Size(119, 24);
            this.nextShapeLabel.TabIndex = 13;
            this.nextShapeLabel.Text = "Next Shape";
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.levelLabel.Location = new System.Drawing.Point(4, 32);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(136, 32);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "0";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linesLabel
            // 
            this.linesLabel.BackColor = System.Drawing.Color.Transparent;
            this.linesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linesLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.linesLabel.Location = new System.Drawing.Point(4, 32);
            this.linesLabel.Name = "linesLabel";
            this.linesLabel.Size = new System.Drawing.Size(136, 32);
            this.linesLabel.TabIndex = 1;
            this.linesLabel.Text = "0";
            this.linesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controlsLinkLabel
            // 
            this.controlsLinkLabel.AutoSize = true;
            this.controlsLinkLabel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.controlsLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlsLinkLabel.Location = new System.Drawing.Point(418, 638);
            this.controlsLinkLabel.Name = "controlsLinkLabel";
            this.controlsLinkLabel.Size = new System.Drawing.Size(83, 17);
            this.controlsLinkLabel.TabIndex = 16;
            this.controlsLinkLabel.TabStop = true;
            this.controlsLinkLabel.Text = "Controls...";
            this.controlsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pointsPanel
            // 
            this.pointsPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pointsPanel.Controls.Add(this.pointsDescriptionLabel);
            this.pointsPanel.Controls.Add(this.pointsLabel);
            this.pointsPanel.Location = new System.Drawing.Point(299, 12);
            this.pointsPanel.Name = "pointsPanel";
            this.pointsPanel.Size = new System.Drawing.Size(195, 83);
            this.pointsPanel.TabIndex = 17;
            this.pointsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pointsPanel_Paint);
            // 
            // pointsDescriptionLabel
            // 
            this.pointsDescriptionLabel.AutoSize = true;
            this.pointsDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.pointsDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsDescriptionLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pointsDescriptionLabel.Location = new System.Drawing.Point(4, 4);
            this.pointsDescriptionLabel.Name = "pointsDescriptionLabel";
            this.pointsDescriptionLabel.Size = new System.Drawing.Size(67, 24);
            this.pointsDescriptionLabel.TabIndex = 12;
            this.pointsDescriptionLabel.Text = "Points";
            // 
            // levelPanel
            // 
            this.levelPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.levelPanel.Controls.Add(this.levelDescriptionLabel);
            this.levelPanel.Controls.Add(this.levelLabel);
            this.levelPanel.Location = new System.Drawing.Point(322, 122);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(143, 83);
            this.levelPanel.TabIndex = 18;
            this.levelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.levelPanel_Paint);
            // 
            // levelDescriptionLabel
            // 
            this.levelDescriptionLabel.AutoSize = true;
            this.levelDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelDescriptionLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.levelDescriptionLabel.Location = new System.Drawing.Point(4, 4);
            this.levelDescriptionLabel.Name = "levelDescriptionLabel";
            this.levelDescriptionLabel.Size = new System.Drawing.Size(60, 24);
            this.levelDescriptionLabel.TabIndex = 20;
            this.levelDescriptionLabel.Text = "Level";
            // 
            // linesPanel
            // 
            this.linesPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.linesPanel.Controls.Add(this.linesDescriptionLabel);
            this.linesPanel.Controls.Add(this.linesLabel);
            this.linesPanel.Location = new System.Drawing.Point(322, 264);
            this.linesPanel.Name = "linesPanel";
            this.linesPanel.Size = new System.Drawing.Size(143, 83);
            this.linesPanel.TabIndex = 19;
            this.linesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.linesPanel_Paint);
            // 
            // linesDescriptionLabel
            // 
            this.linesDescriptionLabel.AutoSize = true;
            this.linesDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.linesDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linesDescriptionLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.linesDescriptionLabel.Location = new System.Drawing.Point(4, 4);
            this.linesDescriptionLabel.Name = "linesDescriptionLabel";
            this.linesDescriptionLabel.Size = new System.Drawing.Size(60, 24);
            this.linesDescriptionLabel.TabIndex = 21;
            this.linesDescriptionLabel.Text = "Lines";
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pauseButton.Enabled = false;
            this.pauseButton.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pauseButton.Location = new System.Drawing.Point(109, 635);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(87, 23);
            this.pauseButton.TabIndex = 20;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // muteCheckBox
            // 
            this.muteCheckBox.AutoSize = true;
            this.muteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteCheckBox.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.muteCheckBox.Location = new System.Drawing.Point(309, 637);
            this.muteCheckBox.Name = "muteCheckBox";
            this.muteCheckBox.Size = new System.Drawing.Size(103, 19);
            this.muteCheckBox.TabIndex = 21;
            this.muteCheckBox.Text = "Mute Sound";
            this.muteCheckBox.UseVisualStyleBackColor = true;
            this.muteCheckBox.CheckedChanged += new System.EventHandler(this.muteCheckBox_CheckedChanged);
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Tetris_Gui_Alpha.Properties.Resources.tetris_wallpaper_pattern_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(506, 667);
            this.Controls.Add(this.muteCheckBox);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.linesPanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.pointsPanel);
            this.Controls.Add(this.controlsLinkLabel);
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
            this.pointsPanel.ResumeLayout(false);
            this.pointsPanel.PerformLayout();
            this.levelPanel.ResumeLayout(false);
            this.levelPanel.PerformLayout();
            this.linesPanel.ResumeLayout(false);
            this.linesPanel.PerformLayout();
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
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.LinkLabel controlsLinkLabel;
        private System.Windows.Forms.Panel pointsPanel;
        private System.Windows.Forms.Label pointsDescriptionLabel;
        private System.Windows.Forms.Panel levelPanel;
        private System.Windows.Forms.Label levelDescriptionLabel;
        private System.Windows.Forms.Panel linesPanel;
        private System.Windows.Forms.Label linesDescriptionLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.CheckBox muteCheckBox;
    }
}

