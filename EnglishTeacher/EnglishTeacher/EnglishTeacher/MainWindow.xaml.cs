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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishTeacher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            /* WordPool.Add(new Word("Pies", "Dog"));
            WordPool.Add(new Word("Kot", "Cat"));
            WordPool.Add(new Word("Rower", "Bike"));
            WordPool.Add(new Word("Śpiewac", "Sing"));
            WordPool.Add(new Word("Tańczyć", "Dance"));
            WordPool.Add(new Word("Mysz", "Mouse"));
            WordPool.Add(new Word("Komputer", "Computer"));
            WordPool.Add(new Word("Małpa", "Monkey"));
            WordPool.Add(new Word("Auto", "Car"));
            WordPool.Add(new Word("Drzewo", "Tree"));
            WordPool.Add(new Word("Skarpety", "Socks"));
            WordPool.Add(new Word("Spodnie", "Trousers"));
            WordPool.Add(new Word("Telefon", "Phone"));
            WordPool.Add(new Word("Gwiazda", "Star"));
            WordPool.Add(new Word("Słuchawki", "Headphones"));
            WordPool.Add(new Word("Łóżko", "Bed"));
            WordPool.Add(new Word("Okulary", "Glasses"));
            WordPool.Add(new Word("Książka", "Book"));
            WordPool.Add(new Word("Krzesło", "Chair"));
            WordPool.Add(new Word("Pilot", "Remote"));
            WordPool.Add(new Word("Kwiatek", "Flower"));
            WordPool.Add(new Word("Słońce", "Sun"));
            WordPool.Add(new Word("Deszcz", "Rain"));
            WordPool.Add(new Word("Chmura", "Cloud"));
            WordPool.Add(new Word("Droga", "Road"));
            WordPool.Add(new Word("Drzwi", "Door"));
            WordPool.Add(new Word("Wiatr", "Wind"));
            WordPool.Add(new Word("Dom", "House"));
            WordPool.Add(new Word("Krew", "Blood"));
            WordPool.Add(new Word("Ręka", "Hand"));
            WordPool.Add(new Word("Noga", "Leg"));
            WordPool.Add(new Word("Głowa", "Head"));
            WordPool.Add(new Word("Oko", "Eye"));
            WordPool.Add(new Word("Krowa", "Cow"));
            WordPool.Add(new Word("Królik", "Rabbit"));
            WordPool.Add(new Word("Koń", "Horse"));*/
            Program.LoadProgress();
            Program.LoadWords();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Program.PlayTestMode();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Statystyki window = new Statystyki();
            //window.Show();
            //this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WordPool.SaveToFileWords();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Difficulty window = new Difficulty();
            window.Show();
            
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Program.PlayLearnMode();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            WordList window = new WordList();
            window.Show();
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
            Program.SaveProgress();
            Program.SaveWords();
        }
    }
}
