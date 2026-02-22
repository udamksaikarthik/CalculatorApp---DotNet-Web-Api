using System.ComponentModel.DataAnnotations;

namespace CalculatorApp.Models
{
    public class CalculatorClass
    {
        [Required(ErrorMessage = "Number1 is required.")]
        public double Number1 { get; set; }
        [Required(ErrorMessage = "Number2 is required.")]
        public double Number2 { get; set; }

        [Required(ErrorMessage = "Operation is required.")]
        [RegularExpression("add|subtract|multiply|divide",
            ErrorMessage = "Operation must be add, subtract, multiply, or divide.")]
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
                    Result = Number1 / Number2;
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation. Use 'add', 'subtract', 'multiply', or 'divide'.");
            }
            return Result;
        }
    }
}
