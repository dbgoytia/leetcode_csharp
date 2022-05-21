using System;
namespace Calculator
{
    public class InputConverter
    {
        public double ConvertInputToNumeric(string argTextInput)
        {
            double convertedInput;
            if (!double.TryParse(argTextInput, out convertedInput)) throw new ArgumentException("Expected a numeric value");
            return convertedInput;
            // Note here that we did not add a try-catch as it would be redundant
            // If you think about it, all it would do is re-throw the exception
            // which might end-up adding a lot of information to the log, however
            // some projects like this approach and depends on coding style
        }
    }
}
