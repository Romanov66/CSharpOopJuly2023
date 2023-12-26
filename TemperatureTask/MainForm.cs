using TemperatureTask.Model.Scales;

namespace TemperatureTask
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void conversion_Click(object sender, EventArgs e)
        {
            if (inputText.Text.Length == 0 || fromComboBox.Text.Length == 0 || toComboBox.Text.Length == 0)
            {
                MessageBox.Show("Заполните все необходимые поля.", "Справка");

                return;
            }

            double degree = Model.Model.ConvertToDouble(inputText.Text);
            IScale scale1 = Model.Model.GetScale(fromComboBox.Text);
            IScale scale2 = Model.Model.GetScale(toComboBox.Text);

            outputText.Text = Model.Model.CalculateTemperature(degree, scale1, scale2).ToString();
        }
    }
}