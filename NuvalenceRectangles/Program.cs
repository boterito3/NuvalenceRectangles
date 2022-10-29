using System;
using System.Collections.Generic;

namespace NuvalenceRectangles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 4 numbers separated by comma (X1,Y1,X2,Y2) where (X1,Y1) represent bottom left coordinate and (X2,Y2) represent the top right coordinate of Rectangle A.");
            Console.WriteLine("ie: 2,3,6,4");
            Console.WriteLine("------------------------\n");
            var typedValue = Console.ReadLine();
            var rectangleA = new Rectangle(typedValue);

            Console.WriteLine("Now the values for Rectangle B.");
            Console.WriteLine("ie: 5,2,9,5");
            Console.WriteLine("------------------------\n");
            typedValue = Console.ReadLine();
            var rectangleB = new Rectangle(typedValue);

            var engine = new RectangleEngine(rectangleA, rectangleB);
            engine.RunFeaturesAnalysis();

            //Assert
            Console.WriteLine("------------------------\n");
            Console.WriteLine("RESULTS:\n");
            Console.WriteLine($"Intersection: {engine.Intersection}");
            Console.WriteLine($"Containtment: {engine.Containtment}");
            Console.WriteLine($"Adjacency: {engine.Adjacency}");
            Console.WriteLine($"Intersection Points: {engine.IntersectionPoints}");
            Console.WriteLine($"AdjacencyType: {engine.AdjacencyType}");
        }
    }
}
