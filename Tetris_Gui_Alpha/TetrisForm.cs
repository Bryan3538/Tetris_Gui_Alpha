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
        int boxHeight = 30;
        int boxWidth = 30;
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
        private const int START_Y = 4;
        

        public TetrisForm()
        {
            InitializeComponent();
            panel1.Height = boxHeight * ROWS + 1;
            panel1.Width = boxWidth * COLS + 1;

            pos = new Point(START_X, START_Y);
            tetFact = new TetriminoFactory();
            typesIndex = 0;
            tet = tetFact.getTetriminoWithShape(types[typesIndex]);
            InitializeGrid();
            moveTetrimino(pos);
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
                g.DrawLine(pen, 0, yPos, panel1.Width, yPos);
                yPos += boxHeight;
            }

            //vertical lines
            int xPos = 0;
            for (int lineCount = 0; lineCount <= COLS; lineCount++)
            {
                g.DrawLine(pen, xPos, 0, xPos, panel1.Height);
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

                if (x >= COLS || x < 0 || y >= ROWS || y < 0)
                {
                    return false;
                }
                else
                {
                    if (grid[y, x])
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
            else
            {
                MessageBox.Show("Shape doesn't fit at new position!");
            }

            //replace tetrimino at new position (or old if check failed)
            placeTetriminoInGrid();

            panel1.Invalidate();
        }


        private void removeTetriminoFromGrid()
        {
            foreach (Point p in tet.Shape)
            {
                grid[pos.Y + p.Y, pos.X + p.X] = false;
            }
        }

        private void placeTetriminoInGrid()
        {
            foreach (Point p in tet.Shape)
            {
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
            moveTetrimino(new Point(pos.X - 1, pos.Y));
        }
        //move it right
        private void button4_Click(object sender, EventArgs e)
        {
            moveTetrimino(new Point(pos.X + 1, pos.Y));
        }
        private void lockShapeInGrid()
        {
            typesIndex = (typesIndex + 1) % types.Length;
            tet = tetFact.getTetriminoWithShape(types[typesIndex]);
            pos = new Point(START_X, START_Y);

            checkForCompleteRows();

            panel1.Invalidate();
        }

        private void checkForCompleteRows()
        {
            bool complete = true;
            List<int> completedRows = new List<int>();

            for(int row = ROWS - 1; row >= 0; row--)
            {
                for(int col = 0; col < COLS; col++)
                {
                    complete = complete && grid[row, col];
                }

                if (complete)
                {
                    collapseRow(row);
                    row++; //to compensate for how collapseRow moves everything up one.
                }

                complete = true;
            }
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
            removeTetriminoFromGrid();

            tet.RotateLeft();
            //if shape doesn't fit with new rotation, undo it
            if (!DoesShapeFit(pos))
                tet.RotateRight();


            placeTetriminoInGrid();
            panel1.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            removeTetriminoFromGrid();

            tet.RotateRight();
            //if shape doesn't fit with new rotation, undo it
            if (!DoesShapeFit(pos))
                tet.RotateLeft();


            placeTetriminoInGrid();
            panel1.Invalidate();
        }
    }
}
