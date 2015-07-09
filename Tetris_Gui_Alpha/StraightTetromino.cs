using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Gui_Alpha
{
    class StraightTetromino : Tetromino
    {
        private int rotation = 0;

        public StraightTetromino() : base()
        {
            shape[0] = new Point(0, 1);
            shape[1] = new Point(0, 2);
            shape[2] = new Point(0, 0);
            shape[3] = new Point(0, -1);
            fillBrush = Brushes.Turquoise;
            borderPen = new Pen(Color.DarkTurquoise, BORDER_WIDTH);
        }

        public override void RotateLeft()
        {
            rotation = (rotation + 90) % 360;
            Rotate();
        }

        public override void RotateRight()
        {
            rotation -= 90;

            if (rotation < 0)
                rotation = 270;

            Rotate();
        }

        private void Rotate()
        {
            switch(rotation)
            {
                case 90: 
                    shape[0] = new Point(-1, 0);
                    shape[1] = new Point(-2, 0);
                    shape[2] = new Point(0, 0);
                    shape[3] = new Point(1, 0);
                    break;
                case 180:
                    shape[0] = new Point(-1, 1);
                    shape[1] = new Point(-1, 2);
                    shape[2] = new Point(-1, 0);
                    shape[3] = new Point(-1, -1);
                    break;
                case 270:
                    shape[0] = new Point(0, 1);
                    shape[1] = new Point(1, 1);
                    shape[2] = new Point(-1, 1);
                    shape[3] = new Point(-2, 1);
                    break;
                default: //rotation = 0
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(0, -1);
                    shape[2] = new Point(0, 1);
                    shape[3] = new Point(0, 2);
                    break;
            }
        }

       
    }
}
