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

            Console.WriteLine("Фигура с максимальной площадью: " + GetShapeWithMaxArea(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром: " + GetShapeWithSecondPerimeter(shapes));
        }

        public static IShape GetShapeWithMaxArea(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                return null;
            }

            Array.Sort(shapes, new AreasComparer());

            return shapes[^1];
        }

        public static IShape GetShapeWithSecondPerimeter(IShape[] shapes)
        {
            if (shapes.Length <= 1)
            {
                return null;
            }

            Array.Sort(shapes, new PerimetersComparer());

            return shapes[^2];
        }
    }
}