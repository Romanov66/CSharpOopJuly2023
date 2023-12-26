namespace TemperatureTask.Model.Scales
{
    public interface IScale
    {
        string GetScaleName();

        double Convert(double degree, FahrenheitScale scale);

        double Convert(double degree, CelsiusScale scale);

        double Convert(double degree, KelvinScale scale);
    }
}
