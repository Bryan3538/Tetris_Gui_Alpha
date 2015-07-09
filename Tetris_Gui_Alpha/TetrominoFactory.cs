using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Gui_Alpha
{
    class TetrominoFactory
    {
        public TetrominoFactory() { }

        public Tetromino getTetriminoWithShape(char shapeType)
        {
            Tetromino tet;

            switch(char.ToUpper(shapeType))
            {
                case 'I':
                    tet = new StraightTetromino();
                    break;
                case 'O':
                    tet = new SquareTetromino();
                    break;
                default:
                    tet = new BasicTetromino(shapeType);
                    break;
            }

            return tet;
        }

    }
}
