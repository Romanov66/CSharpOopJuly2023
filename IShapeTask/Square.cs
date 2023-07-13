namespace Academits.Romanov.IShapeTask
{
    public class Square : IShape
    {
        public double sideLenght { get; set; }

        public Square(double height)
        {
            sideLenght = sideLenght;
        }

        public string GetShapeType()
        {
            return "Квадрат";
        }

        public double GetHeight()
        {
            return sideLenght;
        }

        public double GetWidth()
        {
            return sideLenght;
        }

        public double GetArea()
        {
            return sideLenght * sideLenght;
        }

        public double GetPerimeter()
        {
            return sideLenght * 4;
        }
    }
}