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
    /// Interaction logic for WordList.xaml
    /// </summary>
    public partial class WordList : Window
    {
        public WordList()
        {
            InitializeComponent();
            List<Row> Rows = new List<Row>();
            for (int i = 0; i < WordPool.GetSizeOfPool(); i++)
            {
                string pname = WordPool.Get(i).GetPolishName(); ;
                WordPool.Release(i);
                string ename = WordPool.Get(i).GetEnglishName(); ;
                WordPool.Release(i);
                Rows.Add(new Row() { pName = pname, eName = ename });
            }
            lvWords.ItemsSource = Rows;

        }

        private void LoadData()
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WordAdd window = new WordAdd();
            window.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int id = lvWords.SelectedIndex;
            WordPool.Delete(id);
            WordList window = new WordList();
            window.Show();
            this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //update
            int id;
            if (lvWords.SelectedIndex == -1)
            {
                id = 0;
            }
            else id=lvWords.SelectedIndex;
            WordUpdate window = new WordUpdate(id);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource wordPoolViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("wordPoolViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // wordPoolViewSource.Source = [generic data source]


        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            Program.SaveProgress();
            Program.SaveWords();
        }
    }
    public class Row
    {
        public string pName { get; set; }

        public string eName { get; set; }
    }
}
