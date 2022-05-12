Console.WriteLine("Hello, and welcome to the sentence validator!");
var cont = "y";
do
{
    try
    {
        Console.WriteLine("Please enter the sentence you would like to validate below:");
        var sentenceToValidate = Console.ReadLine();
        if (sentenceToValidate is not null || sentenceToValidate != string.Empty)
        {
            var sentenceValidator = new SentenceValidator.SentenceValidator(sentenceToValidate);
            var sentenceInfo = sentenceValidator.IsSentenceValid();
            if (sentenceInfo.IsSentenceValid)
            {
                Console.WriteLine("Passed");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            Console.WriteLine(sentenceInfo.ValidationMessage);
            Console.WriteLine("----------------------");
            Console.WriteLine("Would you like to validate another sentence? (y/n)");
            cont = Console.ReadLine();
            continue;
        }
        else
        {
            throw new Exception();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error! {0}", ex.Message);
    }
} while (cont == "y");


