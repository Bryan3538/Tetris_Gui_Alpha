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

namespace Tetris_Gui_Alpha
{
    public partial class TetrisForm : Form
    {
        //TODO: Rename methods so that they're consistent

        #region Constants

        private const int ROWS = 22;
        private const int COLS = 10;
        //private const int START_X = 5; //replaced with random generation
        private const int START_Y = 0;

        #endregion

        #region Variables

        private int boxHeight;
        private int boxWidth;
        private Brush paintBrush;
        private Pen paintPen;
        private Tetromino tet;
        private Point pos;
        private char[] types;
        private int typesIndex;
        private bool[,] grid;
        private Brush[,] brushes;
        private TetrominoFactory tetFact;
        private int points;
        private WMPLib.WindowsMediaPlayer backgroundThemePlayer;
        private const string BACKGROUND_THEME_URL = @"sounds/theme.mp3";
        private bool gamePlaying;

        #endregion


        #region Constructors_and_Initializations
        
        public TetrisForm()
        {
            InitializeComponent();

            //stops panel flickering on redraw
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, tetrisPanel, new object[] { true });

            #region Variable_Initialization
            boxHeight = 25;
            boxWidth = 25;
            paintBrush = new SolidBrush(Color.Blue);
            paintPen = new Pen(Color.LimeGreen, 1);
            types = new char[] { 'L', 'J', 'S', 'Z', 'T', 'O', 'I' };
            grid = new bool[ROWS, COLS];
            points = 0;
            backgroundThemePlayer = new WMPLib.WindowsMediaPlayer();
            backgroundThemePlayer.URL = BACKGROUND_THEME_URL;
            backgroundThemePlayer.settings.setMode("Loop", true);
            backgroundThemePlayer.controls.stop();
            gamePlaying = false;
            #endregion

            InitializeTetrisPanel();

            SetupNewGame();
        }

        private void InitializeTetrisPanel()
                {
                    tetrisPanel.Height = boxHeight * ROWS + 1;
                    tetrisPanel.Width = boxWidth * COLS + 1;
                    Point panelPosition = new Point();
                    panelPosition.X = this.Width / 2 - tetrisPanel.Width / 2;
                    panelPosition.Y = 10;
                    tetrisPanel.Location = panelPosition;
                }

        private void InitializeGrid()
        {
            for(int row = 0; row < ROWS; row++)
            {
                for(int col = 0; col < COLS; col++)
                {
                    grid[row, col] = false;
                }
            }
        }

        #endregion


        #region Shape_Methods

        private void selectRandomTetrisShape()
        {
            Random rng = new Random();
            typesIndex = rng.Next(types.Length);
            tet = tetFact.getTetriminoWithShape(types[typesIndex]);
        }

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
                    grid[pos.Y + p.Y, pos.X + p.X] = false;
            }
        }

        private void placeTetriminoInGrid()
        {
            foreach (Point p in tet.Shape)
            {
                if (pos.Y + p.Y >= 0)
                    grid[pos.Y + p.Y, pos.X + p.X] = true;
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
                selectRandomTetrisShape();
                pos = new Point(new Random().Next(COLS - 1) + 1, START_Y);
            }
           
            tetrisPanel.Invalidate();
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

            return stuck; //shape can continue descending
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
            pos = new Point(new Random().Next(COLS - 1) + 1, START_Y);
            tetFact = new TetrominoFactory();
            selectRandomTetrisShape();
            InitializeGrid();
            moveTetrimino(pos);
            disableInputs();
        }

        private void stopGame()
        {
            dropDownTimer.Stop();
            backgroundThemePlayer.controls.stop();
            gamePlaying = false;
            disableInputs();

            //TODO: Play some kind of losing sound
        }

        private void startGame()
        {
            dropDownTimer.Start();
            backgroundThemePlayer.controls.play();
            gamePlaying = true;
            enableInputs();
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
            points += ((completedRows * (completedRows + 1)) / 2) * 100;
            pointsLabel.Text = points.ToString();
        }

        private void collapseRow(int row)
        {
            //set row to all falses
            for (int col = 0; col < COLS; col++)
                grid[row, col] = false;

            //move all other rows up 1
            for (int r = row - 1; r >= 0; r--)
            {
                for (int c = 0; c < COLS; c++)
                {
                    grid[r + 1, c] = grid[r, c];
                    grid[r, c] = false;
                }
            }
        }

        #endregion


        #region Graphics

        private void tetrisPanel_Paint(object sender, PaintEventArgs e)
        {
            int x;
            int y;
            Brush redBrush = new SolidBrush(Color.Red);
            Pen yellowPen = new Pen(Color.Yellow, 1);
            DrawGridLines(e.Graphics);

            for (int row = 0; row < ROWS; row++)
            {
                for(int col = 0; col < COLS; col++)
                {
                    if (grid[row, col] == true)
                    {
                        x = col * boxWidth;
                        y = row * boxHeight;
                        e.Graphics.FillRectangle(redBrush, x, y, boxWidth, boxHeight);
                        e.Graphics.DrawRectangle(yellowPen, x, y, boxWidth, boxHeight);
                    }
                }
            }

            foreach (Point p in tet.Shape)
            {
                x = (pos.X + p.X) * boxWidth;
                y = (pos.Y + p.Y) * boxHeight;
                e.Graphics.FillRectangle(paintBrush, x, y, boxWidth, boxHeight);
                e.Graphics.DrawRectangle(paintPen, x, y, boxWidth, boxHeight);
            }
        }

        private void DrawGridLines(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);
            

            //horizontal lines
            int yPos = 0;
            for (int lineCount = 0; lineCount <= ROWS; lineCount++ )
            {
                g.DrawLine(pen, 0, yPos, tetrisPanel.Width, yPos);
                yPos += boxHeight;
            }

            //vertical lines
            int xPos = 0;
            for (int lineCount = 0; lineCount <= COLS; lineCount++)
            {
                g.DrawLine(pen, xPos, 0, xPos, tetrisPanel.Height);
                xPos += boxWidth;
            }
        }

        #endregion


        #region Input_&_Event_Handling

        private void disableInputs()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button) && !c.Equals(startButton))
                {
                    c.Enabled = false;
                }
            }
        }

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

        private void resetButton_Click(object sender, EventArgs e)
        {
            SetupNewGame();
        }

        private void TetrisForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gamePlaying)
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

        #endregion
    }
}
