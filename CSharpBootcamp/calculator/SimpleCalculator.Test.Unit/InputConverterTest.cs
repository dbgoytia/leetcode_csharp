using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {

        private readonly InputConverter _inputConverter = new InputConverter();


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "A userId of null was inappropriately allowed.")]
        public void ConvertsDoubleThrowsArgumentExceptionWhenGivenNonNumericValue()
        {
            _ = _inputConverter.ConvertInputToNumeric("two");
        }


        [TestMethod]
        public void ConvertsStringToDoubleWhenGivenNumericValue()
        {
            Assert.AreEqual(_inputConverter.ConvertInputToNumeric("2"), 2);
        }
        
    }
}
