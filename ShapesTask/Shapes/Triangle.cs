namespace ShapesTask.Shapes
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

        public double GetWidth()
        {
            return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }

        public double GetArea()
        {
            double firstSideLength = GetSideLength(X1, Y1, X2, Y2);
            double secondSideLength = GetSideLength(X1, Y1, X3, Y3);
            double thirdSideLength = GetSideLength(X2, Y2, X3, Y3);

            double triangleSemiPerimeter = (firstSideLength + secondSideLength + thirdSideLength) / 2;

            return Math.Sqrt(triangleSemiPerimeter * (triangleSemiPerimeter - firstSideLength) * (triangleSemiPerimeter - secondSideLength) * (triangleSemiPerimeter - thirdSideLength));
        }

        public double GetPerimeter()
        {
            double firstSideLength = GetSideLength(X1, Y1, X2, Y2);
            double secondSideLength = GetSideLength(X1, Y1, X3, Y3);
            double thirdSideLength = GetSideLength(X2, Y2, X3, Y3);

            return firstSideLength + secondSideLength + thirdSideLength;
        }

        public override string ToString()
        {
            return $"Треугольник с координатами: ({X1}; {Y1}), ({X2}; {Y2}), ({X3}; {Y3})";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || GetType() != obj.GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return (X1 == triangle.X1) && (X2 == triangle.X2) && (X3 == triangle.X3)
                && (Y1 == triangle.Y1) && (Y2 == triangle.Y2) && (Y3 == triangle.Y3);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}