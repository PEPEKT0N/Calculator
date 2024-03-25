using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    /// Логика взаимодействия для SimpleCalc.xaml
    /// </summary>
    public partial class SimpleCalc : Page
    {
        char op;
        public SimpleCalc()
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

        private void Engineering_calc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EngineeringCalc());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
