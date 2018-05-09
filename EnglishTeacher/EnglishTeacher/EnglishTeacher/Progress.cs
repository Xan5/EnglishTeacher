using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    class Progress
    {
        private int advanceLevel;
        private int progress;
        public Progress()
        {
            advanceLevel = 0;
            progress = 0;
        }
        public int getAdvanceLevel()
        {
            return advanceLevel;
        }
        public void setAdvanceLevel(int type)
        {
            if((advanceLevel>=0)&&(advanceLevel<=2))
            {
                advanceLevel = type;
            }
        }
        public int getMyProgress()
        {
            return progress;
        }
        public void setProgress(int amount)
        {
            progress = amount;
            if(progress<500)
            {
                advanceLevel = 0;
            }
            if ((progress>=500)&&(progress<1000))
            {
                advanceLevel = 1;
            }
            if (progress>=1000)
            {
                advanceLevel = 2;
            }
        }
    }
}
