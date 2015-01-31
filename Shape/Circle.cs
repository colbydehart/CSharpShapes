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
    public class Circle : Shape
    {
        private decimal radius;
        public decimal Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(int radius)
        {
            this.radius = radius;
        }
        
        public override int SidesCount
        {
            get { throw new NotImplementedException(); }
        }

        public override decimal Perimeter()
        {
            throw new NotImplementedException();
        }

        public override decimal Area()
        {
            throw new NotImplementedException();
        }

        public override void Scale(int percent)
        {
            throw new NotImplementedException();
        }

        public override void DrawOnto(System.Windows.Controls.Canvas canvas, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
