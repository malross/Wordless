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
            allWords = resource.Split('\n').Select(word => word.ToUpperInvariant()).ToArray();
            this.name = name;
        }

        public string Name => name;

        public bool Contains(string word) => allWords.Contains(word);

        public string RandomWordOfLength(int length)
        {
            var correctLengthWords = allWords.Where(w => w.Length == length).ToArray();
            return correctLengthWords[RandomNumberGenerator.GetInt32(correctLengthWords.Length)];
        }

        public static readonly WordList MIT = new(Properties.Resources.MIT_wordlist_10000, "MIT top 10000");
    }
}
