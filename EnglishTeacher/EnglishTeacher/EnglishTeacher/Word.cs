using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishTeacher
{
    [Serializable]
    class Word
    {
        private string polishName;
        private string englishName;
        private bool inUse = false;

        public Word(string pName, string eName)
        {
            polishName = pName;
            englishName = eName;
        }
        public string GetPolishName()
        {
            return polishName;
        }
        public string GetEnglishName()
        {
            return englishName;
        }
        public bool GetInUse()
        {
            return inUse;
        }
        public void SetPolishName(string name)
        {
            polishName = name;
        }
        public void SetEnglishName(string name)
        {
            englishName = name;
        }
        public void SetInUse(bool use)
        {
            inUse = use;
        }

        Object word;

        Word(Object word)
        {
            this.word = word;
        }
    }
}
