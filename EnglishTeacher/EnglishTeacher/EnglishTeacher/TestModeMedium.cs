using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    class TestModeMedium : TestMode
    {
        protected override void ShowQuestion()
        {
            MediumTest window = new MediumTest();
            Word tmp;
            string[] words = new string[5];
            int i = 0;
            if (Program.GetLearnType() == false)
            {
                words[0] = GetAnswear().GetEnglishName();
                i++;
                String word = GetAnswear().GetPolishName();
                window.SetWord(word);
                window.SetCorrectAnswer(GetAnswear().GetEnglishName());
                while (i != 5)
                {
                    int correct = 1;
                    var rnd = new Random();
                    int wordAmount = WordPool.GetSizeOfPool();
                    int wordNumber = rnd.Next(wordAmount - 1);
                    tmp = WordPool.Get(wordNumber);
                    WordPool.Release(wordNumber);
                    for (int j = 0; j < i; j++)
                    {
                        if (tmp.GetEnglishName() == words[j])
                        {
                            correct = 0;
                        }
                    }
                    if (correct == 1)
                    {
                        words[i] = tmp.GetEnglishName();
                        i++;
                    }

                }
                var rand = new Random();
                int nmb = rand.Next(0, 5);
                if (nmb == 0)
                {
                    window.SetAnswer1(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer3(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 1)
                {
                    window.SetAnswer2(words[0]);
                    window.SetAnswer1(words[1]);
                    window.SetAnswer3(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 2)
                {
                    window.SetAnswer3(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 3)
                {
                    window.SetAnswer4(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer3(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 4)
                {
                    window.SetAnswer5(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer3(words[4]);
                }

            }
            if (Program.GetLearnType() == true)
            {
                words[0] = GetAnswear().GetPolishName();
                i++;
                String word = GetAnswear().GetEnglishName();
                window.SetWord(word);
                window.SetCorrectAnswer(GetAnswear().GetPolishName());
                while (i != 5)
                {
                    int correct = 1;
                    var rnd = new Random();
                    int wordAmount = WordPool.GetSizeOfPool();
                    int wordNumber = rnd.Next(wordAmount - 1);
                    tmp = WordPool.Get(wordNumber);
                    WordPool.Release(wordNumber);
                    for (int j = 0; j < i; j++)
                    {
                        if (tmp.GetPolishName() == words[j])
                        {
                            correct = 0;
                        }
                    }
                    if (correct == 1)
                    {
                        words[i] = tmp.GetPolishName();
                        i++;
                    }

                }
                var rand = new Random();
                int nmb = rand.Next(0, 5);
                if (nmb == 0)
                {
                    window.SetAnswer1(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer3(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 1)
                {
                    window.SetAnswer2(words[0]);
                    window.SetAnswer1(words[1]);
                    window.SetAnswer3(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 2)
                {
                    window.SetAnswer3(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 3)
                {
                    window.SetAnswer4(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer3(words[3]);
                    window.SetAnswer5(words[4]);
                }
                if (nmb == 4)
                {
                    window.SetAnswer5(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                    window.SetAnswer4(words[3]);
                    window.SetAnswer3(words[4]);
                }

            }
            window.ShowDialog();

            if (window.correct == 1)
            {
                IncreaseCorrectAnswears();
            }
            if (window.correct == 3)
            {
                endTest = true;
            }
        }
    }
}
