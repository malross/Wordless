using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Wordle
{
    public class Game : ObservableObject
    {
        private const int MaxGuesses = 6;
        private readonly WordList wordList;

        public Game(GameSettings settings)
        {
            wordList = settings.WordList;
            Answer = wordList.RandomWordOfLength(settings.WordLength);
            Guesses = Enumerable.Range(1, MaxGuesses).Select(_ => new Guess(settings.WordLength)).ToList();
        }

        public string Answer { get; }
        public IEnumerable<Guess> Guesses { get; private set; }
        public bool IsInProgress { get => !Guesses.Any(x => x.ToString() == Answer) && Guesses.Count(x => x.IsSubmitted) < MaxGuesses; }
        public bool CanGuess { get => IsInProgress && Guesses.First(x => !x.IsSubmitted).IsReadyToSubmit; }

        public string CurrentGuess
        {
            get
            {
                return IsInProgress ? Guesses.First(x => !x.IsSubmitted).ToString() : string.Empty;
            }
            set
            {
                if (!IsInProgress)
                    throw new InvalidOperationException("Should not be able to guess when there's no game in progress!");

                Guesses.First(x => !x.IsSubmitted).SetValue(value);
            }
        }
    }
}
