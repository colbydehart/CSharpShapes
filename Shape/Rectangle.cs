using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace CSharpShape
{
    public class Rectangle : Quadrilateral
    {
        private decimal height;
        public decimal Height
        {
            get { return height; }
            set { height = value; }
        }

        private decimal width;
        public decimal Width
        {
            get { return width; }
            set { width = value; }
        }

        public Rectangle(int width, int height)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("dimensions must be greater than 0");
            }
            this.height = height;
            this.width = width;
        }

        public override decimal Area()
        {
            return Height * Width;
        }

        public override decimal Perimeter()
        {
            return (height * 2) + (width * 2);
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
                throw new ArgumentException("must be greater than 0");
            height = height * percent / 100;
            width = width * percent / 100;
        }

        public override void DrawOnto(System.Windows.Controls.Canvas canvas, int x, int y)
        {
            PointCollection points = new PointCollection() {
                new Point(x, y),
                new Point((double)(x+width), y),
                new Point((double)(x+width), (double)(y+height)),
                new Point(x, (double)(y+height))
            };

            Polygon myRect = new Polygon();
            myRect.Points = points;
            myRect.Fill = FillColor;
            myRect.Stroke = BorderColor;
            myRect.VerticalAlignment = VerticalAlignment.Center;
            myRect.HorizontalAlignment = HorizontalAlignment.Left;
            myRect.StrokeThickness = 2;

            canvas.Children.Add(myRect);
        }
    }
}
