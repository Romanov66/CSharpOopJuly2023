namespace Academits.Romanov.IShapeTask
{
    public class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public override string GetShapeType()
        {
            return "Треугольник";
        }

        public override double GetWidth()
        {
            double[] xCoordinates = { X1, X2, X3 };

            double epsilon = 1.0e-10;

            double maxX = 0;
            double minX = xCoordinates[0];

            for (int i = 0; i < xCoordinates.Length; i++)
            {
                if (xCoordinates[i] - maxX > epsilon)
                {
                    maxX = xCoordinates[i];
                }
                else
                {
                    if (minX - xCoordinates[i] > epsilon)
                    {
                        minX = xCoordinates[i];
                    }
                }
            }

            return maxX - minX;
        }

        public override double GetHeight()
        {
            double[] xCoordinates = { Y1, Y2, Y3 };

            double epsilon = 1.0e-10;

            double maxY = 0;
            double minY = xCoordinates[0];

            for (int i = 0; i < xCoordinates.Length; i++)
            {
                if (xCoordinates[i] - maxY > epsilon)
                {
                    maxY = xCoordinates[i];
                }
                else
                {
                    if (minY - xCoordinates[i] > epsilon)
                    {
                        minY = xCoordinates[i];
                    }
                }
            }

            return maxY - minY;
        }

        public override double GetArea()
        {
            double side1Length = Math.Abs(Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1)));
            double side2Length = Math.Abs(Math.Sqrt((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1)));
            double side3Length = Math.Abs(Math.Sqrt((X3 - X2) * (X3 - X2) + (Y3 - Y2) * (Y3 - Y2)));

            double triangleSemiPerimeter = (side1Length + side2Length + side3Length) / 2;

            return Math.Sqrt(triangleSemiPerimeter * (triangleSemiPerimeter - side1Length) * (triangleSemiPerimeter - side2Length) * (triangleSemiPerimeter - side3Length));
        }

        public override double GetPerimeter()
        {
            double side1Length = Math.Abs(Math.Sqrt((X2 - X1) * (X2 - X1) + (Y2 - Y1) * (Y2 - Y1)));
            double side2Length = Math.Abs(Math.Sqrt((X3 - X1) * (X3 - X1) + (Y3 - Y1) * (Y3 - Y1)));
            double side3Length = Math.Abs(Math.Sqrt((X3 - X2) * (X3 - X2) + (Y3 - Y2) * (Y3 - Y2)));

            return side1Length + side2Length + side3Length;
        }
    }
}