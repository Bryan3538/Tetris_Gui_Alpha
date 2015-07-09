using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Gui_Alpha
{
    class SquareTetromino : Tetromino
    {
        public SquareTetromino()
        {
            shape[0] = new Point(0, 0);
            shape[1] = new Point(1, 0);
            shape[2] = new Point(1, -1);
            shape[3] = new Point(0, -1);
        }

        public override void RotateRight()
        {
            //does nothing
        }

        public override void RotateLeft()
        {
            //does nothing
        }
    }
}
