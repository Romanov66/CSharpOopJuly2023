using ShapesTask.Shapes;

namespace ShapesTask.Comparers
{
    public class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1 is null)
            {
                throw new ArgumentException("Параметр не может быть null", nameof(shape1));
            }

            if (shape2 is null)
            {
                throw new ArgumentException("Параметр не может быть null", nameof(shape2));
            }

            return shape1.GetArea().CompareTo(shape2.GetArea());
        }
    }
}