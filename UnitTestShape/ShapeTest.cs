using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpShape;
using System.Drawing;
using System.Windows.Media;

namespace UnitTestShape
{
    [TestClass]
    public class UnitTestShape
    {
        public class MyShape : Shape
        {
            public override int SidesCount
            {
                get { throw new NotImplementedException(); }
            }

            public override void Scale(int percent)
            {
                throw new NotImplementedException();
            }

            public override decimal Perimeter()
            {
                throw new NotImplementedException();
            }

            public override decimal Area()
            {
                throw new NotImplementedException();
            }

            public override void DrawOnto(System.Windows.Controls.Canvas canvas, int x, int y)
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void TestSettingBorderColor()
        {
            Shape shape = new MyShape();
            shape.BorderColor = new SolidColorBrush(Colors.AliceBlue);
            Assert.AreEqual(Colors.AliceBlue, shape.BorderColor.Color);
        }

        [TestMethod]
        public void TestDefaultBorderColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Colors.Tomato, shape.BorderColor.Color);
        }

        [TestMethod]
        public void TestSettingFillColor()
        {
            Shape shape = new MyShape();
            shape.FillColor = new SolidColorBrush(Colors.AliceBlue);
            Assert.AreEqual(Colors.AliceBlue, shape.FillColor.Color);
        }

        [TestMethod]
        public void TestDefaultFillColor()
        {
            Shape shape = new MyShape();
            Assert.AreEqual(Colors.Bisque, shape.FillColor.Color);
        }
    }
}
