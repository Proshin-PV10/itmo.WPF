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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double first;
        private double second;
        private bool TakeSec;
        private bool Add;
        private bool Minus;
        private bool Mult;
        private bool Div;
        private bool Zap;
        private bool Error;

        public MainWindow()
        {
            InitializeComponent();            
        }
        private void Take1()
        {
            if ((Add == true || Minus == true || Mult == true || Div == true)&& Answer.Text!=""&& Error==false)
            {
                first = double.Parse(Answer.Text);
                Answer.Text = "";
                Zap = false;


            }
        }
        private void Take2()
        {
            if (TakeSec=true && Error==false && Answer.Text!="")
            {
                second = double.Parse(Answer.Text);
                Math();
            }
        }

        private void Math()
        {
            
            if (Add)
            {
                Answer.Text = (first + second).ToString();
                Add= false;
            }

            if (Minus)
            {
                Answer.Text = (first - second).ToString();
                Minus = false;
            }

            if (Mult)
            {
                Answer.Text = (first * second).ToString();
                Mult = false;
            }

            if (Div)
            {
                if (second == 0)
                {
                    Answer.FontSize = 20;
                    Answer.Text = "Деление на ноль невозможно";
                    Error = true;
                }
                else
                {
                    Answer.Text = (first / second).ToString();
                    Div = false;
                }
            }
            
        }

        private void click1_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "1";
            Answer.Text += "1";
        }

        private void click2_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "2";
            Answer.Text += "2";
        }
        private void click3_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "3";
            Answer.Text += "3";
        }
        private void click4_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "4";
            Answer.Text += "4";
        }
        private void click5_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "5";
            Answer.Text += "5";
        }
        private void click6_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "6";
            Answer.Text += "6";
        }
        private void click7_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "7";
            Answer.Text += "7";
        }
        private void click8_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "8";
            Answer.Text += "8";
        }
        private void click9_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "9";
            Answer.Text += "9";
        }
        private void click0_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "0";
            Answer.Text += "0";
        }
        private void clickz_Click(object sender, RoutedEventArgs e)
        {
            if (Zap==false)
            {
                if (Answer.Text=="")
                {
                    Answer.Text = "0,";
                    TextA.Text = "0,";
                }
                else
                {
                    TextA.Text += ",";
                    Answer.Text += ",";
                }                
                Zap = true;
            }
            
            
        }
        private void clicks_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "+";
            Add = true;
            Take1();
          
        }
        private void clickv_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "-";
            Minus = true;
            Take1();
        }
        private void clicku_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "*";
            Mult = true;
            Take1();
        }
        private void clickd_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text += "/";
            Div = true;
            Take1();
            
        }

        private void clickr_Click(object sender, RoutedEventArgs e)
        {
            TakeSec = true;
            Take2();
            TextA.Text = $"({TextA.Text})";
        }
        private void clickpm_Click(object sender, RoutedEventArgs e)
        {
            if(Answer.Text != "" && Error == false)
            {
                double x = double.Parse(Answer.Text);
                Answer.Text = (x * (-1)).ToString();
            }
            
        }
        private void clickproc_Click(object sender, RoutedEventArgs e)
        {
            if(Error==false && Answer.Text!="")
            {
                double x = double.Parse(Answer.Text);
                Answer.Text = (x * 100).ToString();
            }
            
        }
        private void clickdel_Click(object sender, RoutedEventArgs e)
        {


            if (Answer.Text.Length > 0)
            {
                Answer.Text = Answer.Text.Substring(0, Answer.Text.Length - 1);
            }
            if (TextA.Text.Length > 0)
            {
                TextA.Text = TextA.Text.Substring(0, TextA.Text.Length - 1);
            }
        }
        private void clickc_Click(object sender, RoutedEventArgs e)
        {
            TextA.Text = "";
            Answer.Text = "";
            first = 0;
            second = 0;
            TakeSec = false;
            Add = false;
            Minus = false;
            Mult = false;
            Div = false;
            Zap = false;
            Error = false;
            Answer.FontSize = 32;
        }

       
    }
}
