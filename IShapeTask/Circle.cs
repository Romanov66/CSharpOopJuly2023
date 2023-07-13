namespace Academits.Romanov.IShapeTask
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public string GetShapeType()
        {
            return "Круг";
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
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return Math.PI * Radius * 2;
        }
    }
}