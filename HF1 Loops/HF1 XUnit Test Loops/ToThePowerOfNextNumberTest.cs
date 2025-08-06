namespace HF1_XUnit_Test_Loops
{
    public class ToThePowerOfNextNumberTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int expected = -2;

            //Act
            int actual = HF1_Loops.Program.ToThePowerOfNextNumber(-2, 3);

            //Assert  
            Assert.Equal(expected, actual);
        }
    }
}