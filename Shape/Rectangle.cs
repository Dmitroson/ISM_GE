using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLibrary
{
    public class Rectangle : Shape
    {
        protected int Heigth;
        protected int Width;

        public Rectangle(int CoordX, int CoordY, int height, int width, Pen pen) : base(CoordX, CoordY)
        {
            Heigth = height;
            Width = width;
            this.pen = pen;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawRectangle(this.pen, CoordX, CoordY, Heigth, Width);
        }
    }
}