using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace lab5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int k = 31;
        public int calcN()
        {
            int n = k;
            long a = (long) Math.Pow(2, k);
            long b = (long)(Math.Pow(2, n) / (n + 1));
            while (a> b)
            {
                n++;
                b = (long)(Math.Pow(2, n) / (n + 1));
            }
            return n;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            int n = calcN();
            int p = n - k;
            string message = generateMessage(n);
            string totalMessage = generateTotalString(n,message);
        }

        private string generateMessage(int n)
        {
            string msg = "";
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
               msg += rnd.Next(0,2);
            }
            return msg;
        }
        private string generateTotalString(int n,string originalMessage)
        {
            string totalMessage = "";
            int counter = 0;
            int stringPointer = 0;
            for (int i = 0; i < n; i++)
            {
                if (Math.Pow(2,counter)==i)
                {
                    counter++;
                    int check = 0;
                    int checkMul = (int) Math.Pow(2,counter);
                    for (int j = checkMul; j < n; j++)
                    {
                        if (j%checkMul==0)
                        {
                            check = check ^ originalMessage[j];
                        }
                    }
                    if (check ==0)
                    {
                        totalMessage += "0";
                    }
                    else
                    {
                        totalMessage += "1";
                    }
                }
                else
                {
                    totalMessage += originalMessage[stringPointer];
                    stringPointer++;
                }
            }
            return totalMessage;
        }
    }
}
