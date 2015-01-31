using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShape
{
    /// <summary>
    /// A square shape
    /// </summary>
    public class Square : Rectangle
    {
        /// Constructor for square based off one of its edge's lenghths
        /// </summary>
        /// <param name="edgelength">Length of one of the edges</param>
        public Square(int edgelength) : base(edgelength, edgelength) { }
    }
}
