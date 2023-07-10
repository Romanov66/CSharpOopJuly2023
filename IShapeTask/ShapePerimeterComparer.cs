using Academits.Romanov.IShapeTask;

namespace IShapeTask
{
    public class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            if (x is null || y is null)
            {
                throw new Exception("Некорректное значение параметра");
            }

            double xArea = x.GetPerimeter();
            double yArea = y.GetPerimeter();

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