namespace Academits.Romanov.IShapeTask
{
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string GetShapeType()
        {
            return "Круг";
        }

        public override double GetHeight()
        {
            return Radius * 2;
        }

        public override double GetWidth()
        {
            return Radius * 2;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return Math.PI * Radius * 2;
        }
    }
}