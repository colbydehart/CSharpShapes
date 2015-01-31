using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;

namespace CSharpShape
{
    /// <summary>
    /// Shape superclass for all shapes.
    /// </summary>
    abstract public class Shape
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int[] Velocity;
        
        
        
        /// <summary>
        /// The fill color of the shape
        /// </summary>
        public SolidColorBrush FillColor { set; get; }
        /// <summary>
        /// The color of the shape's border
        /// </summary>
        public SolidColorBrush BorderColor { set; get; }

        /// <summary>
        /// The number of sides of the shape
        /// </summary>
        abstract public int SidesCount { get; }

        public Shape()
        {
            BorderColor = new SolidColorBrush(Colors.Tomato);
            FillColor = new SolidColorBrush(Colors.Bisque);
            x = 0;
            y = 0;
            Velocity = new int[] { 20, 20 };
        }

        /// <summary>
        /// Calculates the area of the shape
        /// </summary>
        /// <returns>the area of the shape</returns>
        abstract public decimal Area();

        /// <summary>
        /// calculates the perimeter of the shape
        /// </summary>
        /// <returns>the perimeter of the shape</returns>
        abstract public decimal Perimeter();

        /// <summary>
        /// Scales the shape in size
        /// </summary>
        /// <param name="percent">integer of the percentage to scale</param>
        abstract public void Scale(int percent);

        /// <summary>
        /// Creates a polygon and adds it to a canvas at a given point
        /// </summary>
        /// <param name="canvas">the canvas to draw upon</param>
        /// <param name="x">X position to draw the shape</param>
        /// <param name="y">Y position to draw the shape</param>
        abstract public void DrawOnto(Canvas canvas, int x, int y);
    }
}
