namespace Academits.Romanov.IShapeTask
{
    public class Square : IShape
    {
        public double Height { get; set; }

        public Square(double height)
        {
            Height = height;
        }

        public override string GetShapeType()
        {
            return "Квадрат";
        }

        public override double GetHeight()
        {
            return Height;
        }

        public override double GetWidth()
        {
            return Height;
        }

        public override double GetArea()
        {
            return Height * Height;
        }

        public override double GetPerimeter()
        {
            return Height * 4;
        }
    }
}