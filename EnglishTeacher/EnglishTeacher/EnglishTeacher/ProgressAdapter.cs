using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    class ProgressAdapter:Development
    {
        private Progress myProgress = new Progress();

        public int getLevel()
        {
            return myProgress.getAdvanceLevel();
        }

        public int getProgress()
        {
            return myProgress.getMyProgress();
        }

        public void increaseProgress(int amount)
        {
            int tmpProgress = myProgress.getMyProgress();
            int tmpLevel = myProgress.getAdvanceLevel();
            tmpProgress = tmpProgress + amount;
            myProgress.setProgress(tmpProgress);
            myProgress.setAdvanceLevel(tmpLevel);
        }

        public void setProgress(int amount)
        {
            myProgress.setProgress(amount);
        }

        public void setLevel(int type)
        {
            myProgress.setAdvanceLevel(type);
        }
    }
}
