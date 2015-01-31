using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpShape;

namespace UnitTestShape
{
    [TestClass]
    public class UnitTestCircles
    {
        [TestMethod]
        public void TestCircleConstructor()
        {
            Circle circle = new Circle(40);
            Assert.AreEqual(40, circle.Radius);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCircleConstructorSanityChecksWidth()
        {
            Circle circle = new Circle(0, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCircleConstructorSanityChecksWidthPositivity()
        {
            Circle circle = new Circle(-1, 50);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCircleConstructorSanityChecksHeight()
        {
            Circle circle = new Circle(50, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCircleConstructorSanityChecksHeightPositivity()
        {
            Circle circle = new Circle(50, -1);
        }

        [TestMethod]
        public void TestScaleCircle200Percent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(200);
            Assert.AreEqual(20, circle.Width);
            Assert.AreEqual(30, circle.Height);
        }

        [TestMethod]
        public void TestScaleCircle150Percent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(150);
            Assert.AreEqual(15, circle.Width);
            Assert.AreEqual((decimal)22.5, circle.Height);
        }

        [TestMethod]
        public void TestScaleCircle100Percent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(100);
            Assert.AreEqual(10, circle.Width);
            Assert.AreEqual(15, circle.Height);
        }

        [TestMethod]
        public void TestScaleCircle37Percent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(37);
            Assert.AreEqual((decimal)3.7, circle.Width);
            Assert.AreEqual((decimal)5.55, circle.Height);
        }

        [TestMethod]
        public void TestScaleCircleUpAndDown()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(50);
            circle.Scale(200);
            Assert.AreEqual(10, circle.Width);
            Assert.AreEqual(15, circle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleCircleTo0Percent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleCircleToNegativePercent()
        {
            Circle circle = new Circle(10, 15);
            circle.Scale(-5);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Circle circle = new Circle(1, 5);
            Assert.AreEqual(4, circle.SidesCount);
        }

        [TestMethod]
        public void TestCircleArea()
        {
            Circle circle = new Circle(1, 5);
            Assert.AreEqual(5, circle.Area());
        }

        [TestMethod]
        public void TestBiggerCircleArea()
        {
            Circle circle = new Circle(10, 100);
            Assert.AreEqual(1000, circle.Area());
        }

        [TestMethod]
        public void TestCirclePerimeter()
        {
            Circle circle = new Circle(1, 5);
            Assert.AreEqual(12, circle.Perimeter());
        }

        [TestMethod]
        public void TestBiggerCirclePerimeter()
        {
            Circle circle = new Circle(10, 100);
            Assert.AreEqual(220, circle.Perimeter());
        }

    }
}
