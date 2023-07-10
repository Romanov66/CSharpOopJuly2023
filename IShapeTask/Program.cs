using IShapeTask;

namespace Academits.Romanov.IShapeTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShape square1 = new Square(4);
            IShape square2 = new Square(6);

            IShape rectangle1 = new Rectangle(5, 7);
            IShape rectangle2 = new Rectangle(12, 18);

            IShape triangle1 = new Triangle(5, 9, 12, 9, 9, 30);

            IShape circle1 = new Circle(13);

            IShape[] shapes = new IShape[] { square1, square2, rectangle1, rectangle2, triangle1, circle1 };

            IShape shape1 = GetShapeMaxArea(shapes);
            IShape shape2 = GetSecondShapeAlongPerimeter(shapes);

            Console.WriteLine($"Максимальная площадь фигуры массива: {shape1.GetArea()}, тип фигуры: {shape1.GetShapeType()}, ширина фигуры: {shape1.GetWidth()}, высота фигуры: {shape1.GetHeight()}.");
            Console.WriteLine($"Вторая величина периметра фигуры массива: {shape2.GetArea()}, тип фигуры: {shape2.GetShapeType()}, ширина фигуры: {shape2.GetWidth()}, высота фигуры: {shape2.GetHeight()}.");
        }

        public static IShape GetShapeMaxArea(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapeAreaComparer());

            return shapes[^1];
        }

        public static IShape GetSecondShapeAlongPerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapePerimeterComparer());

            return shapes[^2];
        }
    }
}