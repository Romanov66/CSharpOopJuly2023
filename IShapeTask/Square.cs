namespace Academits.Romanov.IShapeTask
{
    public class Square : IShape
    {
        public double Height { get; set; }

        public Square(double height)
        {
            Height = height;
        }

        public string GetShapeType()
        {
            return "Квадрат";
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetWidth()
        {
            return Height;
        }

        public double GetArea()
        {
            return Height * Height;
        }

        public double GetPerimeter()
        {
            return Height * 4;
        }
    }
}