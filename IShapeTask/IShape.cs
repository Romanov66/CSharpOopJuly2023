namespace Academits.Romanov.IShapeTask
{
    public interface IShape
    {
        string GetShapeType();

        double GetWidth();

        double GetHeight();

        double GetArea();

        double GetPerimeter();
    }
}