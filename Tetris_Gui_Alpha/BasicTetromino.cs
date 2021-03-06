﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris_Gui_Alpha
{
    /// <summary>
    ///     This class represents all Tetrimino shapes other than 'I' and 'O'
    /// </summary>
    class BasicTetromino : Tetromino
    {
        public BasicTetromino() : base()
        {
            shape[0] = new Point(0, 0);
            shape[1] = new Point(0, -1);
            shape[2] = new Point(0, 1);
            shape[3] = new Point(1, 1);
        }

        public BasicTetromino(char type) : base()
        {

            switch (Char.ToUpper(type))
            {
                case 'L':
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(0, -1);
                    shape[2] = new Point(0, 1);
                    shape[3] = new Point(-1, 1);
                    fillBrush = Brushes.Orange;
                    borderPen = new Pen(Color.Peru, BORDER_WIDTH);
                    break;
                case 'J':
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(0, -1);
                    shape[2] = new Point(0, 1);
                    shape[3] = new Point(1, 1);
                    fillBrush = Brushes.Blue;
                    borderPen = new Pen(Color.MediumBlue, BORDER_WIDTH);
                    break;
                case 'S':
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(1, 0);
                    shape[2] = new Point(0, -1);
                    shape[3] = new Point(-1, -1);
                    fillBrush = Brushes.LimeGreen;
                    borderPen = new Pen(Color.Green, BORDER_WIDTH);
                    break;
                case 'Z':
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(-1, 0);
                    shape[2] = new Point(0, -1);
                    shape[3] = new Point(1, -1);
                    fillBrush = Brushes.Red;
                    borderPen = new Pen(Color.Firebrick, BORDER_WIDTH);
                    break;
                default: //T
                    shape[0] = new Point(0, 0);
                    shape[1] = new Point(-1, 0);
                    shape[2] = new Point(1, 0);
                    shape[3] = new Point(0, -1);
                    fillBrush = Brushes.Orchid;
                    borderPen = new Pen(Color.MediumOrchid, BORDER_WIDTH);
                    break;
            }
        }


        public override void RotateLeft()
        {
            Rotate(Math.PI / -2);
        }

        public override void RotateRight()
        {
            Rotate(Math.PI / 2);
        }

        private void Rotate(double angle)
        {
            double newX = 0;
            double newY = 0;

            for (int i = 0; i < shape.Length; i++)
            {
                newX = shape[i].X * Math.Cos(angle) - shape[i].Y * Math.Sin(angle);
                newY = shape[i].X * Math.Sin(angle) + shape[i].Y * Math.Cos(angle);
                shape[i].X = (int)Math.Round(newX, 0, MidpointRounding.AwayFromZero);
                shape[i].Y = (int)Math.Round(newY, 0, MidpointRounding.AwayFromZero);
            }
        }
    }
}
