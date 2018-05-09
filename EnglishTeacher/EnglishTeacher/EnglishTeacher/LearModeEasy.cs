using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    class LearnModeEasy : LearnMode
    {
        private int[] wrongAnswers = new int[20];

        public override LearnMode CreateMode()
        {
            SetAnswers();
            SetWrongAnswers();
            return this;
        }

        public override void StartMode()
        {
            for (int i = 0; i < 10; i++)
            {
                if (endTest == true)
                {
                    break;
                }
                EasyTest window = new EasyTest();
                window.SetType(true);
                string[] words = new string[3];
                if (Program.GetLearnType() == false)
                {
                    String word = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    words[0] = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    words[1] = WordPool.Get(wrongAnswers[i * 2]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 2]);
                    words[2] = WordPool.Get(wrongAnswers[i * 2 + 1]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 2 + 1]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words[0]);
                }
                else
                {
                    String word = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    words[0] = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    words[1] = WordPool.Get(wrongAnswers[i * 2]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 2]);
                    words[2] = WordPool.Get(wrongAnswers[i * 2 + 1]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 2 + 1]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words[0]);
                }
                var rand = new Random();
                int nmb = rand.Next(0, 2);
                if (nmb == 0)
                {
                    window.SetAnswer1(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer3(words[2]);
                }
                if (nmb == 1)
                {
                    window.SetAnswer2(words[0]);
                    window.SetAnswer1(words[1]);
                    window.SetAnswer3(words[2]);
                }
                if (nmb == 3)
                {
                    window.SetAnswer3(words[0]);
                    window.SetAnswer2(words[1]);
                    window.SetAnswer1(words[2]);
                }

                
                window.ShowDialog();
                /*
                if (window.correct == 1)
                {
                    IncreaseCorrectAnswears();
                }*/
                if (window.correct == 3)
                {
                    endTest = true;
                }


            }
        }

        public void SetWrongAnswers()
        {
            var rnd = new Random();
            int wordAmount = WordPool.GetSizeOfPool();
            for (int i = 0; i < 20; ++i)
            {
                int wordNumber = rnd.Next(wordAmount);
                if (wordNumber != answers[i / 2])
                {
                    if (i % 2 == 1)
                    {
                        if (wordNumber != wrongAnswers[i - 1])
                        {
                            wrongAnswers[i] = wordNumber;
                        }
                        else i--;
                    }
                    else wrongAnswers[i] = wordNumber;
                }
                else i--;
            }
        }
    }
}
