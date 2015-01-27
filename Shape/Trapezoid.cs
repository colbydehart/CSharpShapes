using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpShape
{
    public class Trapezoid : Shape
    {
        private decimal top;
        public decimal Top 
        { 
            get{ return top; } 
            set{ this.top = value; }
        }
        private decimal bottom;

        public decimal Bottom 
        { 
            get{ return bottom; } 
            set{ this.bottom = value; }
        }

        private decimal height;
        public decimal Height 
        { 
            get{ return height; } 
            set{ this.height = value; }
        }

        public decimal AcuteAngle { get; set; }
        public decimal ObtuseAngle { get; set; }

        public Trapezoid(decimal top, decimal bottom, decimal height)
        {
            if (top == bottom)
                throw new ArgumentException("Trapezoid cannot be a rectangle");
            if (top <= 0 || bottom <= 0 || height <= 0)
                throw new ArgumentException("dimensions must be positive");
            this.top = top;
            this.bottom = bottom;
            this.height = height;
            decimal wing = Math.Abs(bottom - top)/2;
            this.AcuteAngle = (decimal)(Math.Atan((double)(height / wing))*(180/Math.PI));
            this.ObtuseAngle = 180 - this.AcuteAngle;
        }

        public override decimal Area()
        {
            return (top + bottom) / 2 * height;
        }

        public override decimal Perimeter()
        {
            decimal wing = Math.Abs(top-bottom)/2;
            double angledSide = Math.Sqrt((double)(wing * wing + height*height));
            return (decimal)(angledSide * 2) + bottom + top;
        }

        public override int SidesCount
        {
            get { return 4; }
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
                throw new ArgumentException("percentage must be a positive integer");
            this.top = this.top * percent / 100;
            this.bottom = this.bottom * percent / 100;
            this.height = this.height * percent / 100;
        }
    }
}
