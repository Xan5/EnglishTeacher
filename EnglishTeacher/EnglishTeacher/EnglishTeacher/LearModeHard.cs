using System;

namespace EnglishTeacher
{
    class LearnModeHard : LearnMode
    {
        public override LearnMode CreateMode()
        {
            SetAnswers();
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
                HardTest window = new HardTest();
                window.SetType(true);
                string words;
                if (Program.GetLearnType() == false)
                {
                    String word = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    words = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words);
                }
                else
                {
                    String word = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    words = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words);
                }

                window.ShowDialog();

                if (window.correct == 3)
                {
                    endTest = true;
                }
            }
        }
    }
}
