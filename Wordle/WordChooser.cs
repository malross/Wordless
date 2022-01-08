using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    internal static class ChooseWord
    {
        internal static string OfLength(int length)
        {
            var allWords = Properties.Resources.MIT_wordlist_10000.Split('\n');
            var correctLengthWords = allWords.Where(w => w.Length == length).ToArray();
            return correctLengthWords[RandomNumberGenerator.GetInt32(correctLengthWords.Length)];
        }
    }
}
