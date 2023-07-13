namespace Academits.Romanov.IShapeTask
{
    public class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public string GetShapeType()
        {
            return "Квадрат";
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
    }
}