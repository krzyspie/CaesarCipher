using System.Text;

namespace CaesarCipher
{
    public class AlgorithmService
    {
        public string Encode(string messageToEncode, int algorithmShift)
        {
            StringBuilder encodedMessage = new();
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
            return encodedMessage.ToString();
        }
    }
}
