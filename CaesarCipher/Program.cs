using System.Text;

Console.WriteLine("Hello, lets encode your message!");
Console.WriteLine("Type your message:");
string messageToEncode = Console.ReadLine();
Console.WriteLine("Enter the algorithm shift:");
string shift = Console.ReadLine();

int.TryParse(shift, out int letterShift);

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

StringBuilder encodedMessage = new StringBuilder();


foreach (var stringCharacter in messageToEncode)
{
    char encodedLetter = stringCharacter;

    if (aplhabetMap.ContainsValue(stringCharacter))
    {
        var letterKey = aplhabetMap.FirstOrDefault(y => y.Value == stringCharacter).Key;
        encodedLetter = aplhabetMap[letterKey + letterShift];
    }

    encodedMessage.Append(encodedLetter);
}

Console.WriteLine(encodedMessage.ToString());