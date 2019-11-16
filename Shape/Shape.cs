using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;


namespace ShapesLibrary
{
    public abstract class Shape
    {
        protected int CoordX;
        protected int CoordY;
        protected Pen pen;

        protected Random random = new Random();
        
        public Shape(int coordX, int coordY)
        {
            CoordX = coordX;
            CoordY = coordY;
        }

        public abstract void Draw(Graphics graphic);
    }
}
