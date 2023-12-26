namespace TemperatureTask.Model.Scales
{
    public interface IScale
    {
        string GetScaleName();

        double ConvertTo(double degree, FahrenheitScale scale);

        double ConvertTo(double degree, CelsiusScale scale);

        double ConvertTo(double degree, KelvinScale scale);
    }
}
