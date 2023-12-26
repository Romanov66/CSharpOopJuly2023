namespace TemperatureTask.Model.Scales
{
    public class FahrenheitScale : IScale
    {
        public const string scaleName = "Градус Фаренгейта";

        public string GetScaleName()
        {
            return scaleName;
        }
        
        public double ConvertTo(double degree, FahrenheitScale scale)
        {
            return degree;
        }

        public double ConvertTo(double degree, CelsiusScale scale)
        {
            return (degree - 32) * (5.0 / 9);
        }

        public double ConvertTo(double degree, KelvinScale scale)
        {
            return (degree - 32) * (5.0 / 9) + 273.15;
        }
    }
}
