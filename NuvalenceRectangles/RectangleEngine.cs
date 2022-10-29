﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NuvalenceRectangles
{
    public class RectangleEngine
    {
        public Rectangle RectangleA { get; set; }
        public Rectangle RectangleB { get; set; }
        public Rectangle IntersectionRentangle { get; set; }
        public bool SameWidth { get; set; }
        public bool SameHight { get; set; }
        public bool StartSamePointX { get; set; }
        public bool StartSamePointY { get; set; }
        public bool Containtment { get; set; }
        public bool Intersection { get; set; }
        public bool Adjacency { get; set; }
        public string IntersectionPoints { get; set; }
        public string AdjacencyType { get; set; }

        public RectangleEngine(Rectangle rectangleA, Rectangle rectangleB)
        {
            RectangleA = rectangleA;
            RectangleB = rectangleB;
            SameWidth = RectangleA.Width == RectangleB.Width;
            SameHight = RectangleA.Height == RectangleB.Height;
            StartSamePointX = RectangleA.X1 == RectangleB.X1;
            StartSamePointY = RectangleA.Y1 == RectangleB.Y1;
            CalculateIntersectionRectangleValues();
            Containtment = CalculateContainmentStatus();
            Adjacency = CalculateAdjacencyStatus();
            Intersection = CalculateIntersectionStatus();
            IntersectionPoints = GetIntersectionPoints();
            AdjacencyType = GetAdjacencyType();
        }
        private void CalculateIntersectionRectangleValues()
        {
            var X1 = Math.Max(RectangleA.X1, RectangleB.X1);
            var X2 = Math.Max(RectangleA.X2, RectangleB.X2);
            var Y1 = Math.Min(RectangleA.Y1, RectangleB.Y1);
            var Y2 = Math.Min(RectangleA.Y2, RectangleB.Y2);
            IntersectionRentangle = new Rectangle(X1, X2, Y1, Y2);
        }

        public bool CalculateContainmentStatus()
        {
            return AcontainsB() || BcontainsA();
        }

        public bool CalculateAdjacencyStatus()
        {
            return IntersectionRentangle.Area == 0;
        }

        public bool CalculateIntersectionStatus()
        {
            if (IntersectionRentangle.Area == 0)
                return false;

            return (IntersectionRentangle.X1 > IntersectionRentangle.X2) || (IntersectionRentangle.Y1 > IntersectionRentangle.Y2);
        }

        public string GetIntersectionPoints()
        {
            //TODO: return only the 2 pints where the interception happens
            return Intersection ? $"({IntersectionRentangle.X1},{IntersectionRentangle.Y1}) ({IntersectionRentangle.X1},{IntersectionRentangle.Y2}) ({IntersectionRentangle.X2},{IntersectionRentangle.Y1}) ({IntersectionRentangle.X2},{IntersectionRentangle.Y2})" : "NO INTERSECTION";
        }

        public string GetAdjacencyType()
        {
            if (Adjacency)
            {
                string adjacencyType;
                string adjacencyAxis;

                adjacencyAxis = IntersectionRentangle.X1 == IntersectionRentangle.X2 ? "Y" : "X";

                if (adjacencyAxis == "Y")
                {
                    if (SameHight && StartSamePointY)
                        adjacencyType = "Adjacency (proper)";
                    else if (SameHight && !StartSamePointY)
                        adjacencyType = "Adjacency (partial)";
                    else
                        adjacencyType = "Adjacency (sub-line)";
                }
                else
                {
                    if (SameWidth && StartSamePointX)
                        adjacencyType = "Adjacency (proper)";
                    else if (SameWidth && !StartSamePointX)
                        adjacencyType = "Adjacency (partial)";
                    else
                        adjacencyType = "Adjacency (sub-line)";
                }

                return adjacencyType;
            }

            return "NO ADJACENCY";
        }

        public bool AcontainsB()
        {
            return RectangleA.X1 <= RectangleB.X1
                && RectangleB.X2 <= RectangleA.X2
                && RectangleA.Y1 <= RectangleB.Y1
                && RectangleB.Y2 <= RectangleA.Y2;
        }

        public bool BcontainsA()
        {
            return RectangleB.X1 <= RectangleA.X1
                && RectangleA.X2 <= RectangleB.X2
                && RectangleB.Y1 <= RectangleA.Y1
                && RectangleA.Y2 <= RectangleB.Y2;
        }
    }
}
