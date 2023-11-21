using ShapesTask.Comparers;
using ShapesTask.Shapes;

namespace ShapesTask
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

            IShape[] shapes = { square1, square2, rectangle1, rectangle2, triangle1, circle1 };

            Console.WriteLine("Фигура с максимальной площадью: " + GetMaxArea(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром: " + GetSecondPerimeter(shapes));
        }

        public static IShape GetMaxArea(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                return null;
            }
            Array.Sort(shapes, new AreasComparer());

            return shapes[^1];
        }

        public static IShape GetSecondPerimeter(IShape[] shapes)
        {
            if (shapes.Length == 0)
            {
                return null;
            }

            Array.Sort(shapes, new PerimetersComparer());

            return shapes[^2];
        }
    }
}