using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShape
{
    public class Rectangle : Shape
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

        public Rectangle(decimal width, decimal height)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("dimensions must be greater than 0");
            }
            this.height = height;
            this.width = width;
        }

        public override int SidesCount
        {
            get { return 4; }
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

    }
}
