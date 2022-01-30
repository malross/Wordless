using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle
{
    public class Guess : ObservableObject
    {
        private readonly Letter[] letters;
        private bool isSubmitted;

        public Guess(int wordLength)
        {
            letters = Enumerable.Range(1, wordLength).Select(_ => new Letter()).ToArray();
        }

        public bool IsSubmitted
        {
            get => isSubmitted;
            set => SetProperty(ref isSubmitted, value);
        }

        public bool IsReadyToSubmit => Letters.All(x => char.IsLetter(x.Character));
        public IEnumerable<Letter> Letters => letters;

        public override string ToString()
        {
            return new string(letters.Select(x => x.Character).ToArray()).Trim();
        }

        internal void SetValue(string value)
        {
            var padded = value.PadRight(letters.Length).ToUpperInvariant();
            for (var i = 0; i < letters.Length; ++i)
            {
                letters[i].Character = padded[i];
            }

            OnPropertyChanged(nameof(IsReadyToSubmit));
        }

        internal void SubmitAndCompareToAnswer(string answer)
        {
            for (var i = 0; i < letters.Length; ++i)
            {
                letters[i].Status =
                    answer[i] == letters[i].Character ? LetterStatus.InRightPlace :
                    answer.Contains(letters[i].Character) ? LetterStatus.InWrongPlace :
                    LetterStatus.NotInWord;
            }

            IsSubmitted = true;
        }
    }
}
