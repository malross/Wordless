using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Wordle
{
    public class Letter : ObservableObject
    {
        private char character;
        private LetterStatus status;

        public Letter()
        {
            Character = ' ';
            Status = LetterStatus.NotSubmitted;
        }

        public char Character
        {
            get => character;
            set => SetProperty(ref character, value);
        }

        public LetterStatus Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
    }

    public enum LetterStatus
    {
        NotSubmitted,
        NotInWord,
        InWrongPlace,
        InRightPlace
    }
}