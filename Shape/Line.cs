using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ShapesLibrary
{
    public class Line : Shape
    {
        protected int CoordX2;
        protected int CoordY2;

        public Line(int coordX, int coordY, int coordX2, int coordY2, Pen pen) : base(coordX, coordY)
        {
            CoordX2 = coordX2;
            CoordY2 = coordY2;
            this.pen = pen;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.DrawLine(this.pen, CoordX, CoordY, CoordX2, CoordY2);
        }
    }
}
