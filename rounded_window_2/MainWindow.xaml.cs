using System;
using System.Collections;
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
using static System.Net.Mime.MediaTypeNames;

namespace rounded_window_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String User_input = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            User_input += "1";
            textField.Text = User_input;
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            User_input += "2";
            textField.Text = User_input;
        }

        private void btnThree_Click(object sender, RoutedEventArgs e)
        {
            User_input += "3";
            textField.Text = User_input;
        }

        private void btnFour_Click(object sender, RoutedEventArgs e)
        {
            User_input += "4";
            textField.Text = User_input;
        }

        private void btnFive_Click(object sender, RoutedEventArgs e)
        {
            User_input += "5";
            textField.Text = User_input;
        }

        private void btnSix_Click(object sender, RoutedEventArgs e)
        {
            User_input += "6";
            textField.Text = User_input;
        }

        private void btnSeven_Click(object sender, RoutedEventArgs e)
        {
            User_input += "7";
            textField.Text = User_input;
        }

        private void btnEight_Click(object sender, RoutedEventArgs e)
        {
            User_input += "8";
            textField.Text = User_input;
        }

        private void btnNine_Click(object sender, RoutedEventArgs e)
        {
            User_input += "9";
            textField.Text = User_input;
        }

        private void btnZero_Click(object sender, RoutedEventArgs e)
        {
            User_input += "0";
            textField.Text = User_input;
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            User_input += ".";
            textField.Text = User_input;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            User_input = User_input.Remove(User_input.Length - 1);
            textField.Text = User_input;
        }
        private void btnplus_Click(object sender, RoutedEventArgs e)
        {
            User_input += "+";
            textField.Text = User_input;
        }

        private void btnminus_Click(object sender, RoutedEventArgs e)
        {
            User_input += "-";
            textField.Text = User_input;
        }

        private void btnmultiply_Click(object sender, RoutedEventArgs e)
        {
            User_input += "*";
            textField.Text = User_input;
        }

        private void open_par_Click(object sender, RoutedEventArgs e)
        {
            User_input += "(";
            textField.Text = User_input;
        }

        private void close_par_Click(object sender, RoutedEventArgs e)
        {
            User_input += ")";
            textField.Text = User_input;
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            User_input += "/";
            textField.Text = User_input;
        }

        private void all_clear_Click(object sender, RoutedEventArgs e)
        {
            User_input = "";
            textField.Text = "";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            User_input = separator(User_input).ToString();
            textField.Text = (User_input);
        }
        private double separator(String text)
        {
            String number = "";
            ArrayList numbers = new ArrayList();
            ArrayList signs = new ArrayList();
            double answer = 0;
            for (int dex = 0; dex < text.Length; dex++)
            {
                if (text[dex] != '+' && text[dex] != '-' && text[dex] != '*' && text[dex] != '/' &&
                        text[dex] != '(' && text[dex] != ')')
                {
                    number += text[dex];
                }

                if (text[dex] == '+' || text[dex] == '-' || text[dex] == '*' || text[dex] == '/'
                        || text[dex] == '(' || text[dex] == ')')
                {
                    if (number != "")
                        numbers.Add(number);
                    number = "";
                    signs.Add(text[dex]);
                }
            }
            if (number != "")
                numbers.Add(number);
            answer = calculate(numbers, signs);
            return answer;
        }

        private double calculate(ArrayList num, ArrayList sign)
        {
            double answer = Double.Parse((String)num[0]);

            char[] bodmas = new char[] { '(', '/', '*', '-', '+' };
            if (num.Count > 1)
            {

                for (int bodmas_signs = 0; bodmas_signs < bodmas.Length; bodmas_signs++)
                {
                    for (int dex = 0; dex < sign.Count; dex++)
                    {
                        if (bodmas[bodmas_signs].Equals(sign[dex]))
                        {
                            if (sign[dex].Equals('('))
                            {
                                String inner_number = "";
                                sign.RemoveAt(dex);
                                while (!sign[dex].Equals(')'))
                                {
                                    inner_number += num[dex];
                                    num.RemoveAt(dex);
                                    if (!sign[dex].Equals(')'))
                                    {
                                        inner_number += sign[dex];
                                        sign.RemoveAt(dex);
                                    }
                                }
                                sign.RemoveAt(dex);
                                inner_number += num[dex];
                                answer = separator(inner_number);
                                num[dex] = answer.ToString();
                            }
                            else if (sign[dex].Equals('/'))
                            {
                                answer = Double.Parse((String)num[dex]) / Double.Parse((String)num[dex+1]);
                                sign.RemoveAt(dex);
                                num.RemoveAt(dex + 1);
                                num[dex] = answer.ToString();
                            }
                            else if (sign[dex].Equals('+'))
                            {
                                answer = Double.Parse((String)num[dex]) + Double.Parse((String)num[dex + 1]);
                                sign.RemoveAt(dex);
                                num.RemoveAt(dex + 1);
                                num[dex] = answer.ToString();
                            }
                            else if (sign[dex].Equals('-'))
                            {
                                answer = Double.Parse((String)num[dex]) - Double.Parse((String)num[dex+1]);
                                sign.RemoveAt(dex);
                                num.RemoveAt(dex + 1);
                                num[dex] = answer.ToString();
                            }
                            else if (sign[dex].Equals('*'))
                            {
                                answer = Double.Parse((String)num[dex]) * Double.Parse((String)num[dex + 1]);
                                sign.RemoveAt(dex);
                                num.RemoveAt(dex + 1);
                                num[dex] = answer.ToString();
                            }
                            calculate(num, sign);
                            answer = Double.Parse((String)num[0]);

                        }
                    }
                }
            }
            if (num.Count <= 1)
            {
                answer = Double.Parse((String)num[0]);
            }

            return answer;
        }
    }
}
