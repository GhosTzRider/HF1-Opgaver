namespace HF1_XUnit_Test_Loops
{
    public class ToThePowerOfNextNumberTest
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            int expected = -8;
            HF1_Loops.Program program = new HF1_Loops.Program();   
            //Act
            int actual = program.ToThePowerOfNextNumber(-2, 3);

            //Assert  
            Assert.Equal(expected, actual);
        }
    }
}