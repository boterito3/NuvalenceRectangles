using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuvalenceRectangles;
using System;

namespace NuvalanceRectangles.Tests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Constructor_InvalidCoordinates_Exception()
        {
            //Arrange - Act
            var rectangle = new Rectangle("2,3");
        }

        [TestMethod]
        public void Constructor_ValidCoordinates_Exception()
        {
            //Arrange - Act
            var rectangle = new Rectangle("2,3,1,4");

            //Assert
            Assert.AreEqual(rectangle.X1, 2);
            Assert.AreEqual(rectangle.Y1, 3);
            Assert.AreEqual(rectangle.X2, 1);
            Assert.AreEqual(rectangle.Y2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CalculateValues_InvalidCoordinates_Exception()
        {
            //Arrange 
            var rectangle = new Rectangle(2, 3, 1, 4);

            //Act
            rectangle.CalculateValues();
        }        

        [TestMethod]
        public void CalculateValues_PositiveCoordinates_ValidRectangle()
        {
            //Arrange - Act
            var rectangle = new Rectangle(2, 3, 6, 4);

            //Act
            rectangle.CalculateValues();

            //Assert
            Assert.AreEqual(rectangle.Width, 4);
            Assert.AreEqual(rectangle.Height, 1);
            Assert.AreEqual(rectangle.Area, 4);
        }

        [TestMethod]
        public void CalculateValues_NegativeCoordinates_ValidRectangle()
        {
            //Arrange - Act
            var rectangle = new Rectangle(-2, 1, 6, 4);

            //Act
            rectangle.CalculateValues();

            //Assert
            Assert.AreEqual(rectangle.Width, 8);
            Assert.AreEqual(rectangle.Height, 3);
            Assert.AreEqual(rectangle.Area, 24);
        }
    }
}
