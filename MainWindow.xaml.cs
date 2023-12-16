using System;
using System.Collections.Generic;
using System.Data;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            // Button selected = (Button)e.Source;
            // txbResult.Text = selected.Content.ToString();
            //Console.WriteLine((e.Source as Button).Name);
            txbMoves.Text = "";
            Button selectedButton = e.Source as Button;
            string content = selectedButton.Content.ToString();

            string lastChar = " ";
            if (txbResult.Text != "")
            {
                lastChar = txbResult.Text[txbResult.Text.Length - 1].ToString();
            }

            if (content == "C")
            {
                txbResult.Text = "";
            }
            else if (content == "Del")
            {
                if (txbResult.Text != "")
                {
                    txbResult.Text = txbResult.Text.Remove(txbResult.Text.Length - 1);
                }
            }
            else if (content == "=")
            {
                txbMoves.Text = txbResult.Text;
                string expression = txbResult.Text.Replace(",", ".");

                DataTable table = new DataTable();
                double result = Convert.ToDouble(table.Compute(txbResult.Text, ""));
                txbResult.Text = result.ToString().Replace(",", ".");
            }
            else if (txbResult.Text == "0")
            {
                if (content == ".")
                {
                    txbResult.Text += content;
                }
                else if (content != "0")
                {
                    txbResult.Text = content;
                }
                
            }
            else if (content == ".")
            {
                if (lastChar == ".")
                {
                    return;
                }
                if (txbResult.Text == "")
                {
                    return;
                }
                else
                {
                    txbResult.Text += content;
                }
            }
            else if ("+-x/".Contains(content))
            {
                if (!"+-x/".Contains(lastChar))
                {
                    txbResult.Text += content;
                }
            }
            else
            {
                txbResult.Text += content;
            }
        }
    }
}
