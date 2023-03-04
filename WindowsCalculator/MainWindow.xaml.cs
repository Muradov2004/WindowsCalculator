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

namespace WindowsCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char process = ' ';
        double number = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            TextBox.Text = "0";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (process == '=')
            {
                number = 0;
                process = ' ';
            }
            if (TextBox.Text == "0")
                TextBox.Text = button.Content.ToString();
            else if (process != ' ')
                TextBox.Text = button.Content.ToString();
            else
                TextBox.Text += button.Content;
        }
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBox.Text.Contains('.'))
                TextBox.Text += btnDot.Content;

        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.Text.Length > 0)
                TextBox.Text = TextBox.Text.Remove(TextBox.Text.Length - 1, 1);
            if (TextBox.Text.Length == 0)
            {
                number = 0;
                process = ' ';
            }
        }

        private void CheckProcess()
        {
            if (number == 0)
                number = double.Parse(TextBox.Text);
            else
                switch (process)
                {
                    case '+':
                        number += double.Parse(TextBox.Text);
                        break;
                    case '-':
                        number -= double.Parse(TextBox.Text);
                        break;
                    case '/':
                        number /= double.Parse(TextBox.Text);
                        break;
                    case '*':
                        number *= double.Parse(TextBox.Text);
                        break;
                    case '^':
                        number *= number;
                        break;
                    case '#':
                        number = Math.Sqrt(double.Parse(TextBox.Text));
                        break;
                    case '?':
                        number = 1 / (double.Parse(TextBox.Text));
                        break;
                    default:
                        break;
                }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '+';
            Label.Content = process;
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '*';
            Label.Content = process;
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '/';
            Label.Content = process;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '-';
            Label.Content = process;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            CheckProcess();
            process = '=';
            Label.Content = process;
            TextBox.Text = number.ToString();
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            number = double.Parse(TextBox.Text);
            process = '^';
            Label.Content = "power";
            CheckProcess();
            TextBox.Text = number.ToString();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            number = double.Parse(TextBox.Text);
            process = '#';
            Label.Content = "sqrt";
            CheckProcess();
            TextBox.Text = number.ToString();
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            Label.Content = "%";
            if (process == ' ')
                TextBox.Text = "0";
            else
                number = (double.Parse(TextBox.Text) / number) * 100;
            TextBox.Text = number.ToString();
        }

        private void bntOneDivivdedBy_Click(object sender, EventArgs e)
        {
            Label.Content = "1/x";
            number = double.Parse(TextBox.Text);
            process = '?';
            CheckProcess();
            TextBox.Text = number.ToString();
        }

        private void btnPlusMinus_Click(Object sender, EventArgs e)
        {
            Label.Content = "-/+";
            if (double.Parse(TextBox.Text) > 0)
                TextBox.Text = TextBox.Text.Insert(0, "-");
            else
                TextBox.Text = (0 - double.Parse(TextBox.Text)).ToString();
        }

    }
}
