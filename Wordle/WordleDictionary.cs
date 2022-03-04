using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DictionarySearch;

namespace Wordle
{
    public class WordleDictionary : WordDictionary
    {
        private static Random random;
        private static List<string> innerDictionary;
        public static void Initalize()
        {
            innerDictionary = Instance.Search(5, "", SearchConditon.None, false).Select(x => x.ToUpper()).ToList();
            random = new Random();
        }

        public static bool IsWord(string word)
        {
            return innerDictionary.Contains(word, StringComparer.OrdinalIgnoreCase);
        }

        public static string RandomWord()
        {
            return innerDictionary[random.Next(0, innerDictionary.Count)];
        }

    }
}
