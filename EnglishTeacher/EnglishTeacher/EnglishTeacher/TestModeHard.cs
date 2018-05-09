using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    class TestModeHard : TestMode
    {
        protected override void ShowQuestion()
        {
            HardTest window = new HardTest();
            if(Program.GetLearnType()==false)
            {
                window.SetWord(GetAnswear().GetPolishName());
                window.SetCorrectAnswer(GetAnswear().GetEnglishName());
            }
            if (Program.GetLearnType() == true)
            {
                window.SetWord(GetAnswear().GetEnglishName());
                window.SetCorrectAnswer(GetAnswear().GetPolishName());
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
