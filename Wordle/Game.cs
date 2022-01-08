using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Game
    {
        public Game(string answer)
        {
            Answer = answer;
            Guesses = Enumerable.Range(1, 6).Select(_ => new Guess(answer.Length)).ToList();
        }

        public string Answer { get; }
        public IEnumerable<Guess> Guesses { get; private set; }
    }
}
