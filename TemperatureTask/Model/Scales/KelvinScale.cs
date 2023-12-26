namespace TemperatureTask.Model.Scales
{
    public class KelvinScale : IScale
    {
        public const string ItemName = "Кельвин";

        public string GetScaleName()
        {
            return ItemName;
        }

        public double Convert(double degree, KelvinScale scale)
        {
            return degree;
        }

        public double Convert(double degree, FahrenheitScale scale)
        {
            return degree * (9.0 / 5) - 459.67;
        }

        public double Convert(double degree, CelsiusScale scale)
        {
            return degree - 273.15;
        }
    }
}
