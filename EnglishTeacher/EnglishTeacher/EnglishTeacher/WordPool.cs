using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EnglishTeacher
{
    static class WordPool
    {
        private static List<Word> wordPool = new List<Word>();
        private static FileStream MyStream;
        public class WordException : System.Exception
        {
            public WordException(string Message) : base(Message) { }
        }

        static WordPool()
        {
        }
        private static List<Word> GetWordPool()
        {
            return wordPool;
        }
        public static void SetWordPool(List<Word> list)
        {
            wordPool = list;
        }

        public static int GetSizeOfPool()
        {
            return wordPool.Count;
        }

        private static bool IfUse()
        {
            bool use = false;
            for (int i = 0; i < wordPool.Count; i++)
            {
                if (wordPool[i].GetInUse() == true)
                {
                    use = true;
                }
            }
            return use;
        }

        public static void Add(Word word)
        {
            if (IfUse() == false)
            {
                wordPool.Add(word);
            }
            else
                throw new WordException("Jakiś obiekt jest już używany");
        }

        public static Word Get(int x)
        {
            if (IfUse() == false && wordPool.Count > x)
            {
                wordPool[x].SetInUse(true);
                return wordPool[x];
            }
            else
                throw new WordException("Jakiś obiekt jest już używany lub nie ma słowa o takim indeksie");
        }

        public static Word Get(string Name, bool PorE)
        {
            int temp = -1;
            for (int i = 0; i < wordPool.Count; i++)
            {
                if (PorE == true)//jeśli szukamy po języku polskim
                {
                    if (wordPool[i].GetPolishName() == Name)
                    {
                        temp = i;
                    }
                }
                else
                {
                    if (wordPool[i].GetEnglishName() == Name)
                    {
                        temp = i;
                    }
                }
            }
            if (IfUse() == false && temp != -1)
            {
                wordPool[temp].SetInUse(true);
                return wordPool[temp];
            }
            else
                throw new WordException("Nie ma takiego obiektu w bazie lub jakiś jest już używany");
        }

        public static void Set(int x, string pName, string eName)
        {

            if (IfUse() == false && wordPool.Count > x)
            {
                wordPool[x].SetEnglishName(eName);
                wordPool[x].SetPolishName(pName);
            }
            else
                throw new WordException("Jakiś obiekt jest już używany lub nie słowa o takim indeksie");

        }

        public static void Set(string Name, bool PorE, string pName, string eName)
        {
            int temp = -1;
            for (int i = 0; i < wordPool.Count; i++)
            {
                if (PorE == true)//jeśli szukamy po języku polskim
                {
                    if (wordPool[i].GetPolishName() == Name)
                    {
                        temp = i;
                    }
                }
                else
                {
                    if (wordPool[i].GetEnglishName() == Name)
                    {
                        temp = i;
                    }
                }
            }
            if (IfUse() == false && temp != -1)
            {
                wordPool[temp].SetEnglishName(eName);
                wordPool[temp].SetPolishName(pName);
            }
            else
                throw new WordException("Nie ma takiego obiektu w bazie lub jakiś jest już używany");
        }

        public static void Release(int x)
        {
            Word word = wordPool[x];
            if (word.GetInUse() == true && wordPool.Count > x)
            {
                wordPool[x].SetInUse(false);
            }
        }

        public static void Release(string Name, bool PorE)
        {
            Word word;
            int temp = -1;
            for (int i = 0; i < wordPool.Count; i++)
            {
                if (PorE == true)//jeśli szukamy po języku polskim Polish or English
                {
                    if (wordPool[i].GetPolishName() == Name)
                    {
                        word = wordPool[i];
                        temp = i;
                    }
                }
                else
                {
                    if (wordPool[i].GetEnglishName() == Name)
                    {
                        word = wordPool[i];
                        temp = i;
                    }
                }
            }
            if (wordPool[temp].GetInUse() == true && temp != -1)
            {
                wordPool[temp].SetInUse(false);
            }
        }

        public static void Delete(int x)
        {
            if (IfUse() == false && wordPool.Count > x)
            {
                wordPool.RemoveAt(x);
            }
            else
                throw new WordException("Jakiś obiekt jest już używany lub nie ma słówka o takim indeksie");

        }

        public static void Delete(string Name, bool PorE)
        {
            int temp = -1;
            for (int i = 0; i < wordPool.Count; i++)
            {
                if (PorE == true)//jeśli szukamy po języku polskim
                {
                    if (wordPool[i].GetPolishName() == Name)
                    {
                        temp = i;
                    }
                }
                else
                {
                    if (wordPool[i].GetEnglishName() == Name)
                    {
                        temp = i;
                    }
                }
            }
            if (IfUse() == false && temp != -1)
            {
                wordPool.RemoveAt(temp);
            }
            else
                throw new WordException("Nie ma takiego obiektu w bazie lub jakiś jest już używany");
        }

        public static void SaveToFileWords()

        {
            MyStream = new FileStream("C:\\Users\\" + Environment.UserName + "\\Desktop\\data.dat", FileMode.Create);
            BinaryFormatter MyFormatter = new BinaryFormatter();
            MyFormatter.Serialize(MyStream, WordPool.GetWordPool());
            MyStream.Close();
        }

        public static void LoadFromFileWords()
        {
            MyStream = new FileStream("C:\\Users\\" + Environment.UserName + "\\Desktop\\data.dat", FileMode.OpenOrCreate);
            BinaryFormatter MyFormatter = new BinaryFormatter();
            if (MyStream.Length != 0)
            {
                wordPool = (List<Word>)MyFormatter.Deserialize(MyStream);
            }
            MyStream.Close();
            FileInfo F = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Desktop\\data.dat");
            if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\data.dat"))
            {
                F.Delete();
            }

        }

    }


}
