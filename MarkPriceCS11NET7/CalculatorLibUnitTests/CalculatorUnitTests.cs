using CalculatorLib;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
            double a = 2;
            double b = 2;
            double expected = 4;

            Calculator c = new();

            double actual = c.Add(a, b);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestAdding2And3()
        {
            double a = 2;
            double b = 3;
            double expected = 5;

            Calculator c = new();

            double actual = c.Add(a, b);

            Assert.Equal(expected, actual);
        }
    }
}