using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Gui_Alpha
{
    abstract class Tetromino
    {
        protected Point[] shape;
        protected Brush fillBrush;
        protected Pen borderPen;
        protected const int BORDER_WIDTH = 3;

        protected Tetromino()
        {
            shape = new Point[4];
        }

        protected Tetromino(Tetromino t2)
        {
            this.shape[0] = t2.shape[0];
            this.shape[1] = t2.shape[1];
            this.shape[2] = t2.shape[2];
            this.shape[3] = t2.shape[3];
        }

        abstract public void RotateRight();
        abstract public void RotateLeft();

        public Point[] Shape
        {
            get
            {
                Point[] copy = new Point[shape.Length];

                for (int i = 0; i < copy.Length; i++)
                {
                    copy[i] = new Point(shape[i].X, shape[i].Y);
                }

                return copy;
            }

        }

        public Brush FillBrush
        {
            get { return fillBrush; }
        }

        public Pen BorderPen
        {
            get { return borderPen; }
        }

        //public int Height
        //{
        //    get
        //    {
        //        int min = 99;
        //        int max = -99;
        //        foreach(Point p in shape)
        //        {
        //            if (p.Y < min)
        //                min = p.Y;
        //            if (p.Y > max)
        //                max = p.Y;
        //        }

        //        return max - min + 1;
        //    }
        //}
    }
}
