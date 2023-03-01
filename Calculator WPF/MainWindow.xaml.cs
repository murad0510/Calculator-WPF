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

namespace Calculator_WPF
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

        bool IsPositife = true;
        bool txtClear = true;
        double result = 0;
        string operatorResult = "";
        bool Oper = true;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtClear)
            {
                Netice.Clear();
            }

            if (Netice.Text.StartsWith("0"))
            {
                if (Oper)
                {
                    Netice.Text += '.';
                    Oper = false;
                }
            }

            txtClear = false;

            Button button = sender as Button;
            if (button.Content.ToString() == ".")
            {
                if (!Netice.Text.Contains("."))
                {
                    Netice.Text += button.Content;
                }
            }
            else
            {
                Netice.Text += button.Content;
            }

            if (Netice.Text.StartsWith("."))
            {
                var text = "";
                Netice.Text = text;
                Netice.Text += "0.";
                Oper = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Content.ToString();

            txtClear = true;
            Oper = true;

            if (operatorResult == "+")
            {
                Netice.Text = (result + Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "-")
            {
                Netice.Text = (result - Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "×")
            {
                Netice.Text = (result * Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "÷")
            {
                if (Netice.Text != "0")
                {
                    Netice.Text = (result / Double.Parse(Netice.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("0-a bolme yoxdur");
                }
            }
            else if (operatorResult == "%")
            {
                Netice.Text = (result / 100).ToString();
            }

            result = Double.Parse(Netice.Text);
            oprationView.Content = Netice.Text + " " + newOperator;
            Netice.Text = result.ToString();
            operatorResult = newOperator;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            txtClear = true;
            Netice.Text = "0";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Netice.Text = Netice.Text.Remove(Netice.Text.Length - 1);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            txtClear = true;
            oprationView.Content = "0";
            Netice.Text = "0";
            result = 0;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            oprationView.Content = "";

            if (operatorResult == "+")
            {
                Netice.Text = (result + Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "−")
            {
                Netice.Text = (result - Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "×")
            {
                Netice.Text = (result * Double.Parse(Netice.Text)).ToString();
            }
            else if (operatorResult == "÷")
            {
                if (Netice.Text != "0")
                {
                    Netice.Text = (result / Double.Parse(Netice.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("0-a bolme yoxdur");
                }
            }
            else if (operatorResult == "%")
            {
                Netice.Text = (result / 100).ToString();
            }

            result = Double.Parse(Netice.Text);
            Netice.Text = result.ToString();
            operatorResult = "";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (IsPositife)
            {
                Netice.Text = (Double.Parse(Netice.Text) * -1).ToString();
            }
            else
            {
                Netice.Text = (Double.Parse(Netice.Text) * -1).ToString();
            }
            IsPositife = !IsPositife;
        }
    }
}
