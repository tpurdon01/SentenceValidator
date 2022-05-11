using System.Text.RegularExpressions;

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
				ListEndsWithPeriod(listOfWords.LastOrDefault()) &&
				ListHasEvenQuotations(sentence) &&
				IsCorrectNumberFormat(listOfWords))
				return true;
			return false;
        }

		public bool StringStartsWithCapital(string firstWord)
        {
			var firstLetterInWord = firstWord.ToCharArray()[0];
			if (Char.IsUpper(firstLetterInWord))
				return true;
			return false;
        }

		public bool ListEndsWithPeriod(string lastWord)
        {
			var lastWordChars = lastWord.ToCharArray();
			var lastChar = lastWordChars.LastOrDefault();

			// could replace with regex
			if (lastChar == '.' || lastChar == '!' || lastChar == '?')
				return true;

			return false;
        }

		public bool ListHasEvenQuotations(string sentence)
        {
			var rx = new Regex("\"");
			return rx.Matches(sentence).Count % 2 == 0;
        }

		public bool IsCorrectNumberFormat(List<string> sentence)
        {
			foreach (var word in sentence)
				// TODO: Extract to another method
				foreach (var character in word.ToCharArray())
					if (Char.IsNumber(character))
						if (int.TryParse(character.ToString(), out int number))
							// TODO: check criteria for this
							if (number < 13) return false;
			return true;
        }

		private List<string> DecomposeSentenceToList(string sentence)
        {
			return sentence.Split(" ").ToList();
        }
	}
}

