using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Tetris_Gui_Alpha
{
    public partial class TetrisForm : Form
    {
        //TODO: Rename methods so that they're consistent

        #region Constants

        private const int ROWS = 22;
        private const int COLS = 10;
        private const int SHAPES_TO_STORE = 50;
        private const int REFILL_QUEUE_THRESHOLD = 1;
        private const int START_Y = 0;
        
        
        private const int BOX_HEIGHT = 28;
        private const int BOX_WIDTH = 28;
        private const int DEFAULT_DROPDOWN_INTERVAL = 750;
        private const string BACKGROUND_THEME_URL = @"sounds/theme.mp3";
        #endregion

        #region Variables
        
        private Brush defaultBrush;
        private Pen defaultPen;
        private Brush[,] fillBrushes;
        private Pen[,] borderPens;
        private WMPLib.WindowsMediaPlayer backgroundThemePlayer;
        private bool gamePlaying;
        private bool paused;
        private bool muted;

        private Tetromino tet;
        private char[] types;
        private Point pos;
        private bool[,] grid;
        private TetrominoFactory tetFact;
        private int points;
        private int level;
        private int rows;
        private Queue<Tetromino> futureShapes;

        #endregion


        #region Constructors_and_Initializations
        
        public TetrisForm()
        {
            InitializeComponent();

            //stops panel flickering on redraw
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, tetrisPanel, new object[] { true });
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, previewShapePanel, new object[] { true });

            #region Variable_Initialization
            defaultBrush = new SolidBrush(Color.Blue);
            defaultPen = new Pen(Color.LimeGreen, 1);
            types = new char[] { 'L', 'J', 'S', 'Z', 'T', 'O', 'I' };
            grid = new bool[ROWS, COLS];
            fillBrushes = new Brush[ROWS, COLS];
            borderPens = new Pen[ROWS, COLS];
            points = 0;
            backgroundThemePlayer = new WMPLib.WindowsMediaPlayer();
            backgroundThemePlayer.URL = BACKGROUND_THEME_URL;
            backgroundThemePlayer.settings.setMode("Loop", true);
            backgroundThemePlayer.controls.stop();
            gamePlaying = false;
            futureShapes = new Queue<Tetromino>(SHAPES_TO_STORE);
            level = 0;
            rows = 0;
            #endregion

            StyleGUI();

            //InitializeTetrisPanel();

            SetupNewGame();
        }

        //private void InitializeTetrisPanel()
        //{
        //    tetrisPanel.Height = BOX_HEIGHT * ROWS + 1;
        //    tetrisPanel.Width = BOX_WIDTH * COLS + 1;
        //    Point panelPosition = new Point();
        //    panelPosition.X = this.Width / 2 - tetrisPanel.Width / 2;
        //    panelPosition.Y = 10;
        //    tetrisPanel.Location = panelPosition;
        //}

        private void InitializeGrid()
        {
            for(int row = 0; row < ROWS; row++)
            {
                for(int col = 0; col < COLS; col++)
                {
                    grid[row, col] = false;
                    fillBrushes[row, col] = null;
                    borderPens[row, col] = null;
                }
            }
        }

        private void StyleGUI()
        {
            Color backColor = Color.FromArgb(210, 155, 78, 0);
            tetrisPanel.BackColor = backColor;
            pointsPanel.BackColor = backColor;
            levelPanel.BackColor = backColor;
            linesPanel.BackColor = backColor;
            previewShapePanel.BackColor = backColor;

            nextShapeLabel.ForeColor = Color.WhiteSmoke;

            pointsDescriptionLabel.ForeColor = Color.WhiteSmoke;
            pointsLabel.ForeColor = Color.WhiteSmoke;

            levelDescriptionLabel.ForeColor = Color.WhiteSmoke;
            levelLabel.ForeColor = Color.WhiteSmoke;

            linesDescriptionLabel.ForeColor = Color.WhiteSmoke;
            linesLabel.ForeColor = Color.WhiteSmoke;
            

            Color buttonColor = Color.FromArgb(210, 155, 78, 0);
            startButton.BackColor = buttonColor;
            startButton.ForeColor = Color.WhiteSmoke;

            stopButton.BackColor = buttonColor;
            stopButton.ForeColor = Color.WhiteSmoke;

            pauseButton.BackColor = buttonColor;
            pauseButton.ForeColor = Color.WhiteSmoke;

            controlsLinkLabel.BackColor = backColor;
            controlsLinkLabel.LinkColor = Color.WhiteSmoke;
            controlsLinkLabel.ActiveLinkColor = Color.WhiteSmoke;

            muteCheckBox.BackColor = backColor;
            muteCheckBox.ForeColor = Color.WhiteSmoke;
        }

        #endregion


        #region Shape_Methods

        private bool DoesShapeFit(Point position)
        {
            int x;
            int y;

            foreach (Point p in tet.Shape)
            {
                x = position.X + p.X;
                y = position.Y + p.Y;

                if (x >= COLS || x < 0 || y >= ROWS)
                {
                    return false;
                }
                else
                {
                    if (y >= 0 && grid[y, x])
                        return false;
                }
            }

            return true;
        }

        private void moveTetrimino(Point newPosition)
        {
            //remove old tetrimino blocks from grid
            removeTetriminoFromGrid();

            if (DoesShapeFit(newPosition))
            {
                //set position to new position
                pos.X = newPosition.X;
                pos.Y = newPosition.Y;
            }

            //replace tetrimino at new position (or old if check failed)
            placeTetriminoInGrid();

            tetrisPanel.Invalidate();
        }

        private void removeTetriminoFromGrid()
        {
            foreach (Point p in tet.Shape)
            {
                if (pos.Y + p.Y >= 0)
                {
                    grid[pos.Y + p.Y, pos.X + p.X] = false;
                    fillBrushes[pos.Y + p.Y, pos.X + p.X] = null;
                    borderPens[pos.Y + p.Y, pos.X + p.X] = null;
                }
            }
        }

        private void placeTetriminoInGrid()
        {
            foreach (Point p in tet.Shape)
            {
                if (pos.Y + p.Y >= 0)
                {
                    grid[pos.Y + p.Y, pos.X + p.X] = true;
                    fillBrushes[pos.Y + p.Y, pos.X + p.X] = tet.FillBrush;
                    borderPens[pos.Y + p.Y, pos.X + p.X] = tet.BorderPen;
                }
            }
        }

        private void moveTetriminoDown()
        {
            moveTetrimino(new Point(pos.X, pos.Y + 1));

            if (isShapeStuck())
                lockShapeInGrid();
        }

        private void moveTetriminoLeft()
        {
            moveTetrimino(new Point(pos.X - 1, pos.Y));
        }

        private void moveTetriminoRight()
        {
            moveTetrimino(new Point(pos.X + 1, pos.Y));
        }

        private void lockShapeInGrid()
        {
            checkForCompleteRows();

            if (hasPlayerLost())
            {
                dropDownTimer.Stop();
                backgroundThemePlayer.controls.stop();
                stopGame();
                MessageBox.Show("YOU LOSE!");
            }
            else 
            {
                tet = futureShapes.Dequeue();
                pos = new Point(new Random().Next(1, COLS - 1), START_Y);

                if (futureShapes.Count < REFILL_QUEUE_THRESHOLD)
                    FillMovesQueue();

                updateShapePreview();
            }
           
            tetrisPanel.Invalidate();
        }

        private void updateShapePreview()
        {
            previewShapePanel.Invalidate();
        }

        private bool isShapeStuck()
        {
            bool stuck = false;
            removeTetriminoFromGrid();
            foreach(Point p in tet.Shape)
            {
                if (pos.Y + p.Y + 1 >= ROWS) //shape is at bottom
                    stuck = true;
                else if (grid[pos.Y + p.Y + 1, pos.X + p.X]) //grid square below shape is filled
                    stuck = true;
            }
            placeTetriminoInGrid();

            return stuck;
        }

        private void rotateTetriminoLeft()
        {
            removeTetriminoFromGrid();

            tet.RotateLeft();
            //if shape doesn't fit with new rotation, undo it
            if (!DoesShapeFit(pos))
                tet.RotateRight();


            placeTetriminoInGrid();
            tetrisPanel.Invalidate();
        }

        private void rotateTetriminoRight()
        {
            removeTetriminoFromGrid();

            tet.RotateRight();
            //if shape doesn't fit with new rotation, undo it
            if (!DoesShapeFit(pos))
                tet.RotateLeft();


            placeTetriminoInGrid();
            tetrisPanel.Invalidate();
        }

        #endregion


        #region Game_Manipulation_Methods
        private void SetupNewGame()
        {
            dropDownTimer.Enabled = false;
            dropDownTimer.Interval = DEFAULT_DROPDOWN_INTERVAL;
            level = 0;
            rows = 0;
            points = 0;
            pointsLabel.Text = "0";
            levelLabel.Text = "0";
            linesLabel.Text = "0";
            paused = false;
            pauseButton.Text = "Pause";
            pos = new Point(new Random().Next(COLS - 1) + 1, START_Y);
            tetFact = new TetrominoFactory();

            if (futureShapes.Count > 0)
                futureShapes.Clear();

            FillMovesQueue();
            tet = futureShapes.Dequeue();
            InitializeGrid();

            moveTetrimino(pos);
        }

        private void FillMovesQueue()
        {
            Random rng = new Random();
            int typesIndex;
            

            while(futureShapes.Count < SHAPES_TO_STORE)
            {
                typesIndex = rng.Next(types.Length);
                futureShapes.Enqueue(tetFact.getTetriminoWithShape(types[typesIndex]));
            }
        }

        private void stopGame()
        {
            dropDownTimer.Stop();
            backgroundThemePlayer.controls.stop();
            gamePlaying = false;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            pauseButton.Enabled = false;

            //TODO: Play some kind of losing sound
        }

        private void startGame()
        {
            dropDownTimer.Start();
            if(!muted)
                backgroundThemePlayer.controls.play();
            gamePlaying = true;
            enableInputs();
            previewShapePanel.Invalidate();
            stopButton.Enabled = true;
            startButton.Enabled = false;
            pauseButton.Enabled = true;
        }

        private bool hasPlayerLost()
        {
            #region oldAlgorithm_Scrapped
            //bool lost = true;

            //for(int col = 0; col < COLS; col++)
            //{
            //    for(int row = 0; row < ROWS; row++)
            //    {
            //        lost = lost && grid[row, col];
            //    }

            //    if (lost)
            //        return lost;

            //    lost = true;
            //}

            //return false;
            #endregion
            int row = 0;
            for (int col = 0; col < COLS; col++)
                if (grid[row, col])
                    return true;

            return false;

        }

        private void checkForCompleteRows()
        {
            bool complete = true;
            int completedRows = 0;

            for (int row = ROWS - 1; row >= 0; row--)
            {
                for (int col = 0; col < COLS; col++)
                {
                    complete = complete && grid[row, col];
                }

                if (complete)
                {
                    completedRows++;
                    collapseRow(row);
                    row++; //to compensate for how collapseRow moves everything up one.
                }
                complete = true;
            }

            //add to points
            points += ((completedRows * (completedRows + 1)) / 2) * (100 * level);
            pointsLabel.Text = points.ToString("N0");
            //add to rows
            if (completedRows > 0)
            {
                rows += completedRows;
                linesLabel.Text = rows.ToString("N0");
            }
            //determine level
            if ((rows > (level * (level + 1) / 2) * 5 && level != 0) || (level == 0 && rows >= 3))
            {
                level++;
                dropDownTimer.Interval = (int)(Math.Pow(0.9, level) * dropDownTimer.Interval);
                levelLabel.Text = level.ToString("N0");
            } 
                
        }

        private void collapseRow(int row)
        {
            //Collapse the specified row
            for (int col = 0; col < COLS; col++)
                grid[row, col] = false;

            //move all other rows up 1
            for (int r = row - 1; r >= 0; r--)
            {
                for (int c = 0; c < COLS; c++)
                {
                    //move everything up one row (further down as drawn)
                    grid[r + 1, c] = grid[r, c];
                    fillBrushes[r + 1, c] = fillBrushes[r, c];
                    borderPens[r + 1, c] = borderPens[r, c];

                    //delete the row that was just moved
                    grid[r, c] = false;
                    fillBrushes[r, c] = null;
                    borderPens[r, c] = null;
                }
            }
        }

        private void togglePause()
        {
            if (!paused)
            {
                paused = true;
                pauseButton.Text = "Unpause";
            }
            else
            {
                paused = false;
                pauseButton.Text = "Pause";
            }


            if(paused)
            {
                backgroundThemePlayer.controls.pause();
                dropDownTimer.Stop();
            }
            else
            {
                if(!muted)
                    backgroundThemePlayer.controls.play();
                dropDownTimer.Start();
            }
        }

        #endregion


        #region Graphics

        private void tetrisPanel_Paint(object sender, PaintEventArgs e)
        {
            int x;
            int y;
            DrawGridLines(e.Graphics);

            for (int row = 0; row < ROWS; row++)
            {
                for(int col = 0; col < COLS; col++)
                {
                    if (grid[row, col] == true)
                    {
                        x = col * BOX_WIDTH;
                        y = row * BOX_HEIGHT;
                        e.Graphics.FillRectangle(fillBrushes[row, col], x, y, BOX_WIDTH, BOX_HEIGHT);
                        e.Graphics.DrawRectangle(borderPens[row, col], x, y, BOX_WIDTH, BOX_HEIGHT);
                    }
                }
            }

            foreach (Point p in tet.Shape)
            {
                x = (pos.X + p.X) * BOX_WIDTH;
                y = (pos.Y + p.Y) * BOX_HEIGHT;
                e.Graphics.FillRectangle(tet.FillBrush, x, y, BOX_WIDTH, BOX_HEIGHT);
                e.Graphics.DrawRectangle(tet.BorderPen, x, y, BOX_WIDTH, BOX_HEIGHT);
            }
        }

        private void DrawGridLines(Graphics g)
        {
            Pen pen = new Pen(Color.WhiteSmoke, 1);
            

            //horizontal lines
            int yPos = 0;
            for (int lineCount = 0; lineCount <= ROWS; lineCount++ )
            {
                g.DrawLine(pen, 0, yPos, tetrisPanel.Width, yPos);
                yPos += BOX_HEIGHT;
            }

            //vertical lines
            int xPos = 0;
            for (int lineCount = 0; lineCount <= COLS; lineCount++)
            {
                g.DrawLine(pen, xPos, 0, xPos, tetrisPanel.Height);
                xPos += BOX_WIDTH;
            }
        }

        private void previewShapePanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.previewShapePanel.ClientRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
            if(futureShapes.Count >= 1 && gamePlaying)
            {
                int xBase = previewShapePanel.Width / 2 - BOX_WIDTH / 2;
                int yBase = previewShapePanel.Height / 2 - BOX_HEIGHT / 2;

                Tetromino nextShape = futureShapes.Peek();

                foreach(Point p in nextShape.Shape)
                {
                    int x = xBase + p.X * BOX_WIDTH;
                    int y = yBase + p.Y * BOX_WIDTH;
                    //fill the shape
                    e.Graphics.FillRectangle(nextShape.FillBrush, xBase + p.X * BOX_WIDTH, yBase + p.Y * BOX_WIDTH,
                        BOX_WIDTH, BOX_HEIGHT);
                    //draw the border
                    e.Graphics.DrawRectangle(nextShape.BorderPen, xBase + p.X * BOX_WIDTH, yBase + p.Y * BOX_WIDTH,
                        BOX_WIDTH, BOX_HEIGHT);
                }
            } 
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this,
                "Q\t=\tRotate Left" + Environment.NewLine +
                "E\t=\tRotate Right" + Environment.NewLine +
                "A\t=\tMove Left" + Environment.NewLine +
                "S\t=\tMove Down" + Environment.NewLine +
                "D\t=\tMove Right" + Environment.NewLine,

                "Controls",
                MessageBoxButtons.OK,
                MessageBoxIcon.None
                );
        }

        private void pointsPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pointsPanel.ClientRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void levelPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.levelPanel.ClientRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void linesPanel_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.linesPanel.ClientRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        #endregion


        #region Input_&_Event_Handling

        private void enableInputs()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    c.Enabled = true;
                }
            }
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            moveTetriminoDown();
        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {

            moveTetriminoLeft();
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            moveTetriminoRight();
        }

        private void rotateLeftButton_Click(object sender, EventArgs e)
        {
            rotateTetriminoLeft();
        }

        private void rotateRightButton_Click(object sender, EventArgs e)
        {
            rotateTetriminoRight();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            SetupNewGame();
            startGame();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopGame();
            
        }

        private void dropDownTimer_Tick(object sender, EventArgs e)
        {
            moveTetriminoDown();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            togglePause();
        }

        private void TetrisForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gamePlaying && !paused)
            {
                switch (char.ToUpper(e.KeyChar))
                {
                    case (char)Keys.A:
                    case (char)Keys.Left:
                        moveTetriminoLeft();
                        break;
                    case (char)Keys.S:
                    case (char)Keys.Down:
                        moveTetriminoDown();
                        break;
                    case (char)Keys.D:
                    case (char)Keys.Right:
                        moveTetriminoRight();
                        break;
                    case (char)Keys.Q:
                    case (char)Keys.Up:
                        rotateTetriminoLeft();
                        break;
                    case (char)Keys.E:
                        rotateTetriminoRight();
                        break;
                }
            }

            #region keydownhandler
            //Used if handling in keydown instead of keypressed
            //switch (e.KeyData)
            //{
            //    case Keys.A:
            //    case Keys.Left:
            //        moveTetriminoLeft();
            //        break;
            //    case Keys.S:
            //    case Keys.Down:
            //        moveTetriminoDown();
            //        break;
            //    case Keys.D:
            //    case Keys.Right:
            //        moveTetriminoRight();
            //        break;
            //    case Keys.Q:
            //    case Keys.Up:
            //        rotateTetriminoLeft();
            //        break;
            //    case Keys.E:
            //        rotateTetriminoRight();
            //        break;
            //}
            #endregion
        }

        private void muteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            muted = muteCheckBox.Checked;

            if (muted)
                backgroundThemePlayer.controls.pause();
            else if (gamePlaying && !paused)
                backgroundThemePlayer.controls.play();
        }

        #endregion

        

        

        
        
    }
}
