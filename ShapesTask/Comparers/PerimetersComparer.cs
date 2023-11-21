namespace ShapesTask.Comparers
{
    public class PerimetersComparer : IComparer<IShape>
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

            double shape1Perimeter = shape1.GetPerimeter();
            double shape2Perimeter = shape2.GetPerimeter();

            return shape1Perimeter.CompareTo(shape2Perimeter);
        }
    }
}