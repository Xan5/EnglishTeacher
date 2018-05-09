using System;

namespace EnglishTeacher
{
    class LearnModeMedium : LearnMode
    {
        private int[] wrongAnswers = new int[40];

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
                MediumTest window = new MediumTest();
                window.SetType(true);
                string[] words = new string[6];
                if (Program.GetLearnType() == false)
                {
                    String word = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    words[0] = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    words[1] = WordPool.Get(wrongAnswers[i * 4]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 4]);
                    words[2] = WordPool.Get(wrongAnswers[i * 4 + 1]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 4 + 1]);
                    words[3] = WordPool.Get(wrongAnswers[i * 4 + 2]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 4 + 2]);
                    words[4] = WordPool.Get(wrongAnswers[i * 4 + 3]).GetEnglishName();
                    WordPool.Release(wrongAnswers[i * 4 + 3]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words[0]);
                }
                else
                {
                    String word = WordPool.Get(answers[i]).GetEnglishName();
                    WordPool.Release(answers[i]);
                    words[0] = WordPool.Get(answers[i]).GetPolishName();
                    WordPool.Release(answers[i]);
                    words[1] = WordPool.Get(wrongAnswers[i * 4]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 4]);
                    words[2] = WordPool.Get(wrongAnswers[i * 4 + 1]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 4 + 1]);
                    words[3] = WordPool.Get(wrongAnswers[i * 4 + 2]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 4 + 2]);
                    words[4] = WordPool.Get(wrongAnswers[i * 4 + 3]).GetPolishName();
                    WordPool.Release(wrongAnswers[i * 4 + 3]);
                    window.SetWord(word);
                    window.SetCorrectAnswer(words[0]);
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

                window.ShowDialog();

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
            for (int i = 0; i < 40; ++i)
            {
                int wordNumber = rnd.Next(wordAmount);
                if (wordNumber != answers[i / 4])
                {
                    if(i % 4 == 0)
                    {
                        wrongAnswers[i] = wordNumber;
                    }
                    if (i % 4 == 1)
                    {
                        if (wordNumber != wrongAnswers[i - 1])
                        {
                            wrongAnswers[i] = wordNumber;
                        }
                        else i--;
                    }
                    if (i % 4 == 2)
                    {
                        if (wordNumber != wrongAnswers[i - 1] && wordNumber != wrongAnswers[i - 2])
                        {
                            wrongAnswers[i] = wordNumber;
                        }
                        else i--;
                    }
                    if (i % 4 == 3)
                    {
                        if (wordNumber != wrongAnswers[i - 1] && wordNumber != wrongAnswers[i - 2] && wordNumber != wrongAnswers[i - 3])
                        {
                            wrongAnswers[i] = wordNumber;
                        }
                        else i--;
                    }
                }
                else i--;
            }
        }
    }
}
