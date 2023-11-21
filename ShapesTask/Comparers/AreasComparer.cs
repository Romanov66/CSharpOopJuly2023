namespace ShapesTask.Comparers
{
    public class AreasComparer : IComparer<IShape>
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

            double shape1Area = shape1.GetArea();
            double shape2Area = shape2.GetArea();

            return shape1Area.CompareTo(shape2Area);
        }
    }
}