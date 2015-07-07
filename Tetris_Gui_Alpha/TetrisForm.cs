using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Gui_Alpha
{
    public partial class TetrisForm : Form
    {
        int boxHeight = 25;
        int boxWidth = 25;
        Brush paintBrush = new SolidBrush(Color.Blue);
        Pen paintPen = new Pen(Color.LimeGreen, 1);
        Tetrimino tet;
        Point pos;
        char[] types = new char[] { 'L', 'J', 'S', 'Z', 'T', 'O', 'I' };
        int typesIndex; //DEBUG
        private const int ROWS = 22;
        private const int COLS = 10;
        private bool[,] grid = new bool[ROWS, COLS]; //filled in blocks, except the current tetrimino
        TetriminoFactory tetFact;
        private const int START_X = 5;
        private const int START_Y = 0;
        private int points = 0;
        

        public TetrisForm()
        {
            InitializeComponent();
            InitializeTetrisPanel();

            StartNewGame();
        }

        private void StartNewGame()
        {
            dropDownTimer.Enabled = false;
            pos = new Point(START_X, START_Y);
            tetFact = new TetriminoFactory();
            selectRandomTetrisShape();
            InitializeGrid();
            moveTetrimino(pos);
        }

        private void selectRandomTetrisShape()
        {
            Random rng = new Random();
            typesIndex = rng.Next(types.Length);
            tet = tetFact.getTetriminoWithShape(types[typesIndex]);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int x;
            int y;
            Brush redBrush = new SolidBrush(Color.Red);
            Pen yellowPen = new Pen(Color.Yellow, 1);
            DrawGridLines(e.Graphics);

            //TODO: daw the grid, not just the shape
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
                if(pos.Y + p.Y >= 0)
                    grid[pos.Y + p.Y, pos.X + p.X] = true;
            }
        }

        //move it down
        private void button2_Click(object sender, EventArgs e)
        {
            moveTetriminoDown();
        }

        private void moveTetriminoDown()
        {
            moveTetrimino(new Point(pos.X, pos.Y + 1));

            if (isShapeStuck())
                lockShapeInGrid();
        }

        //move it left
        private void button3_Click(object sender, EventArgs e)
        {
            
            moveTetriminoLeft();
        }

        private void moveTetriminoLeft()
        {
            moveTetrimino(new Point(pos.X - 1, pos.Y));
        }

        //move it right
        private void button4_Click(object sender, EventArgs e)
        {
            moveTetriminoRight();
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
                MessageBox.Show("YOU LOSE!");
            }
            else 
            {
                selectRandomTetrisShape();
                pos = new Point(START_X, START_Y);
            }
           
            tetrisPanel.Invalidate();
        }

        private bool hasPlayerLost()
        {
            bool lost = true;
            for(int col = 0; col < COLS; col++)
            {
                for(int row = 0; row < ROWS; row++)
                {
                    lost = lost && grid[row, col];
                }

                if (lost)
                    return lost;

                lost = true;
            }

            return false;
        }

        private void checkForCompleteRows()
        {
            bool complete = true;
            int completedRows = 0;

            for(int row = ROWS - 1; row >= 0; row--)
            {
                for(int col = 0; col < COLS; col++)
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
            for(int r = row - 1; r >= 0; r--)
            {
                for(int c = 0; c < COLS; c++)
                {
                    grid[r + 1, c] = grid[r, c];
                    grid[r, c] = false;
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            rotateTetriminoLeft();
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

        private void button5_Click(object sender, EventArgs e)
        {
            rotateTetriminoRight();
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

        private void button6_Click(object sender, EventArgs e)
        {
            //if(!dropDownTimer.Enabled)
            //    dropDownTimer.Enabled = true;
            dropDownTimer.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //if (dropDownTimer.Enabled)
            //    dropDownTimer.Enabled = false;
            dropDownTimer.Stop();
        }

        private void dropDownTimer_Tick(object sender, EventArgs e)
        {
            moveTetriminoDown();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void TetrisForm_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
