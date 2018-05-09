using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnglishTeacher
{
    /// <summary>
    /// Logika interakcji dla klasy Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Window
    {
        
        public Difficulty()
        {
            InitializeComponent();
            if (Program.GetCurrentLevel() == 0)
            {
                level.Text = "Łatwy";
                easy.IsChecked = true;
            }
            if (Program.GetCurrentLevel() == 1)
            {
                level.Text = "Średni";
                medium.IsChecked = true;
            }
            if (Program.GetCurrentLevel() == 2)
            {
                level.Text = "Trudny";
                hard.IsChecked = true;
            }
            if(Program.GetLearnType()==false)
            {
                poleng.IsChecked = true;
            }
            if (Program.GetLearnType() == true)
            {
                engpol.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(easy.IsChecked==true)
            {
                Program.ChangeCurrentLevel(0);
            }
            if (medium.IsChecked == true)
            {
                Program.ChangeCurrentLevel(1);
            }
            if (hard.IsChecked == true)
            {
                Program.ChangeCurrentLevel(2);
            }
            if(poleng.IsChecked==true)
            {
                Program.SetLearnType(false);
            }
            if(engpol.IsChecked==true)
            {
                Program.SetLearnType(true);
            }
            this.Close();
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            Program.SaveProgress();
        }
    }
}
