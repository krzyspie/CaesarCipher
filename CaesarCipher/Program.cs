using System.Text;

Dictionary<int, char> aplhabetMap = new Dictionary<int, char>()
{
    { 0, 'a' },
    { 1, 'b' },
    { 2, 'c' },
    { 3, 'd' },
    { 4, 'e' },
    { 5, 'f' },
    { 6, 'g' },
    { 7, 'h' },
    { 8, 'i' },
    { 9, 'j' },
    { 10, 'k' },
    { 11, 'l' },
    { 12, 'm' },
    { 13, 'n' },
    { 14, 'o' },
    { 15, 'p' },
    { 16, 'q' },
    { 17, 'r' },
    { 18, 's' },
    { 19, 't' },
    { 20, 'u' },
    { 21, 'v' },
    { 22, 'w' },
    { 23, 'x' },
    { 24, 'y' },
    { 25, 'z' },
};

Console.WriteLine("Hello, lets encode your message!");

string messageToEncode = GetMessageToEncode();

int algorithmShift = GetAlgorithmShift(aplhabetMap);

StringBuilder encodedMessage = new StringBuilder();
foreach (var stringCharacter in messageToEncode)
{
    char encodedLetter = stringCharacter;

    if (aplhabetMap.ContainsValue(stringCharacter))
    {
        var letterKey = aplhabetMap.FirstOrDefault(y => y.Value == stringCharacter).Key;
        var encodedLetterKey = 26 + (letterKey + algorithmShift);
        encodedLetter = aplhabetMap[encodedLetterKey % aplhabetMap.Count];
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