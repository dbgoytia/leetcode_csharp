using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOperations()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("add", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOperations()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SubstractsTwoNumbersAndReturnsValidResultForNonSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("substract", number1, number2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void SubstractsTwoNumbersAndReturnsValidResultForSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("-", number1, number2);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("multiply", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("*", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForNonSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("divide", number1, number2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForSymbolOperations()
        {
            int number1 = 2;
            int number2 = 1;
            double result = _calculatorEngine.Calculate("/", number1, number2);
            Assert.AreEqual(2, result);
        }
    }
}
