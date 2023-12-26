using TemperatureTask.Model.Scales;

namespace TemperatureTask.Model
{
    public class Model
    {
        private static readonly IScale[] Scales = { new FahrenheitScale(), new CelsiusScale(), new KelvinScale() };

        public static double CalculateTemperature(double dergee, IScale scaleFrom, IScale scaleTo)
        {
            return scaleFrom.ConvertTo(dergee, scaleTo);
        }

        public static IScale GetScale(string data)
        {
            IScale? scale = null;

            for (int i = 0; i < Scales.Length; i++)
            {
                string itemName = Scales[i].GetScaleName();

                if (data == itemName)
                {
                    scale = Scales[i];
                }
            }

            return scale!;
        }

        public static double ConvertToDouble(string data)
        {
            double result = 0;

            try
            {
                result = Convert.ToDouble(data);
            }
            catch
            {
                MessageBox.Show("Значение должно быть числом.", "Справка");
            }

            return result;
        }
    }
}
