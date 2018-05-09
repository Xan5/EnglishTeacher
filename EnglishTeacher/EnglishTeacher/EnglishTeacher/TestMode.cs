using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    abstract class TestMode
    {
        private Word answear;
        protected int correctAnswears = 0;
        protected bool endTest = false;
        protected Word GetAnswear()
        {
            return answear;
        }
        protected void GetWord()
        {
            var rnd = new Random();
            int wordAmount = WordPool.GetSizeOfPool();
            int wordNumber = rnd.Next( wordAmount - 1);
            answear = WordPool.Get(wordNumber);
            WordPool.Release(wordNumber);
        }
        protected abstract void ShowQuestion();
        protected void IncreaseCorrectAnswears()
        {
            correctAnswears++;
        }
        protected void EndTest()
        {
            System.Windows.MessageBox.Show("Twój wynik to: " + correctAnswears.ToString()+"/5");
            Program.AddProgress(correctAnswears*5);
        }

        public void RunTest()
        {
            String[] question = new String[5];
            int iterator = 0;
            for(int i=0;i<5;i++)
            {
                if(endTest==true)
                {
                    break;
                }
                if(i==0)
                {
                    this.GetWord();
                    question[iterator] = answear.GetEnglishName();
                    iterator++;
                }
                int correct = 0;
                while((i>0)&&(correct==0))
                {
                    this.GetWord();
                    correct = 1;
                    for(int j=0;j<iterator;j++)
                    {
                        if(question[j]==answear.GetEnglishName())
                        {
                            correct = 0;
                        }
                    }
                    if(correct==1)
                    {
                        question[iterator] = answear.GetEnglishName();
                        iterator++;
                    }
                }
                this.ShowQuestion();
            }
            this.EndTest();
        }
        
    }
}
