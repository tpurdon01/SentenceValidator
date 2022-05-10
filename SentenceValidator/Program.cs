Console.WriteLine("Hello, and welcome to the sentence validator!");
Console.WriteLine("Please enter the sentence you would like to validate below:");
try
{
    var sentenceToValidate = Console.ReadLine();
    if (sentenceToValidate is not null || sentenceToValidate != string.Empty)
    {
        var sentenceValidator = new SentenceValidator.SentenceValidator(sentenceToValidate);
    }
    else
    {
        throw new Exception();
    }
} catch(Exception ex)
{
    Console.WriteLine($"Error! {0}", ex.Message);
}

