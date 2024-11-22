using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculator1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _result;
        private string _operation;
        private bool _operationPressed;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtDisplay.Text == "0" || _operationPressed)
                txtDisplay.Text = "";

            _operationPressed = false;
            Button button = (Button)sender;
            txtDisplay.Text += button.Content.ToString();
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            _operation = button.Content.ToString();
            _result = double.Parse(txtDisplay.Text);
            _operationPressed = true;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double secondOperand = double.Parse(txtDisplay.Text);
            switch (_operation)
            {
                case "+":
                    txtDisplay.Text = (_result + secondOperand).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (_result - secondOperand).ToString();
                    break;
                case "x":
                    txtDisplay.Text = (_result * secondOperand).ToString();
                    break;
                case "/":
                    if (secondOperand != 0)
                        txtDisplay.Text = (_result / secondOperand).ToString();
                    else
                        MessageBox.Show("Деление на ноль невозможно!");
                    break;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "0";
            _result = 0;
            _operation = string.Empty;
        }
    }
}
