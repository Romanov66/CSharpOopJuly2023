using ShapesTask.Shapes;

namespace ShapesTask.Comparers
{
    public class PerimetersComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1 is null)
            {
                throw new ArgumentNullException(nameof(shape1), "Параметр не может быть null");
            }

            if (shape2 is null)
            {
                throw new ArgumentNullException(nameof(shape2), "Параметр не может быть null");
            }

            return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
        }
    }
}