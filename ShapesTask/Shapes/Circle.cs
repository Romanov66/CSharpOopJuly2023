namespace ShapesTask.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetHeight()
        {
            return Radius * 2;
        }

        public double GetWidth()
        {
            return Radius * 2;
        }

        public double GetArea()
        {
            return Radius * Radius * Math.PI;
        }

        public double GetPerimeter()
        {
            return Math.PI * Radius * 2;
        }

        public override string ToString()
        {
            return $"Круг с радиусом = {Radius}";
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

            Circle circle = (Circle)obj;

            return circle.Radius == Radius;
        }

        public override int GetHashCode()
        {
            return 37 * Radius.GetHashCode();
        }
    }
}