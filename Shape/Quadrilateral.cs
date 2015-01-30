using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpShape
{
    abstract public class Quadrilateral : Shape
    {
        public override int SidesCount
        {
            get { return 4; }
        }

    }
}
