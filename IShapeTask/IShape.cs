namespace Academits.Romanov.IShapeTask
{
    public class IShape
    {
        public virtual string GetShapeType()
        {
            return "";
        }

        public virtual double GetWidth()
        {
            return 0;
        }

        public virtual double GetHeight()
        {
            return 0;
        }

        public virtual double GetArea()
        {
            return 0;
        }

        public virtual double GetPerimeter()
        {
            return 0;
        }
    }
}