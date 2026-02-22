namespace CalculatorApp.Models
{
    public class CalculatorClass
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; } = 0;

        private double PerformOperation()
        {
            return Operation switch
            {
                "add" => Number1 + Number2,
                "subtract" => Number1 - Number2,
                "multiply" => Number1 * Number2,
                "divide" => Number2 != 0 ? Number1 / Number2 : throw new DivideByZeroException("Cannot divide by zero."),
                _ => throw new InvalidOperationException("Invalid operation. Use 'add', 'subtract', 'multiply', or 'divide'.")
            };
        }
    }
}
