namespace SentenceValidator
{
	public class SentenceValidator
	{
		private readonly string sentence = string.Empty;

		public SentenceValidator() { }

		public SentenceValidator(string sentence)
		{
            this.sentence = sentence;
		}

		// change this so method returns a validation message
		public bool IsSentenceValid()
        {
			var listOfWords = DecomposeSentenceToList(this.sentence);
			if (StringStartsWithCapital(listOfWords.FirstOrDefault()) &&
				ListEndsWithPeriod(listOfWords) &&
				ListHasEvenQuotations(listOfWords) &&
				IsCorrectNumberFormat(listOfWords))
				return true;
			return false;
        }

		public bool StringStartsWithCapital(string word)
        {
			return false;
        }

		public bool ListEndsWithPeriod(List<string> sentence)
        {
			return false;
        }

		public bool ListHasEvenQuotations(List<string> sentence)
        {
			return false;
        }

		private bool IsCorrectNumberFormat(List<string> sentence)
        {
			return false;
        }

		private List<string> DecomposeSentenceToList(string sentance)
        {
			return new List<string> { "" };
        }
	}
}

