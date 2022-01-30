using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class WordList
    {
        private string[] allWords;
        private string name;

        private WordList(string resource, string name)
        {
            allWords = resource.Split('\n').Take(2000).Select(word => word.ToUpperInvariant()).ToArray();
            this.name = name;
        }

        public string Name => name;

        public bool Contains(string word) => allWords.Contains(word);

        public string RandomWordOfLength(int length)
        {
            var correctLengthWords = allWords.Where(w => w.Length == length).ToArray();
            var wordIndex = RandomNumberGenerator.GetInt32(correctLengthWords.Length);
            return correctLengthWords[wordIndex];
        }

        public static readonly WordList MIT = new(Properties.Resources.MIT_wordlist_10000, "MIT top 10000");
        public static readonly WordList Lexipedia = new(Properties.Resources.Lexipedia_wordlist_3_10, "Lexipedia");
    }
}
