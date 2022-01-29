using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class GameSettings
    {
        public int WordLength { get; set; } = 5;
        public WordList WordList = WordList.MIT;
    }
}
