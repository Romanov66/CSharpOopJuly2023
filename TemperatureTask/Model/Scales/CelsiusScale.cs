﻿namespace TemperatureTask.Model.Scales
{
    public class CelsiusScale : IScale
    {
        public const string ItemName = "Градус Цельсия";

        public string GetScaleName()
        {
            return ItemName;
        }

        public double Convert(double degree, CelsiusScale scale)
        {
            return degree;
        }

        public double Convert(double degree, FahrenheitScale scale)
        {
            return degree * (9.0 / 5) + 32;
        }

        public double Convert(double degree, KelvinScale scale)
        {
            return degree + 273.15;
        }
    }
}
