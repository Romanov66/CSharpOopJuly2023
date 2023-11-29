using ShapesTask.Comparers;
using ShapesTask.Shapes;

namespace ShapesTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Square(4),
                new Rectangle(5, 7),
                new Triangle(5, 9, 12, 9, 9, 30),
                new Circle(13)
            };

            Console.WriteLine("Фигура с максимальной площадью: " + GetShapeByMaxArea(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром: " + GetShapeBySecondPerimeter(shapes));
        }

        public static IShape GetShapeByMaxArea(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                return null;
            }

            Array.Sort(shapes, new ShapeAreaComparer());

            return shapes[^1];
        }

        public static IShape GetShapeBySecondPerimeter(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                return null;
            }

            if (shapes.Length == 1)
            {
                return shapes[0];
            }

            Array.Sort(shapes, new ShapePerimeterComparer());

            return shapes[^2];
        }
    }
}