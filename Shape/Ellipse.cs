using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLibrary
{
    public class Ellipse : Shape
    {
        protected int Heigth;
        protected int Width;

        public Ellipse(int CoordX, int CoordY, int height, int width, Pen pen) : base(CoordX, CoordY)
        {
            Heigth = height;
            Width = width;
            this.pen = pen;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(this.pen, CoordX, CoordY, Heigth, Width);
        }
    }
}
