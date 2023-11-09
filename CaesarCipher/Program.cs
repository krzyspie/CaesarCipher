using CaesarCipher;

Console.WriteLine("Hello, lets encode your message!");

string messageToEncode = GetMessageToEncode();

int algorithmShift = GetAlgorithmShift(Constants.aplhabetMap);

AlgorithmService algorithmService = new();

string encidedMessage = algorithmService.Encode(messageToEncode, algorithmShift);
Console.WriteLine(encidedMessage);

static string GetMessageToEncode()
{
    string message = string.Empty;
    while (string.IsNullOrWhiteSpace(message))
    {
        Console.WriteLine("Type your message:");
        message = Console.ReadLine();
    }

    return message;
}

static int GetAlgorithmShift(Dictionary<int, char> aplhabetMap)
{
    int algorithmShift = 0;
    bool isNumber = false;
    while (!isNumber)
    {
        Console.WriteLine("Enter the algorithm shift:");
        string shiftGivenByTheUser = Console.ReadLine();
        isNumber = int.TryParse(shiftGivenByTheUser, out int parsedUserShift);
        algorithmShift = parsedUserShift % aplhabetMap.Count;
    }

    return algorithmShift;
}