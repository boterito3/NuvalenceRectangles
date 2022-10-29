using System;
using System.Collections.Generic;
using System.Text;

namespace NuvalenceRectangles
{    public class Rectangle
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Area { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool InvalidRectangle { get; set; }
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            InvalidRectangle = x2 < x1 || y2 < y1;
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public void CalculateValues()
        {
            if (InvalidRectangle)
                throw new Exception("Invalid Rectangle");

            Width = X2 - X1;
            Height = Y2 - Y1;
            Area = Width * Height;
        }
    }
}
