using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    interface Development
    {
        int getProgress();
        void increaseProgress(int amount);
        void setProgress(int amount);
        int getLevel();
        void setLevel(int type);
        
    }
}
