namespace Academits.Romanov.IShapeTask
{
    public class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x is null || y is null)
            {
                throw new Exception("Некорректное значение параметра");
            }

            double xArea = x.GetArea();
            double yArea = y.GetArea();

            if (xArea > yArea)
            {
                return 1;
            }

            if (xArea < yArea)
            {
                return -1;
            }

            return 0;
        }
    }
}