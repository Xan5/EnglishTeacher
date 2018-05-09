using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EnglishTeacher
{
    static class Program
    {
        //private static LearnMode learnMode;
        //private static TestMode testMode;
        private static Development progress = new ProgressAdapter();
        private static bool learnType=false;

        static Program()
        {

        }

        public static void PlayTestMode() {
            TestMode test;
            if(progress.getLevel()==0)
            {
                test = new TestModeEasy();
                test.RunTest();
            }
            if (progress.getLevel() == 1)
            {
                test = new TestModeMedium();
                test.RunTest();
            }
            if (progress.getLevel() == 2)
            {
                test = new TestModeHard();
                test.RunTest();
            }
        }

        public static void PlayLearnMode()
        {
            LearnModeFactory factory = new LearnModeFactory();
            LearnMode mode;
            mode = factory.CreateMode(progress.getLevel());
            mode.StartMode();
        }

        public static void AddProgress(int amount)
        {
            progress.increaseProgress(amount);
        }
        
        public static void ChangeCurrentLevel(int level) {
            progress.setLevel(level);
        }
        public static int GetCurrentLevel()
        {
            return progress.getLevel();
        }
        public static void AddWord(string polish,string english)
        {
            WordPool.Add(new Word(polish, english));
        }
        public static Word GetWord(int i)
        {
            return WordPool.Get(i);
        }
        public static void DeleteWord(String name,bool english)
        {
            WordPool.Delete(name, english);
        }
        public static bool GetLearnType()
        {
            return learnType;
        }
        public static void SetLearnType(bool englishtopolish)
        {
            learnType = englishtopolish;
        }
        public static void SaveWords()
        {
            WordPool.SaveToFileWords();
        }
        public static void LoadWords()
        {
            WordPool.LoadFromFileWords();
        }
        public static void SaveProgress()
        {
            FileStream MyStream1 = new FileStream("C:\\Users\\" + Environment.UserName + "\\Desktop\\data1.dat", FileMode.OpenOrCreate);
            BinaryFormatter MyFormatter = new BinaryFormatter();
            int zmienna1 = progress.getProgress();
            int zmienna2 = progress.getLevel();
            bool zmienna3 = GetLearnType();
            MyFormatter.Serialize(MyStream1, zmienna1);
            MyFormatter.Serialize(MyStream1, zmienna2);
            MyFormatter.Serialize(MyStream1, zmienna3);
            MyStream1.Close();
        }
        public static void LoadProgress()
        {
            FileStream MyStream1 = new FileStream("C:\\Users\\" + Environment.UserName + "\\Desktop\\data1.dat", FileMode.OpenOrCreate);
            BinaryFormatter MyFormatter = new BinaryFormatter();
            if (MyStream1.Length != 0)
            {
                int zmienna1 = (int)MyFormatter.Deserialize(MyStream1);
                int zmienna2 = (int)MyFormatter.Deserialize(MyStream1);
                bool zmienna3 = (bool)MyFormatter.Deserialize(MyStream1);
                progress.setProgress(zmienna1);
                progress.setLevel(zmienna2);
                SetLearnType(zmienna3);

            }
            MyStream1.Close();
            FileInfo F1 = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\data1.dat");
            if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\data1.dat"))
            {
                F1.Delete();
            }
        }
    }
    
}
