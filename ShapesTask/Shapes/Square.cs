namespace ShapesTask.Shapes
{
    public class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetHeight()
        {
            return SideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return SideLength * SideLength;
        }

        public double GetPerimeter()
        {
            return SideLength * 4;
        }

        public override string ToString()
        {
            return $"Квадрат с длиной сторон = {SideLength}";
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

            Square square = (Square)obj;

            return square.SideLength == SideLength;
        }

        public override int GetHashCode()
        {
            return SideLength.GetHashCode();
        }
    }
}