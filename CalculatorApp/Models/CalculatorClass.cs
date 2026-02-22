namespace CalculatorApp.Models
{
    public class CalculatorClass
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; } = 0;

        public double PerformOperation()
        {
            switch (Operation)
            {
                case "add":
                    Result = Number1 + Number2;
                    break;
                case "subtract":
                    Result = Number1 - Number2;
                    break;
                case "multiply":
                    Result = Number1 * Number2;
                    break;
                case "divide":
                    if (Number2 == 0)
                        throw new DivideByZeroException("Cannot divide by zero.");
                    Result = Number1 / Number2;
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation. Use 'add', 'subtract', 'multiply', or 'divide'.");
            }
            return Result;
        }
    }
}
