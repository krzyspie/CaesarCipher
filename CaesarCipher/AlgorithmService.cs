using System.Text;

namespace CaesarCipher
{
    public class AlgorithmService
    {
        public string Encode(string messageToEncode, int algorithmShift)
        {
            var shiftToApply = CalculateShift(algorithmShift);

            string encodedMessage = EncodeMessage(messageToEncode, shiftToApply);

            return encodedMessage;
        }

        private string EncodeMessage(string messageToEncode, int shiftToApply)
        {
            StringBuilder encodedMessage = new();

            foreach (var stringCharacter in messageToEncode)
            {
                char encodedCharacter = stringCharacter;

                var isUpper = char.IsUpper(encodedCharacter);

                var characterToCheck = char.ToLower(stringCharacter);
                if (Constants.aplhabetMap.ContainsValue(characterToCheck))
                {
                    var characterKey = Constants.aplhabetMap.FirstOrDefault(y => y.Value == characterToCheck).Key;
                    int encodedCharacterKey = CalculateEncodedCharacterKey(characterKey, shiftToApply);
                    encodedCharacter = Constants.aplhabetMap[encodedCharacterKey];
                }

                encodedMessage.Append(isUpper ? char.ToUpper(encodedCharacter) : encodedCharacter);
            }

            return encodedMessage.ToString();
        }

        private int CalculateShift(int shift)
        {
            return shift % Constants.aplhabetMap.Count;
        }

        private int CalculateEncodedCharacterKey(int characterKey, int shift)
        {
            var encodedCharacterKey = Constants.aplhabetMap.Count + characterKey + shift;
            return CalculateShift(encodedCharacterKey);
        }
    }
}
