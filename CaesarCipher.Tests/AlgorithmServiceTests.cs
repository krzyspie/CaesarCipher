namespace CaesarCipher.Tests
{
    public class AlgorithmServiceTests
    {

        [Theory]
        [InlineData(0, "test message!")]
        [InlineData(15, "ithi bthhpvt!")]
        [InlineData(90, "fqef yqeemsq!")]
        [InlineData(-9, "kvjk dvjjrxv!")]
        [InlineData(-62, "juij cuiiqwu!")]
        public void Test1(int shift, string expectedResult)
        {
            //Arrenge
            string message = "test message!";

            AlgorithmService service = new();

            //Act
            string result = service.Encode(message, shift);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}