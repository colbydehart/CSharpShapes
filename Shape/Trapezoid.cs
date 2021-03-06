﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CSharpShape
{
    public class Trapezoid : Quadrilateral
    {

        public decimal Top { get; private set; }
        public decimal Bottom { get; private set; }
        public decimal Height { get; private set; }
        public decimal AcuteAngle { get; private set; }
        public decimal ObtuseAngle { get; private set; }

        public Trapezoid(int top, int bottom, int height)
        {
            if (top == bottom)
                throw new ArgumentException("Trapezoid cannot be a rectangle");
            if (top <= 0 || bottom <= 0 || height <= 0)
                throw new ArgumentException("Dimensions must be positive");
            this.Top = top;
            this.Bottom = bottom;
            this.Height = height;

            decimal wing = Math.Abs(Bottom - Top)/2;
            this.AcuteAngle = decimal.Round(
                                  (decimal)
                                  (Math.Atan((double)(Height / wing))
                                  * (180 / Math.PI))
                              , 2);
            this.ObtuseAngle = 180 - this.AcuteAngle;
        }

        public override decimal Area()
        {
            return (Top + Bottom) / 2 * Height;
        }

        public override decimal Perimeter()
        {
            decimal wing = Math.Abs(Top-Bottom)/2;
            double angledSide = Math.Sqrt((double)(wing * wing + Height*Height));
            return decimal.Round((decimal)(angledSide * 2) + Bottom + Top, 2);
        }

        public override void Scale(int percent)
        {
            if (percent <= 0)
                throw new ArgumentException("percentage must be a positive integer");
            this.Top = this.Top * percent / 100;
            this.Bottom = this.Bottom * percent / 100;
            this.Height = this.Height * percent / 100;
        }

        public override void DrawOnto(System.Windows.Controls.Canvas canvas, int x, int y)
        {

            double big = (double)(Top > Bottom ? Top : Bottom);
            double small = (double)(Top < Bottom ? Top : Bottom);
            double wing = (big - small)/2;
            PointCollection points = new PointCollection() {
                new Point(x+wing, y),
                new Point(x+small+wing, y),
                new Point(x+big, (double)(y+Height)),
                new Point(x, (double)(y+Height))
            };

            Polygon myTrap = new Polygon();
            myTrap.Points = points;
            myTrap.Fill = FillColor;
            myTrap.Stroke = BorderColor;
            myTrap.VerticalAlignment = VerticalAlignment.Center;
            myTrap.HorizontalAlignment = HorizontalAlignment.Left;
            myTrap.StrokeThickness = 2;

            canvas.Children.Add(myTrap);
        }
    }
}
