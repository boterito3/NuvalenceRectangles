using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuvalenceRectangles;

namespace NuvalanceRectangles.Tests
{
    [TestClass]
    public class RectangleEngineTests
    {
        [TestMethod]
        public void CalculateIntersectionStatus_IntersectedRectangles_True()
        {
            //Arrange
            var rectangleA = new Rectangle(5, 2, 9, 5);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateIntersectionStatus();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateIntersectionStatus_NotIntersectedRectangles_False()
        {
            //Arrange
            var rectangleA = new Rectangle(2, 6, 3, 8);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateIntersectionStatus();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateContainmentStatus_ContainedRectangles_True()
        {
            //Arrange
            var rectangleA = new Rectangle(10, 1, 13, 5);
            var rectangleB = new Rectangle(10, 1, 12, 3);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateContainmentStatus();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateContainmentStatus_NotContainedRectangles_False()
        {
            //Arrange
            var rectangleA = new Rectangle(5, 2, 9, 5);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateContainmentStatus();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CalculateAdjacencyStatus_AdjacentRectangles_True()
        {
            //Arrange
            var rectangleA = new Rectangle(1, 3, 5, 4);
            var rectangleB = new Rectangle(5, 2, 9, 5);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateAdjacencyStatus();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CalculateAdjacencyStatus_NotAdjacentRectangles_False()
        {
            //Arrange
            var rectangleA = new Rectangle(5, 2, 9, 5);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            var result = engine.CalculateAdjacencyStatus();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetIntersectionPoints_IntersectedRectangles_ValidCoordinates()
        {
            //Arrange
            var rectangleA = new Rectangle(5, 2, 9, 5);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.Intersection = engine.CalculateIntersectionStatus();
            var result = engine.GetIntersectionPoints();

            //Assert
            Assert.AreEqual(result, "(5,3) (5,4) (6,3) (6,4)");
        }

        [TestMethod]
        public void GetIntersectionPoints_NotIntersectedRectangles_NoIntersection()
        {
            //Arrange
            var rectangleA = new Rectangle(2, 6, 3, 8);
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.Intersection = engine.CalculateIntersectionStatus();
            var result = engine.GetIntersectionPoints();

            //Assert
            Assert.AreEqual(result, "NO INTERSECTION");
        }

        [TestMethod]
        public void GetAdjacencyType_AdjacentRectangles_SubLine()
        {
            //Arrange
            var rectangleA = new Rectangle(1, 3, 5, 4);
            var rectangleB = new Rectangle(5, 2, 9, 5);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.Adjacency = engine.CalculateAdjacencyStatus();
            var result = engine.GetAdjacencyType();

            //Assert
            Assert.AreEqual(result, "subline");
        }

        [TestMethod]
        public void GetAdjacencyType_AdjacentRectangles_Proper()
        {
            //Arrange
            var rectangleA = new Rectangle(1, 2, 5, 5);
            var rectangleB = new Rectangle(5, 2, 9, 5);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.Adjacency = engine.CalculateAdjacencyStatus();
            var result = engine.GetAdjacencyType();

            //Assert
            Assert.AreEqual(result, "proper");
        }

        [TestMethod]
        public void GetAdjacencyType_AdjacentRectangles_Partial()
        {
            //Arrange
            var rectangleA = new Rectangle(1, 3, 5, 6);
            var rectangleB = new Rectangle(5, 2, 9, 5);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.Adjacency = engine.CalculateAdjacencyStatus();
            var result = engine.GetAdjacencyType();

            //Assert
            Assert.AreEqual(result, "partial");
        }

        [TestMethod]
        public void IntegrationTest_IntersectedRectangles_True_False_False()
        {
            //Arrange
            var rectangleB = new Rectangle(2, 3, 6, 4);
            var rectangleA = new Rectangle(5, 2, 9, 5);
            var engine = new RectangleEngine(rectangleA, rectangleB);

            //Act
            engine.RunFeaturesAnalysis();

            //Assert
            Assert.IsTrue(engine.Intersection);
            Assert.IsFalse(engine.Containtment);
            Assert.IsFalse(engine.Adjacency);
            Assert.AreEqual(engine.IntersectionPoints, "(5,3) (5,4) (6,3) (6,4)");
            Assert.AreEqual(engine.AdjacencyType, "NO ADJACENCY");
        }
    }
}
