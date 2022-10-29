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
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1 || y2 < y1)
                throw new Exception("Invalid Rectangle: (X1, Y1) botom left coordinates and (X2, Y2) top rigth coodinates");

            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
            CalculateValues();
        }

        private void CalculateValues()
        {
            Width = X2 - X1;
            Height = Y2 - Y1;
            Area = Width * Height;
        }
    }
}
