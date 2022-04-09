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

namespace WpfCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastnumber, result;
        selectedOperator selectedoperator;
        public MainWindow()
        {
            InitializeComponent();
            btnAC.Click += BtnAC_Click;
            btnEqual.Click += BtnEqual_Click;
            btnModulos.Click += BtnModulos_Click;
            btnDivided.Click += BtnDivided_Click;
            btnAddMinus.Click += btnAddMinus_Click;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (selectedoperator)
                {
                    case selectedOperator.Addition:
                        result = simpleMath.Add(lastnumber, newNumber);
                        break;
                    case selectedOperator.Subtraction:
                        result = simpleMath.Substration(lastnumber, newNumber);
                        break;
                    case selectedOperator.Division:
                        result = simpleMath.Division(lastnumber, newNumber);
                        break;
                    case selectedOperator.multiplication:
                        result = simpleMath.multiply(lastnumber, newNumber);
                        break;
                    default:
                        break;
                }
                lblResult.Content = result.ToString();
            }
        }

        private void BtnModulos_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastnumber != 0)
                {
                    tempNumber *= lastnumber; 
                }
                lblResult.Content = tempNumber.ToString();
            }
        }

        // 50 + 5% (2.5) = (52.5)
        // 80 + 10% (8) = (88)
        private void BtnDivided_Click(object sender, RoutedEventArgs e)
        {
            //if (double.TryParse(lblResult.Content.ToString(), out lastnumber))
            //{
            //    lastnumber = lastnumber / 1;
            //    lblResult.Content = lastnumber.ToString();
            //}
        }

        private void btnAddMinus_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastnumber))
            {
                lastnumber = lastnumber * -1;
                lblResult.Content = lastnumber.ToString();
            }
        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
            result = 0;
            lastnumber = 0;
        }

        private void operationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastnumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnAdd)
                selectedoperator = selectedOperator.Addition;
            if (sender == btnMinus)
                selectedoperator = selectedOperator.Subtraction;
            if (sender == btnMultiply)
                selectedoperator = selectedOperator.multiplication;
            if (sender == btnDivided)
                selectedoperator = selectedOperator.Division;
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {
                //Do Nothing
            }
            else
            {
                lblResult.Content = $"{ lblResult.Content }.";
            }
        }

        private void number_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{ lblResult.Content }{selectedValue}";
            }
        }
    }

    public enum selectedOperator
    {
        Addition,
        Subtraction,
        Division,
        multiplication
    }

    public class simpleMath
    {
        public static double Add(double n1,double n2)
        {
            return n1 + n2;
        }
        public static double Substration(double n1,double n2)
        {
            return n1 - n2;
        }
        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Ivalid operation", MessageBoxButton.OK,MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
        public static double multiply(double n1,double n2)
        {
            return n1 * n2;
        }
    }
}
