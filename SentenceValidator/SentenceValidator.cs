using System.Text.RegularExpressions;

namespace SentenceValidator
{
	public class SentenceValidator
	{
		private readonly string sentence = string.Empty;
		public readonly string invalidCapitals = " Sentence does not start with a capital. \n";
		public readonly string invalidPeriods = " Sentence has incorrect ending puncuation \n";
		public readonly string invalidQuotes = " Uneven number of quotations \n";
		public readonly string invalidNumericFormat = " Incorrect number format \n";

		public SentenceValidator() { }

		public SentenceValidator(string sentence)
		{
            this.sentence = sentence;
		}

		public SentenceValidationInformation IsSentenceValid()
        {
			// Result to be returned to the program.
            // Assuming that the sentence is valid unless proven otherwise.
			var result = new SentenceValidationInformation();
			result.IsSentenceValid = true;

			var listOfWords = DecomposeSentenceToList(this.sentence);

			if (!StringStartsWithCapital(listOfWords.FirstOrDefault()))
			{
				result.IsSentenceValid = false;
                result.ValidationMessage += invalidCapitals;
			}

			if (!ListEndsWithPeriod(listOfWords.LastOrDefault()))
            {
				result.IsSentenceValid = false;
				result.ValidationMessage += invalidPeriods;

			}
			if (!ListHasEvenQuotations(sentence))
            {
				result.IsSentenceValid = false;
				result.ValidationMessage += invalidQuotes;
			}

			if (!IsCorrectNumberFormat(listOfWords))
            {
				result.IsSentenceValid = false;
				result.ValidationMessage += invalidNumericFormat;
			}

			return result;

        }

		public bool StringStartsWithCapital(string firstWord)
        {
			if (firstWord == string.Empty) return false;
			var firstLetterInWord = firstWord.ToCharArray()[0];
			var secondLetterInWord = firstLetterInWord;
			if (firstWord.Length > 1) secondLetterInWord = firstWord.ToCharArray()[1];
			// Account for sentences begining with quotes.
			if (Char.IsUpper(firstLetterInWord) ||
				(firstLetterInWord == '"' && Char.IsUpper(secondLetterInWord)))
				return true;
			return false;
        }

		public bool ListEndsWithPeriod(string lastWord)
        {
			var validChars = new List<char> { '.', '!', '?' };
			var lastWordChars = lastWord.ToCharArray();
			var lastChar = lastWordChars.LastOrDefault();
		
			// if the last char is a quotation, ensure second last is a period
			if (lastChar == '"')
				return validChars.Contains(lastWordChars[lastWordChars.Length - 2]);

			return validChars.Contains(lastChar);
        }

		public bool ListHasEvenQuotations(string sentence)
        {
			var rx = new Regex("\"");
			return rx.Matches(sentence).Count % 2 == 0;
        }

		public bool IsCorrectNumberFormat(List<string> sentence)
        {
			var rx = new Regex(@"\d+");
			if(sentence.Count() > 0 )
            {
				foreach (var word in sentence)
                {
					// removing all puncuation from a word to allow for '20, 10' for example
					var processableWord = Regex.Replace(word, @"[^\w\d\s]", "");
					// char needs converted to a string to try parse it to an int
					if (int.TryParse(processableWord.ToString(), out int number))
						if (number < 13) return false;
				}
				return true;
			} else {
				return false;
           }
			
        }

		private List<string> DecomposeSentenceToList(string sentence)
        {
			return sentence.Split(" ").ToList();
        }
	}
}

