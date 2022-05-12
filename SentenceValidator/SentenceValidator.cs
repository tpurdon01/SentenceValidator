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
		public SentenceValidationInformation IsSentenceValid()
        {
			var isValid = false;
			var outputMsg = string.Empty;

			var listOfWords = DecomposeSentenceToList(this.sentence);

			if (StringStartsWithCapital(listOfWords.FirstOrDefault()))
            {
				if (ListEndsWithPeriod(listOfWords.LastOrDefault()))
				{
					if (ListHasEvenQuotations(sentence))
					{
						if (IsCorrectNumberFormat(listOfWords))
						{
							outputMsg = "Sentence is valid!";
							isValid = true;
						} else
                        {
							outputMsg = "Incorrect number format";
                        }
					} else
                    {
						outputMsg = "Uneven number of quotations";
                    }
				} else
                {
					outputMsg = "Sentence has incorrect ending puncuation";
                }
			} else
            {
				outputMsg = " Sentence does not start with a capital";
            }

			return new SentenceValidationInformation
			{
				IsSentenceValid = isValid,
				ValidationMessage = outputMsg
			};

        }

		public bool StringStartsWithCapital(string firstWord)
        {
			if (firstWord == string.Empty) return false;
			var firstLetterInWord = firstWord.ToCharArray()[0];
			if (Char.IsUpper(firstLetterInWord))
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
			if(sentence.Count() > 0 )
            {
				foreach (var word in sentence)
					if (int.TryParse(word.ToString(), out int number))
						if (number <= 13) return false;
				return true;
			} else
            {
				return false;
            }
			
        }

		private List<string> DecomposeSentenceToList(string sentence)
        {
			return sentence.Split(" ").ToList();
        }
	}
}

