using System;
using System.Collections.Generic;
using System.Linq;
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
        public Rectangle(string coordinates)
        {
            var values = coordinates.Split(',');
            if (values.Count() != 4)
                throw new Exception("Invalid Coordinates");

            X1 = int.Parse(values[0]);
            Y1 = int.Parse(values[1]);
            X2 = int.Parse(values[2]);
            Y2 = int.Parse(values[3]);
            InvalidRectangle = X2 < X1 || Y2 < Y1;
        }
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
