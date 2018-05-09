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
    /// Logika interakcji dla klasy HardTest.xaml
    /// </summary>
    public partial class HardTest : Window
    {
        //private String answer = "";
        private String correctAnswer = "";
        private bool type = false;
        public int correct = 0;
        public HardTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            correct = 3;
            this.Close();
        }
        public void SetCorrectAnswer(string correct)
        {
            correctAnswer = correct;
        }
        public void SetType(bool learnMode)
        {
            type = learnMode;
        }
        public void SetWord(string word)
        {
            correctWord.Text = word;
        }
        public String GetAnswear()
        {
            return textAnswear.Text.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (type == false)
            {
                if (GetAnswear() == correctAnswer)
                {
                    correct = 1;
                }
                this.Close();

            }
            if (type == true)
            {
                if (GetAnswear() == correctAnswer)
                {

                    this.Close();
                }
                else System.Windows.MessageBox.Show("Zła odpowiedź, spróbuj ponownie!");
            }
        }

        void Window_Closing(object sender, CancelEventArgs e)
        {
        
            Program.SaveProgress();
            Program.SaveWords();
        }
    }
}
