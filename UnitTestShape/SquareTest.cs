using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpShape;

namespace UnitTestShape
{
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        public void SquareIsConstructedWithSingleArgument()
        {
            Square square = new Square(3);
            Assert.AreEqual(square.Width, 3);
            Assert.AreEqual(square.Height, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareSanityChecksWidth()
        {
            Square square = new Square(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareSanityChecksWidthPositivity()
        {
            Square square = new Square(-1);
        }

        [TestMethod]
        public void SquareScale200()
        {
            Square squ = new Square(10);
            squ.Scale(200);
            Assert.AreEqual(squ.Width, 20);
            Assert.AreEqual(squ.Height, 20);
        }

        [TestMethod]
        public void SquareScale150()
        {
            Square squ = new Square(10);
            squ.Scale(150);
            Assert.AreEqual(squ.Width, 15);
            Assert.AreEqual(squ.Height, 15);
        }

        [TestMethod]
        public void SquareScale100()
        {
            Square squ = new Square(10);
            squ.Scale(100);
            Assert.AreEqual(squ.Height, 10);
            Assert.AreEqual(squ.Width, 10);
        }

        [TestMethod]
        public void SquareScale37()
        {
            Square squ = new Square(10);
            squ.Scale(37);
            Assert.AreEqual(squ.Height, (decimal)3.7);
            Assert.AreEqual(squ.Width, (decimal)3.7);
        }

        [TestMethod]
        public void SquareScaleUpAndDown()
        {
            Square squ = new Square(10);
            squ.Scale(50);
            squ.Scale(200);
            Assert.AreEqual(squ.Width, 10);
            Assert.AreEqual(squ.Height, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareScale0()
        {
            Square squ = new Square(10);
            squ.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareScaleNegative()
        {
            Square squ = new Square(10);
            squ.Scale(-100);
        }

        [TestMethod]
        public void SquareSidesCount()
        {
            Square squ = new Square(10);
            Assert.AreEqual(squ.SidesCount, 4);
        }

        [TestMethod]
        public void SquareArea()
        {
            Square squ = new Square(10);
            Assert.AreEqual(squ.Area(), 100);
        }

        [TestMethod]
        public void SquareLargerArea()
        {
            Square squ = new Square(20);
            Assert.AreEqual(squ.Area(), 400);
        }

        [TestMethod]
        public void SquarePerimeter()
        {
            Square squ = new Square(10);
            Assert.AreEqual(squ.Perimeter(), 40);
        }

        [TestMethod]
        public void SquareLargerPerimeter()
        {
            Square squ = new Square(20);
            Assert.AreEqual(squ.Perimeter(), 80);
        }

        [TestMethod]
        public void SquareDefaultColors()
        {
            Rectangle shape = new Rectangle(10, 15);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }


    }
}
