using System.Text;

namespace CaesarCipher
{
    public class AlgorithmService
    {
        public string Encode(string messageToEncode, int algorithmShift)
        {
            var shiftToApply = algorithmShift % Constants.aplhabetMap.Count;

            StringBuilder encodedMessage = new();

            foreach (var stringCharacter in messageToEncode)
            {
                char encodedCharacter = stringCharacter;

                var isUpper = char.IsUpper(encodedCharacter);

                var characterToCheck = char.ToLower(stringCharacter);
                if (Constants.aplhabetMap.ContainsValue(characterToCheck))
                {
                    var characterKey = Constants.aplhabetMap.FirstOrDefault(y => y.Value == characterToCheck).Key;
                    var encodedCharacterKey = Constants.aplhabetMap.Count + characterKey + shiftToApply;
                    encodedCharacter = Constants.aplhabetMap[encodedCharacterKey % Constants.aplhabetMap.Count];
                }

                encodedMessage.Append(isUpper ? char.ToUpper(encodedCharacter) : encodedCharacter);
            }

            return encodedMessage.ToString();
        }
    }
}
