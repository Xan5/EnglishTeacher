using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace EnglishTeacher
{
    abstract class LearnMode
    {
        protected bool endTest = false;
        protected int[] answers = new int[10];

        public abstract LearnMode CreateMode();
        public abstract void StartMode();

        protected void SetAnswers()
        {
            var rnd = new Random();
            int wordAmount = WordPool.GetSizeOfPool();
            for (int i = 0; i < 10; ++i)
            {
                int wordNumber = rnd.Next(wordAmount);
                for (int j = 0; j <= i; ++j)
                {
                    if (i == 0)
                    {
                        answers[i] = wordNumber;
                    }
                    else if (answers[j] == wordNumber)
                    {
                        i--;
                        break;
                    }
                    if (j == i)
                    {
                        answers[i] = wordNumber;
                    }
                }
            }
        }
    }

    class LearnModeFactory
    {
        public LearnMode CreateMode(int level)
        {
            LearnMode mode = null;
            if (level == 0)
            {
                mode = new LearnModeEasy();
            }
            if (level == 1)
            {
                mode = new LearnModeMedium();
            }
            if (level == 2)
            {
                mode = new LearnModeHard();
            }
            return mode.CreateMode();
        }
    }
}
