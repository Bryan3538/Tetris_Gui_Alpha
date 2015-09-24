using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Gui_Alpha
{
    class TetrisGame
    {
        #region constants
        private const int ROWS = 22;
        private const int COLS = 10;
        private const int SHAPES_TO_STORE = 50;
        private const int REFILL_QUEUE_THRESHOLD = 1;
        private const int START_Y = 0;
        #endregion

        #region variables
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

        #region constructors and initialization

        public TetrisGame()
        {
            types = new char[] { 'L', 'J', 'S', 'Z', 'T', 'O', 'I' };
            grid = new bool[ROWS, COLS];
            points = 0;
            futureShapes = new Queue<Tetromino>(SHAPES_TO_STORE);
            level = 0;
            rows = 0;

            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    grid[row, col] = false;
                }
            }
        }

        #endregion

        #region shape methods
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

            //TODO: fix tetrisPanel.Invalidate();
        }

        private void removeTetriminoFromGrid()
        {
            foreach (Point p in tet.Shape)
            {
                if (pos.Y + p.Y >= 0)
                {
                    grid[pos.Y + p.Y, pos.X + p.X] = false;
                    //TODO: fix fillBrushes[pos.Y + p.Y, pos.X + p.X] = null;
                    //TODO: fix borderPens[pos.Y + p.Y, pos.X + p.X] = null;
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
                    //TODO: fix fillBrushes[pos.Y + p.Y, pos.X + p.X] = tet.FillBrush;
                    //TODO: fix borderPens[pos.Y + p.Y, pos.X + p.X] = tet.BorderPen;
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
                //dropDownTimer.Stop();
                //backgroundThemePlayer.controls.stop();
                //stopGame();
                //MessageBox.Show("YOU LOSE!");


                //TODO: set a flag for player losing
            }
            else
            {
                tet = futureShapes.Dequeue();
                pos = new Point(new Random().Next(1, COLS - 1), START_Y);

                if (futureShapes.Count < REFILL_QUEUE_THRESHOLD)
                    FillMovesQueue();

                //TODO: fix updateShapePreview();
            }

            //TODO: fix tetrisPanel.Invalidate();
        }

        //TODO: replace this method
        //private void updateShapePreview()
        //{
        //    previewShapePanel.Invalidate();
        //}

        private bool isShapeStuck()
        {
            bool stuck = false;
            removeTetriminoFromGrid();
            foreach (Point p in tet.Shape)
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
            //TODO: fix tetrisPanel.Invalidate();
        }

        private void rotateTetriminoRight()
        {
            removeTetriminoFromGrid();

            tet.RotateRight();
            //if shape doesn't fit with new rotation, undo it
            if (!DoesShapeFit(pos))
                tet.RotateLeft();


            placeTetriminoInGrid();
            //TODO: fix tetrisPanel.Invalidate();
        }
        #endregion

        #region game manipulation methods
        private void SetupNewGame()
        {
            //TODO: fix dropDownTimer.Enabled = false;
            //TODO: fix dropDownTimer.Interval = DEFAULT_DROPDOWN_INTERVAL;
            level = 0;
            rows = 0;
            points = 0;
            //TODO: fix pointsLabel.Text = "0";
            //TODO: fix levelLabel.Text = "0";
            //TODO: fix linesLabel.Text = "0";
            //TODO: fix paused = false;
            //TODO: fix pauseButton.Text = "Pause";
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


            while (futureShapes.Count < SHAPES_TO_STORE)
            {
                typesIndex = rng.Next(types.Length);
                futureShapes.Enqueue(tetFact.getTetriminoWithShape(types[typesIndex]));
            }
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
            //TODO: fix pointsLabel.Text = points.ToString("N0");
            //add to rows
            if (completedRows > 0)
            {
                rows += completedRows;
                //TODO: fix linesLabel.Text = rows.ToString("N0");
            }
            //determine level
            if ((rows > (level * (level + 1) / 2) * 5 && level != 0) || (level == 0 && rows >= 3))
            {
                level++;
                //TODO: fix dropDownTimer.Interval = (int)(Math.Pow(0.9, level) * dropDownTimer.Interval);
                //TODO: fix levelLabel.Text = level.ToString("N0");
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
                    //TODO: fix fillBrushes[r + 1, c] = fillBrushes[r, c];
                    //TODO: fix borderPens[r + 1, c] = borderPens[r, c];

                    //delete the row that was just moved
                    grid[r, c] = false;
                    //TODO: fix fillBrushes[r, c] = null;
                    //TODO: fix orderPens[r, c] = null;
                }
            }
        }
        #endregion

    }
}
