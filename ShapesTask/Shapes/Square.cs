namespace ShapesTask.Shapes
{
    public class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double GetHeight()
        {
            return Side;
        }

        public double GetWidth()
        {
            return Side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public double GetPerimeter()
        {
            return Side * 4;
        }

        public override string ToString()
        {
            return $"Квадрат с длиной сторон = {Side}";
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

            return square.Side == Side;
        }

        public override int GetHashCode()
        {
            return 37 * Side.GetHashCode();
        }
    }
}