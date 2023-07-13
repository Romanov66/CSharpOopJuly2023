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

        public string GetShapeType()
        {
            return "Прямоугольник";
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetArea()
        {
            return Height * Width;
        }

        public double GetPerimeter()
        {
            return (Height + Width) * 2;
        }
    }
}