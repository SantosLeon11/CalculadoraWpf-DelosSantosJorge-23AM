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

namespace CalculadoraWpf_DelosSantosJorge_23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("1");
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("2");
        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("3");
        }

        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("4");
        }

        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("5");
        }

        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("6");
        }

        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("7");
        }

        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("8");
        }

        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("9");
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers("0");
        }

        private void Punto_Click(object sender, RoutedEventArgs e)
        {
            HandleNumbers(".");
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            Screen.Text = "";
        }

        private void Borrar1_Click(object sender, RoutedEventArgs e)
        {
            if (Screen.Text.Length == 1)
                Screen.Text = "";
            else
            {
                if (Screen.Text.Length > 1)
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                else
                    Screen.Clear();
            }
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandleOperators("/");
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        private void Multiplicacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandleOperators("*");
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        private void Resta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandleOperators("-");
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        private void Suma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandleOperators("+");
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HandleEquals(Screen.Text);
            }
            catch (Exception)
            {

                throw (new Exception("ERROR"));
            }
        }
        private void HandleNumbers(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;
            }
        }
        private void HandleOperators(string value)
        {
            if (!String.IsNullOrEmpty(Screen.Text) && !ContainsOtherOperators(Screen.Text))
            {
                Screen.Text += value;
            }
        }
        private bool IsOperator(string PosOperador)
        {
            if (PosOperador == "+" || PosOperador == "-" || PosOperador == "*" || PosOperador == "/" || PosOperador == "%")
            {
                return true;
            }
            return PosOperador == "+" || PosOperador == "-" || PosOperador == "*" || PosOperador == "/" || PosOperador == "%";
        }
        private bool ContainsOtherOperators(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-") || screenContent.Contains("*") || screenContent.Contains("/") || screenContent.Contains("%");
        }
        private string FindOperador(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return screenContent;
        }
        private void HandleEquals(string screenContent)
        {
            string op = FindOperador(screenContent);
            if (!String.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;
                    case "-":
                        Screen.Text = Rest();
                        break;
                    case "*":
                        Screen.Text = Mult();
                        break;
                    case "/":
                        Screen.Text = Div();
                        break;
                }
            }
        }
        private string Sum()
        {
            string[] numbers = Screen.Text.Split("+");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 + n2, 12).ToString();
        }
        private string Rest()
        {
            string[] numbers = Screen.Text.Split("-");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 - n2, 12).ToString();
        }
        private string Mult()
        {
            string[] numbers = Screen.Text.Split("*");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 * n2, 12).ToString();
        }
        private string Div()
        {
            string[] numbers = Screen.Text.Split("/");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 / n2, 12).ToString();
        }
        private string Porcent()
        {
            string[] numbers = Screen.Text.Split("%");
            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);
            return Math.Round(n1 % n2, 12).ToString();
        }
    }
}
