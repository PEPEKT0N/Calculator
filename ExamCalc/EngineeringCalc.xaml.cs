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

namespace ExamCalc
{
    /// <summary>
    /// Логика взаимодействия для EngineeringCalc.xaml
    /// </summary>
    public partial class EngineeringCalc : Page
    {
        const double rad_to_deg = 180 / Math.PI;
        char op;
        public EngineeringCalc()
        {
            InitializeComponent();
        }
        private void operation_click()
        {
            result_display.Text = display.Text;
            display.Text = "0";
        }
        private void btn_one_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (display.Text == "0")
                display.Text = btn.Content.ToString();
            else
                display.Text += btn.Content.ToString();

        }

        private void btn_division_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '/';
        }

        private void btn_multiply_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '*';
        }

        private void btn_minus_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '-';
        }

        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '+';
        }

        private void btn_result_Click(object sender, RoutedEventArgs e)
        {
            switch (op)
            {
                case '/':
                    if (Double.Parse(display.Text) == 0.0)
                    {
                        MessageBox.Show("На ноль делить нельзя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        display.Text = "0";
                    }
                    else
                        display.Text = (Double.Parse(result_display.Text) / Double.Parse(display.Text)).ToString();
                    break;
                case '*':
                    display.Text = (Double.Parse(result_display.Text) * Double.Parse(display.Text)).ToString();
                    break;
                case '+':
                    display.Text = (Double.Parse(result_display.Text) + Double.Parse(display.Text)).ToString();
                    break;
                case '-':
                    display.Text = (Double.Parse(result_display.Text) - Double.Parse(display.Text)).ToString();
                    break;
                case '%':
                    display.Text = (Double.Parse(result_display.Text) * Double.Parse(display.Text) / 100.0).ToString();
                    break;
                case '^':
                    display.Text = (Math.Pow(Double.Parse(result_display.Text), Double.Parse(display.Text))).ToString();
                    break;
            }
            operation_click();
        }

        private void btn_sign_Click(object sender, RoutedEventArgs e)
        {
            display.Text = (Double.Parse(display.Text) * -1).ToString();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            result_display.Text = "0";
        }

        private void btn_dote_Click(object sender, RoutedEventArgs e)
        {
            if (display.Text.Contains(","))
            {
                return;
            }
            else display.Text += ",";

        }

        private void btn_percent_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '%';
        }

        private void btm_factorial_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(display.Text) <= 0)
            {
                MessageBox.Show("Число должно быть положительным", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int result = 1;
                for (int i = result; i <= Int32.Parse(display.Text); i++)
                {
                    result *= (int)i;
                }
                display.Text = result.ToString();
            }
        }

        private void btn_x_Pow_minusOne_Click(object sender, RoutedEventArgs e)
        {
            display.Text = (Math.Pow(Double.Parse(display.Text), -1)).ToString();
            
        }

        private void btn_pow2_Click(object sender, RoutedEventArgs e)
        {
            display.Text = (Math.Pow(Double.Parse(display.Text), 2)).ToString();
        }

        private void btn_powN_Click(object sender, RoutedEventArgs e)
        {
            operation_click();
            op = '^';
        }

        private void btn_log_Click(object sender, RoutedEventArgs e)
        {
            display.Text = (Math.Log10(Double.Parse(display.Text))).ToString();
        }

        private void btn_ln_Click(object sender, RoutedEventArgs e)
        {            
            display.Text = (Math.Log(Double.Parse(display.Text))).ToString();            
        }

        private void btn_exp_Click(object sender, RoutedEventArgs e)
        {
            display.Text = Math.E.ToString();
        }

        private void btn_pi_Click(object sender, RoutedEventArgs e)
        {
            display.Text = Math.PI.ToString();
        }

        private void btn_sin_Click(object sender, RoutedEventArgs e)
        {
            if (btn_switch_grad.IsChecked == true)
            {
                result_display.Text = Math.Sin(Double.Parse(display.Text) / rad_to_deg).ToString();
            }
            else
            {
                result_display.Text = Math.Sin(Double.Parse(display.Text)).ToString();
            }
        }

        private void btn_cos_Click(object sender, RoutedEventArgs e)
        {
            if (btn_switch_grad.IsChecked == true)
            {
                result_display.Text = Math.Cos(Double.Parse(display.Text) / rad_to_deg).ToString();
            }
            else
            {
                result_display.Text = Math.Cos(Double.Parse(display.Text)).ToString();
            }
        }

        private void btn_tan_Click(object sender, RoutedEventArgs e)
        {
            if (btn_switch_grad.IsChecked == true)
            {
                result_display.Text = Math.Tan(Double.Parse(display.Text) / rad_to_deg).ToString();
            }
            else
            {
                result_display.Text = Math.Tan(Double.Parse(display.Text)).ToString();
            }
        }

        private void btn_cot_Click(object sender, RoutedEventArgs e)
        {
            if (btn_switch_grad.IsChecked == true)
            {
                result_display.Text = Math.Pow(Math.Tan(Double.Parse(display.Text) / rad_to_deg), -1).ToString();
            }
            else
            {
                result_display.Text = Math.Pow(Math.Tan(Double.Parse(display.Text)), -1).ToString();
            }
        }
    }
}
