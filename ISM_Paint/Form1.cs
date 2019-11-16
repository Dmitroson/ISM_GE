using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShapesLibrary;

namespace ISM_Paint
{
    public partial class Form1 : Form
    {
        protected List<Shape> Shapes;
        protected Mode Mode;
        protected int MouseX, MouseY;
        protected int MouseX2, MouseY2;

        
        public void AddShape(Shape shape)
        {
            Shapes.Add(shape);
            listBoxShapes.Items.Add(shape);
            pictureBox.Refresh();
        }

        public void DeleteShape(int number)
        {
            Shapes.RemoveAt(number);
            listBoxShapes.Items.RemoveAt(listBoxShapes.SelectedIndex);
            pictureBox.Refresh();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonColor.BackColor = Color.Black;
            Shapes = new List<Shape>();
            Mode = Mode.DrawPoint;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int num = listBoxShapes.SelectedIndex;

            if(num >= 0 && num < listBoxShapes.Items.Count)
            {
                DeleteShape(listBoxShapes.SelectedIndex);
            }

            if (listBoxShapes.Items.Count > 0)
            {
                listBoxShapes.SetSelected(0, true);
            }
            
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawPoint;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawLine;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            Mode = Mode.DrawCircle;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawPoint:                   
                    Shape point = new ShapesLibrary.Point(e.X, e.Y, new Pen(buttonColor.BackColor, 3));
                    AddShape(point);
                    break;

                case Mode.DrawLine:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;

                case Mode.DrawCircle:
                    MouseX = e.X;
                    MouseY = e.Y;
                    break;
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(Mode == Mode.DrawLine)
                e.Graphics.DrawLine(new Pen(buttonColor.BackColor, 3), MouseX, MouseY, MouseX2, MouseY2);

            if (Mode == Mode.DrawCircle)
                e.Graphics.DrawEllipse(new Pen(buttonColor.BackColor, 3), MouseX, MouseY, MouseX2 - MouseX, MouseY2 - MouseY);

            for (int i = 0; i < Shapes.Count; i++)
            {
                Shapes[i].Draw(e.Graphics);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawLine:
                    Shape line = new Line(MouseX, MouseY, MouseX2, MouseY2, new Pen(buttonColor.BackColor, 3));
                    AddShape(line);
                    break;

                case Mode.DrawCircle:
                    Shape circle = new Circle(MouseX, MouseY, MouseX2 - MouseX, MouseY2 - MouseY, new Pen(buttonColor.BackColor, 3));
                    AddShape(circle);
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (Mode)
            {
                case Mode.DrawLine:
                    if(e.Button == MouseButtons.Left)
                    {
                        MouseX2 = e.X;
                        MouseY2 = e.Y;
                        pictureBox.Invalidate();
                    }
                    break;

                case Mode.DrawCircle:
                    if (e.Button == MouseButtons.Left)
                    {
                        MouseX2 = e.X;
                        MouseY2 = e.Y;
                        pictureBox.Invalidate();
                    }
                    break;
            }
        }
    }
}