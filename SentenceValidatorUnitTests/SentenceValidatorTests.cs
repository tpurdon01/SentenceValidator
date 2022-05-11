using System.Collections.Generic;
using NUnit.Framework;

namespace SentenceValidatorUnitTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("Hello")]
    [TestCase("I")]
    [TestCase("Capital")]
    [TestCase("Can it handle more than one word")]
    public void StringStartsWithCapital_Test_True_Success(string validCapitalSentence)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator(); ;
        Assert.True(sentenceValidator.StringStartsWithCapital(validCapitalSentence));
    }

    [TestCase("123")]
    [TestCase("0_)()%676")]
    [TestCase("")]
    [TestCase("!One MORE for luck! :)")]
    public void StringStartsWithCapital_Test_False_Success(string validCapitalSentence)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator(); ;
        Assert.False(sentenceValidator.StringStartsWithCapital(validCapitalSentence));
    }

    [Test]
    [TestCase("!One MORE for luck! :).")]
    [TestCase("Pass.")]
    [TestCase("... ... ...")]
    [TestCase("The quick brown fox!")]
    [TestCase("What do you mean?")]
    public void ListEndsWithPeriod_Test_True_Success(string input)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        Assert.True(sentenceValidator.ListEndsWithPeriod(input));
    }

    [Test]
    [TestCase("!One MORE for luck! :)")]
    [TestCase("Pass--")]
    [TestCase("http/")]
    [TestCase("The quick brown fox")]
    [TestCase("What do you mean[]")]
    [TestCase("  ")]
    public void ListEndsWithPeriod_Test_False_Success(string input)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        Assert.False(sentenceValidator.ListEndsWithPeriod(input));
    }

    [Test]
    [TestCase("No quotes here sir")]
    [TestCase("He said \"ok\"")]
    [TestCase("\"is that right now\"")]
    [TestCase("\"\"\"\"\"\"")]
    public void ListHasEvenQuotations_Test_True_Success(string input)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        Assert.True(sentenceValidator.ListHasEvenQuotations(input));
    }

    [Test]
    [TestCase("\"One MORE for luck! :)")]
    [TestCase("what he said was \"")]
    public void ListHasEvenQuotations_Test_False_Success(string input)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        Assert.False(sentenceValidator.ListHasEvenQuotations(input));

    }

    [Test]
    public void IsCorrectNumberFormat_Test_True_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var validList1 = new List<string> { "He", "said", "\"", "twelve", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList1));

        var validList2 = new List<string> { "One", "more", "sleep", "right", "now", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList2));

        var validList3 = new List<string> { "One", "Two", "Three" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList3));

        var validList4 = new List<string> { "Four", "times", "five", "is", "20" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList4));

        var validList5 = new List<string> { "No", "quotes", "found", "here", "\"" };
        Assert.True(sentenceValidator.IsCorrectNumberFormat(validList5));
    }

    [Test]
    public void IsCorrectNumberFormat_Test_False_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var invalidList1 = new List<string> { "1", "12", "Sheep" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(invalidList1));

        var invalidList2 = new List<string> { "four", "times", "5", "is", "20" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(invalidList2));

    }
}
