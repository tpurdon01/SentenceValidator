using System.Collections.Generic;
using NUnit.Framework;

namespace SentenceValidatorUnitTests;

public class Tests
{

    SentenceValidator.SentenceValidator sentenceValidator = new SentenceValidator.SentenceValidator();

    [TestCase("The quick brown fox said \"hello Mr Lazy dog\".")]
    [TestCase("The quick brown fox said hello Mr lazy dog.")]
    [TestCase("One lazy dog is too few, 13 is too many.")]
    [TestCase("One lazy dog is too few, thirteen is too many.")]
    public void IsSentenceValid_Test_True(string validCapitalSentence)
    {
        var newValidator = new SentenceValidator.SentenceValidator(validCapitalSentence);
        var validationInfo = newValidator.IsSentenceValid();
        Assert.True(validationInfo.IsSentenceValid);
        Assert.Null(validationInfo.ValidationMessage);
    }

    [TestCase("the quick brown fox said \"hello Mr lazy dog\".")]
    public void IsSentenceValid_Test_False_Capitals(string validCapitalSentence)
    {
        var newValidator = new SentenceValidator.SentenceValidator(validCapitalSentence);
        var validationInfo = newValidator.IsSentenceValid();
        Assert.False(validationInfo.IsSentenceValid);
        Assert.AreEqual(" Sentence does not start with a capital. \n", validationInfo.ValidationMessage);
    }

    [TestCase("\"The quick brown fox said \"hello Mr Lazy dog\".")]
    public void IsSentenceValid_Test_False_Quotes(string validCapitalSentence)
    {
        var newValidator = new SentenceValidator.SentenceValidator(validCapitalSentence);
        var validationInfo = newValidator.IsSentenceValid();
        Assert.False(validationInfo.IsSentenceValid);
        Assert.AreEqual(" Uneven number of quotations \n", validationInfo.ValidationMessage);
    }

    [TestCase("There is no punctuation in this sentence")]
    [TestCase("\"The quick brown fox said \"hello Mr. Lazy dog\".")]
    public void IsSentenceValid_Test_False_Periods(string validCapitalSentence)
    {
        var newValidator = new SentenceValidator.SentenceValidator(validCapitalSentence);
        var validationInfo = newValidator.IsSentenceValid();
        Assert.False(validationInfo.IsSentenceValid);
        Assert.AreEqual(" Sentence has incorrect ending puncuation \n", validationInfo.ValidationMessage);
    }

    [TestCase("One lazy dog is too few, 12 is too many.")]
    [TestCase("Are there 11, 12, or 13 lazy dogs?")]
    public void IsSentenceValid_Test_False_Numbers(string validCapitalSentence)
    {
        var newValidator = new SentenceValidator.SentenceValidator(validCapitalSentence);
        var validationInfo = newValidator.IsSentenceValid();
        Assert.False(validationInfo.IsSentenceValid);
        Assert.AreEqual(" Incorrect number format \n", validationInfo.ValidationMessage);
    }

    [TestCase("Hello")]
    [TestCase("I")]
    [TestCase("Capital")]
    [TestCase("Can it handle more than one word")]
    public void StringStartsWithCapital_Test_True_Success(string validCapitalSentence)
    {
        Assert.True(sentenceValidator.StringStartsWithCapital(validCapitalSentence));
    }

    [TestCase("123")]
    [TestCase("0_)()%676")]
    [TestCase("")]
    [TestCase("!One MORE for luck! :)")]
    public void StringStartsWithCapital_Test_False_Success(string validCapitalSentence)
    {
        Assert.False(sentenceValidator.StringStartsWithCapital(validCapitalSentence));
    }

    [Test]
    [TestCase("!One MORE for luck! :).")]
    [TestCase("Pass.")]
    [TestCase("... ... ...")]
    [TestCase("The quick brown fox!")]
    [TestCase("What do you mean?")]
    [TestCase("Did we account for \"this?\"")]
    public void ListEndsWithPeriod_Test_True_Success(string input)
    {
        Assert.True(sentenceValidator.ListEndsWithPeriod(input));
    }

    [Test]
    [TestCase("!One MORE for luck! :)")]
    [TestCase("Pass--")]
    [TestCase("http/")]
    [TestCase("The quick brown fox")]
    [TestCase("What do you mean[]")]
    [TestCase("  ")]
    [TestCase("")]
    public void ListEndsWithPeriod_Test_False_Success(string input)
    {
        Assert.False(sentenceValidator.ListEndsWithPeriod(input));
    }

    [Test]
    [TestCase("No quotes here sir")]
    [TestCase("He said \"ok\"")]
    [TestCase("\"is that right now\"")]
    [TestCase("\"\"\"\"\"\"")]
    [TestCase("What do you mean by \"this\"?")]
    [TestCase("")]
    public void ListHasEvenQuotations_Test_True_Success(string input)
    {
        Assert.True(sentenceValidator.ListHasEvenQuotations(input));
    }

    [Test]
    [TestCase("\"One MORE for luck! :)")]
    [TestCase("what he said was \"")]
    [TestCase("\"")]
    public void ListHasEvenQuotations_Test_False_Success(string input)
    {
        Assert.False(sentenceValidator.ListHasEvenQuotations(input));

    }

    [Test]
    public void IsCorrectNumberFormat_Test_True_Success()
    {
        var validList1 = new List<string> { "He", "said", "\"", "twelve", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList1));

        var validList2 = new List<string> { "One", "more", "sleep", "right", "now", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList2));

        var validList3 = new List<string> { "One", "Two", "Three" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList3));

        var validList4 = new List<string> { "Four", "times", "five", "is", "20" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList4));

        var validList5 = new List<string> { "No", "numbers", "found", "here", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList5));
    }

    [Test]
    public void IsCorrectNumberFormat_Test_False_Success()
    {
        var invalidList1 = new List<string> { "1", "12", "Sheep" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(invalidList1));

        var invalidList2 = new List<string> { "four", "times", "5", "is", "20" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(invalidList2));

        var invalidList3 = new List<string>(); ;
        Assert.False(sentenceValidator.IsCorrectNumberFormat(invalidList3));

    }
}
