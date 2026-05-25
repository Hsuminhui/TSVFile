using System.Collections.ObjectModel;

namespace TSVFile
{
    public class WordCollection : Collection<WordItem>
    {
        public void LoadFromStringArray(string[] lines)
        {
            this.Clear();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                WordItem item = new WordItem(line);
                this.Add(item);
            }
        }
    }
}