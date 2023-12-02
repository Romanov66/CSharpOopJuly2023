namespace TemperatureTask
{
    public partial class MainForm : Form
    {
        private const double ratioFahrenheitCelsius = (double)9 / 5;
        private const double ratioCelsiusFahrenheit = (double)5 / 9;
        private const double zeroDegreesByKelvin = 273.15;
        private const double zeroDegreesByFahrenheit = 32;

        public MainForm()
        {
            InitializeComponent();
        }

        private double ConvertToDouble()
        {
            double result = 0;

            try
            {
                result = Convert.ToDouble(inputText.Text);
            }
            catch
            {
                MessageBox.Show("Значение должно быть числом.", "Справка");
            }

            return result;
        }

        private void GetFahrenheitToKelvinConversion()
        {
            double fahrenheitDegrees = ConvertToDouble();

            outputText.Text = ((fahrenheitDegrees - zeroDegreesByFahrenheit) * ratioCelsiusFahrenheit + zeroDegreesByKelvin).ToString();
        }

        private void GetFahrenheitToCelsiusConversion()
        {
            double fahrenheitDegrees = ConvertToDouble();

            outputText.Text = ((fahrenheitDegrees - zeroDegreesByFahrenheit) * ratioCelsiusFahrenheit).ToString();
        }

        private void GetCelsiusToKelvinConversion()
        {
            double celsiusDegrees = ConvertToDouble();

            outputText.Text = (celsiusDegrees + zeroDegreesByKelvin).ToString();
        }

        private void GetCelsiusToFahrenheitConversion()
        {
            double celsiusDegrees = ConvertToDouble();

            outputText.Text = (celsiusDegrees * ratioFahrenheitCelsius + 32).ToString();
        }

        private void GetKelvinToCelsiusConversion()
        {
            double kelvinDegrees = ConvertToDouble();

            outputText.Text = (kelvinDegrees - zeroDegreesByKelvin).ToString();
        }

        private void GetKelvinToFahrenheitConversion()
        {
            double kelvinDegrees = ConvertToDouble();

            outputText.Text = (kelvinDegrees * ratioFahrenheitCelsius - 459.67).ToString();
        }

        private void conversion_Click(object sender, EventArgs e)
        {
            if (inputText.Text.Length == 0 || fromComboBox.Text.Length == 0 || toComboBox.Text.Length == 0)
            {
                MessageBox.Show("Заполните все необходимые поля.", "Справка");

                return;
            }

            if (fromComboBox.Text == fromComboBox.Items[0].ToString())
            {
                if (toComboBox.Text == toComboBox.Items[0].ToString())
                {
                    outputText.Text = inputText.Text;
                }
                else if (toComboBox.Text == toComboBox.Items[1].ToString())
                {
                    GetCelsiusToFahrenheitConversion();
                }
                else
                {
                    GetCelsiusToKelvinConversion();
                }
            }
            else if (fromComboBox.Text == fromComboBox.Items[1].ToString())
            {
                if (toComboBox.Text == toComboBox.Items[1].ToString())
                {
                    outputText.Text = inputText.Text;
                }
                else if (toComboBox.Text == toComboBox.Items[0].ToString())
                {
                    GetFahrenheitToCelsiusConversion();
                }
                else
                {
                    GetFahrenheitToKelvinConversion();
                }
            }
            else
            {
                if (toComboBox.Text == toComboBox.Items[2].ToString())
                {
                    outputText.Text = inputText.Text;
                }
                else if (toComboBox.Text == toComboBox.Items[0].ToString())
                {
                    GetKelvinToCelsiusConversion();
                }
                else
                {
                    GetKelvinToFahrenheitConversion();
                }
            }
        }
    }
}