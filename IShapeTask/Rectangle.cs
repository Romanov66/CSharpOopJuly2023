namespace Academits.Romanov.IShapeTask
{
    public class Rectangle : IShape
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public override string GetShapeType()
        {
            return "Прямоугольник";
        }

        public override double GetHeight()
        {
            return Height;
        }

        public override double GetWidth()
        {
            return Width;
        }

        public override double GetArea()
        {
            return Height * Width;
        }

        public override double GetPerimeter()
        {
            return (Height + Width) * 2;
        }
    }
}