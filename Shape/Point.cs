using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLibrary
{
    public class Point : Shape
    {
        protected int Heigth;
        protected int Width;

        public Point(int CoordX, int CoordY, Pen pen) : base(CoordX, CoordY)
        {
            Heigth = 2;
            Width = 2;
            this.pen = pen;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawEllipse(this.pen, CoordX, CoordY, Heigth, Width);
        }
    }
}
