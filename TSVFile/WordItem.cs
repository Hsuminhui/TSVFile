using System;
using System.Linq;

namespace TSVFile
{
    public class WordItem
    {
        public string Word { get; set; }
        public string Phonogram { get; set; }
        public string SoundPath { get; set; }
        public string Explain { get; set; }

        public WordItem(string str)
        {
            string[] strLists = str.Split('\t');

            if (strLists.Length >= 3)
            {
                Word = strLists[0];
                Phonogram = strLists[1];
                SoundPath = strLists[2];
                Explain = string.Join(Environment.NewLine, strLists.Skip(3));
            }
        }

        public override string ToString()
        {
            return Word;
        }
    }
}