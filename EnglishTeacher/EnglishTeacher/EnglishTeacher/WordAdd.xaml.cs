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
    /// Interaction logic for WordAdd.xaml
    /// </summary>
    public partial class WordAdd : Window
    {
        public WordAdd()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WordList window = new WordList();
            window.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WordPool.Add(new Word(PolishWord.Text.ToString(), EnglishWord.Text.ToString()));
            WordList window = new WordList();
            window.Show();
            this.Close();

        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            Program.SaveProgress();
            Program.SaveWords();
        }
    }
}
