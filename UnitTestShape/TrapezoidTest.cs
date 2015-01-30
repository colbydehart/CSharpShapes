using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpShape;

namespace UnitTestShape
{
    [TestClass]
    public class UnitTestTrapezoids
    {
        [TestMethod]
        public void TestTrapezoidConstructor()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(4, trapezoid.Height);
            Assert.AreEqual(8, trapezoid.Top);
            Assert.AreEqual(2, trapezoid.Bottom);
        }

        [TestMethod]
        public void TrapezoidConstructorCalculatesAngles()
        {
            Trapezoid trapezoid = new Trapezoid(10, 4, 4);
            Assert.AreEqual(trapezoid.AcuteAngle, (decimal)53.13);
            Assert.AreEqual(trapezoid.ObtuseAngle, (decimal)126.87);
        }

        [TestMethod]
        public void TrapezoidConstructorCalculatesAnglesAgain()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(trapezoid.AcuteAngle, (decimal)38.66);
            Assert.AreEqual(trapezoid.ObtuseAngle, (decimal)141.34);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidCannotBeRectangle()
        {
            Trapezoid trapezoid = new Trapezoid(40, 40, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksBase1()
        {
            Trapezoid trapezoid = new Trapezoid(0, 50, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksBase2()
        {
            Trapezoid trapezoid = new Trapezoid(50, 0, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksHeight()
        {
            Trapezoid trapezoid = new Trapezoid(50, 30, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksBasePositivity()
        {
            Trapezoid trapezoid = new Trapezoid(-1, 50, 30);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksBase2Positivity()
        {
            Trapezoid trapezoid = new Trapezoid(50, -1, 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidConstructorSanityChecksHeightPositivity()
        {
            Trapezoid trapezoid = new Trapezoid(50, 20, -20);
        }

        [TestMethod]
        public void TestScaleTrapezoid200Percent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(200);
            Assert.AreEqual(40, trapezoid.Height);
            Assert.AreEqual(20, trapezoid.Top);
            Assert.AreEqual(30, trapezoid.Bottom);
        }

        [TestMethod]
        public void TestScaleTrapezoid150Percent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(150);
            Assert.AreEqual((decimal)30, trapezoid.Height);
            Assert.AreEqual((decimal)15, trapezoid.Top);
            Assert.AreEqual((decimal)22.5, trapezoid.Bottom);
        }

        [TestMethod]
        public void TestScaleTrapezoid100Percent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(100);
            Assert.AreEqual(20, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoid37Percent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(37);
            Assert.AreEqual((decimal)7.4, trapezoid.Height);
        }

        [TestMethod]
        public void TestScaleTrapezoidUpAndDown()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(50);
            trapezoid.Scale(200);
            Assert.AreEqual(20, trapezoid.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleTrapezoidTo0Percent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestScaleTrapezoidToNegativePercent()
        {
            Trapezoid trapezoid = new Trapezoid(10, 15, 20);
            trapezoid.Scale(-5);
        }

        [TestMethod]
        public void TestSidesCount()
        {
            Trapezoid trapezoid = new Trapezoid(1, 5, 3);
            Assert.AreEqual(4, trapezoid.SidesCount);
        }

        [TestMethod]
        public void TestTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(1, 5, 3);
            Assert.AreEqual(9, trapezoid.Area());
        }

        [TestMethod]
        public void TestBiggerTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(10, 50, 30);
            Assert.AreEqual(900, trapezoid.Area());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(4, 10, 4);
            Assert.AreEqual(24, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestBiggerTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(40, 100, 40);
            Assert.AreEqual(240, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestDefaultColors()
        {
            Trapezoid shape = new Trapezoid(10, 15, 20);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }
    }
}
