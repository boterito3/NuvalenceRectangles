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
        public void InvalidCoordinates_InvalidRectangle()
        {
            //Arrange - Act
            var rectangle = new Rectangle(2, 3, 1, 4);
        }

        [TestMethod]
        public void PositiveCoordinates_ValidRectangle()
        {
            //Arrange - Act
            var rectangle = new Rectangle(2, 3, 6, 4);

            //Assert
            Assert.AreEqual(rectangle.Width, 4);
            Assert.AreEqual(rectangle.Height, 1);
            Assert.AreEqual(rectangle.Area, 4);
        }

        [TestMethod]
        public void NegativeCoordinates_ValidRectangle()
        {
            //Arrange - Act
            var rectangle = new Rectangle(-2, 1, 6, 4);

            //Assert
            Assert.AreEqual(rectangle.Width, 8);
            Assert.AreEqual(rectangle.Height, 3);
            Assert.AreEqual(rectangle.Area, 24);
        }
    }
}
