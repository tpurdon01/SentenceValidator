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
    [TestCase("O_)()%676")]
    [TestCase("")]
    [TestCase("!One MORE for luck! :)")]
    public void StringStartsWithCapital_Test_False_Success(string validCapitalSentence)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator(); ;
        Assert.False(sentenceValidator.StringStartsWithCapital(validCapitalSentence));
    }

    [Test]
    public void ListEndsWithPeriod_Test_True_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var validList1 = new List<string> { "The", "Quick", "Brown", "Fox", "." };
        Assert.True(sentenceValidator.ListEndsWithPeriod(validList1));

        var validList2 = new List<string> { ".", ".", "." };
        Assert.True(sentenceValidator.ListEndsWithPeriod(validList2));

        var validList3 = new List<string> { "No", "WAY", "!" };
        Assert.True(sentenceValidator.ListEndsWithPeriod(validList3));

        var validList4 = new List<string> { "What", "do", "mean", "here", "?" };
        Assert.True(sentenceValidator.ListEndsWithPeriod(validList4));
    }

    [Test]
    public void ListEndsWithPeriod_Test_False_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var invalidList1 = new List<string> { "The", "Quick", "Brown", "Fox"};
        Assert.False(sentenceValidator.ListEndsWithPeriod(invalidList1));

        var invalidList2 = new List<string> { "", " ", "   " };
        Assert.False(sentenceValidator.ListEndsWithPeriod(invalidList2));

        var invalidList3 = new List<string> { "No", "WAY", "," };
        Assert.False(sentenceValidator.ListEndsWithPeriod(invalidList3));

        var invalidList4 = new List<string> { "What", "do", "mean", "here", "123" };
        Assert.False(sentenceValidator.ListEndsWithPeriod(invalidList4));
    }

    [Test]
    public void ListHasEvenQuotations_Test_True_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var validList1 = new List<string> { "He", "said", "\"", "ok", "\""};
        Assert.False(sentenceValidator.ListHasEvenQuotations(validList1));

        var validList2 = new List<string> { "\"", "Is", "that", "right", "now", "\"" };
        Assert.False(sentenceValidator.ListHasEvenQuotations(validList2));

        var validList3 = new List<string> { "\"No\"", "\"Thank", "you\"" };
        Assert.False(sentenceValidator.ListHasEvenQuotations(validList3));

        var validList4 = new List<string> { "\"", "\"", "\"", "\"", "\"" };
        Assert.False(sentenceValidator.ListHasEvenQuotations(validList4));

        var validList5 = new List<string> { "No", "quotes", "found", "here", "\"" };
        Assert.False(sentenceValidator.ListHasEvenQuotations(validList5));
    }

    [Test]
    public void ListHasEvenQuotations_Test_False_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var invalidList1 = new List<string> { "\""};
        Assert.False(sentenceValidator.ListHasEvenQuotations(invalidList1));

        var invalidList2 = new List<string> { "\"","he", "said", "," };
        Assert.False(sentenceValidator.ListHasEvenQuotations(invalidList2));

    }

    [Test]
    public void IsCorrectNumberFormat_Test_True_Success()
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator();
        var validList1 = new List<string> { "He", "said", "\"", "twelve", "\"" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(validList1));

        var validList2 = new List<string> { "One", "more", "sleep", "right", "now", "\"" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(validList2));

        var validList3 = new List<string> { "One", "Two", "Three" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(validList3));

        var validList4 = new List<string> { "Four", "times", "five", "is", "20" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(validList4));

        var validList5 = new List<string> { "No", "quotes", "found", "here", "\"" };
        Assert.False(sentenceValidator.IsCorrectNumberFormat(validList5));
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
