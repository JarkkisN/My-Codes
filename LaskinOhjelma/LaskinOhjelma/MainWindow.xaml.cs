// Jarkko Niemi - INTIP21A6
// 1.2.2022
// WPF tehtävä 18.1.-1.2.2022 laskin

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

namespace LaskinOhjelma
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
        float num1, ans;
        int count;

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            if (num1 == 0 && TextBox1.Text.Length > 0)
            {
                num1 = 0; TextBox1.Clear();
            }
            else if (num1 > 0 && TextBox1.Text.Length > 0)
            {
                TextBox1.Clear();
            }
        }


        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            count = 0;
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "")
            {
                num1 = float.Parse(TextBox1.Text);
                TextBox1.Clear();
                TextBox1.Focus();
                count = 1;
            }
        }

        private void BtnOne_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 1;
        }

        private void BtnTwo_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 2;
        }

        private void BtnThree_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 3;
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(TextBox1.Text);
            TextBox1.Clear();
            TextBox1.Focus();
            count = 2;
        }

        private void BtnFour_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 4;
        }

        private void BtnFive_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 5;
        }

        private void BtnSix_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 6;
        }

        private void BtnMultiply_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(TextBox1.Text);
            TextBox1.Clear();
            TextBox1.Focus();
            count = 3;
        }

        private void BtnSeven_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 7;
        }

        private void BtnEight_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 8;
        }

        private void BtnNine_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 9;
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            num1 = float.Parse(TextBox1.Text);
            TextBox1.Clear();
            TextBox1.Focus();
            count = 4;
        }

        private void BtnZero_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = TextBox1.Text + 0;
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            compute(count);
        }

        public void compute(int count)
        {
            switch (count)
            {
                case 1:
                    ans = num1 - float.Parse(TextBox1.Text);
                    TextBox1.Text = ans.ToString();
                    break;
                case 2:
                    ans = num1 + float.Parse(TextBox1.Text);
                    TextBox1.Text = ans.ToString();
                    break;
                case 3:
                    ans = num1 * float.Parse(TextBox1.Text);
                    TextBox1.Text = ans.ToString();
                    break;
                case 4:
                    ans = num1 / float.Parse(TextBox1.Text);
                    TextBox1.Text = ans.ToString();
                    break;
                default:
                    break;
            }
        }

    }
}
