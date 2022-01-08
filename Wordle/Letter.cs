namespace Wordle
{
    public class Letter
    {
        public Letter()
        {
            Character = ' ';
            Status = LetterStatus.NotSubmitted;
        }

        public char Character { get; set; }
        public LetterStatus Status { get; set; }
    }

    public enum LetterStatus
    {
        NotSubmitted,
        NotInWord,
        InWrongPlace,
        InRightPlace
    }
}