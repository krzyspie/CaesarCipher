using CaesarCipher;
using System.Text;

Console.WriteLine("Hello, lets encode your message!");

string messageToEncode = GetMessageToEncode();

int algorithmShift = GetAlgorithmShift(Constants.aplhabetMap);

StringBuilder encodedMessage = new StringBuilder();
foreach (var stringCharacter in messageToEncode)
{
    char encodedLetter = stringCharacter;

    if (Constants.aplhabetMap.ContainsValue(stringCharacter))
    {
        var letterKey = Constants.aplhabetMap.FirstOrDefault(y => y.Value == stringCharacter).Key;
        var encodedLetterKey = 26 + (letterKey + algorithmShift);
        encodedLetter = Constants.aplhabetMap[encodedLetterKey % Constants.aplhabetMap.Count];
    }

    encodedMessage.Append(encodedLetter);
}

Console.WriteLine(encodedMessage.ToString());

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