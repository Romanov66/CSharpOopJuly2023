namespace Academits.Romanov.IShapeTask
{
    public class Square : IShape
    {
        public double SideLenght { get; set; }

        public Square(double sideLenght)
        {
            SideLenght = sideLenght;
        }

        public string GetShapeType()
        {
            return "Квадрат";
        }

        public double GetHeight()
        {
            return SideLenght;
        }

        public double GetWidth()
        {
            return SideLenght;
        }

        public double GetArea()
        {
            return SideLenght * SideLenght;
        }

        public double GetPerimeter()
        {
            return SideLenght * 4;
        }
    }
}