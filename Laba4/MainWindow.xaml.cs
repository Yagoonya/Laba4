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

namespace Laba4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool check(int x)
        {
            bool f = true;
            for (int i=2; i<=x/2; i++)
            {
                if (x % i == 0)
                {
                    f = false;
                    break;
                }
            }
            return (f);
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(TB.Text);
                TB.Text = "";
                if (x > 0)
                {
                    if (check(x)) LB.Items.Add(x);
                    if (!check(x)) MessageBox.Show("ne simple");
                }
                else MessageBox.Show("ne simple");

            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
                TB.Text = "";
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LB.Items.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                dlg.ShowDialog();
                using (System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        try
                        {
                            int y = Convert.ToInt32(file.ReadLine());
                            if ((check(y)) && (y > 0))
                                LB.Items.Add(y);
                            else
                            {
                                MessageBox.Show("ЧИСЛА В ФАЙЛЕ НЕ ПРОСТЫЕ!!!");
                                break;
                            }
                            

                        }
                        catch (FormatException ex)
                        {

                        }
                    }

                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "DOCUMENT";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(dlg.FileName))
            {

                for (int i = 0; i < LB.Items.Count; i++)
                    outputFile.WriteLine(LB.Items[i].ToString());

            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
