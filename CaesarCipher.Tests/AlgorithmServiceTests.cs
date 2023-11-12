namespace CaesarCipher.Tests
{
    public class AlgorithmServiceTests
    {

        [Theory]
        [InlineData(0, "Test Message!")]
        [InlineData(15, "Ithi Bthhpvt!")]
        [InlineData(90, "Fqef Yqeemsq!")]
        [InlineData(-9, "Kvjk Dvjjrxv!")]
        [InlineData(-62, "Juij Cuiiqwu!")]
        public void EncodeMessage_ShiftAndMessageProvided(int shift, string expectedResult)
        {
            //Arrenge
            string message = "Test Message!";

            AlgorithmService service = new();

            //Act
            string result = service.Encode(message, shift);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void EmptyMessage_MessageNotProvided()
        {
            //Arrenge
            AlgorithmService service = new();

            //Act
            string result = service.Encode(string.Empty, 2);

            //Assert
            Assert.Equal(string.Empty, result);
        }
    }
}