using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Gui_Alpha
{
    class TetriminoFactory
    {
        public TetriminoFactory() { }

        public Tetrimino getTetriminoWithShape(char shapeType)
        {
            Tetrimino tet;

            switch(char.ToUpper(shapeType))
            {
                case 'I':
                    tet = new StraightTetrimino();
                    break;
                case 'O':
                    tet = new SquareTetrimino();
                    break;
                default:
                    tet = new BasicTetrimino(shapeType);
                    break;
            }

            return tet;
        }

    }
}
