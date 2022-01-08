using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Guess
    {
        public Guess(int wordLength)
        {
            Letters = Enumerable.Range(1, wordLength).Select(_ => new Letter()).ToList();
        }

        public bool IsSubmitted { get; }
        public IEnumerable<Letter> Letters { get; private set; }
    }
}
