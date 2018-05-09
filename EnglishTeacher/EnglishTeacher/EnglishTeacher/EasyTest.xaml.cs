﻿using System;
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
    /// Logika interakcji dla klasy EasyTest.xaml
    /// </summary>
    public partial class EasyTest : Window
    {
        private String answer="";
        private String correctAnswer = "";
        private bool type = false;
        public int correct = 0;
        public EasyTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            correct = 3;
            this.Close();
        }
        public void SetType(bool learnMode)
        {
            type = learnMode;
        }
        public void  SetCorrectAnswer(string correct)
        {
            correctAnswer = correct;
        }
        public void SetWord(string word)
        {
            correctWord.Text = word;
        }
        public void SetAnswer1(string word)
        {
            answer1.Content = word;
        }
        public void SetAnswer2(string word)
        {
            answer2.Content = word;
        }
        public void SetAnswer3(string word)
        {
            answer3.Content = word;
        }

        private void answer1_Click(object sender, RoutedEventArgs e)
        {
            answer = answer1.Content.ToString();
            answer1.Background = Brushes.Yellow;
            answer2.ClearValue(Button.BackgroundProperty);
            answer3.ClearValue(Button.BackgroundProperty);

        }

        private void answer2_Click(object sender, RoutedEventArgs e)
        {
            answer = answer2.Content.ToString();
            answer2.Background = Brushes.Yellow;
            answer1.ClearValue(Button.BackgroundProperty);
            answer3.ClearValue(Button.BackgroundProperty);
        }

        private void answer3_Click(object sender, RoutedEventArgs e)
        {
            answer = answer3.Content.ToString();
            answer3.Background = Brushes.Yellow;
            answer2.ClearValue(Button.BackgroundProperty);
            answer1.ClearValue(Button.BackgroundProperty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (type == false)
            {
                if (answer == correctAnswer)
                {
                    correct = 1;
                }
                this.Close();
                
            }
            if (type == true)
            {
                if (answer == correctAnswer)
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
