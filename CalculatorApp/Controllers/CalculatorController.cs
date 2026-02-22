using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CalculatorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to the Calculator API! Use POST /api/calculator with a JSON body to perform calculations.");
        }

        [HttpPost]
        public IActionResult Post([FromBody] CalculatorApp.Models.CalculatorClass calculator)
        {
            calculator.Operation = calculator.Operation.ToLower().Trim();
            if (calculator == null)
            {
                return BadRequest(new { Error = "Invalid input. Please provide a valid JSON body." });
            }
            else
            {
                if(calculator.Operation != "add" && calculator.Operation != "subtract" && calculator.Operation != "multiply" && calculator.Operation != "divide")
                {
                    return BadRequest(new { Error = "Invalid operation. Supported operations are: add, subtract, multiply, divide." });
                }
                if (calculator.Operation == "divide" && calculator.Number2 == 0)
                {
                    return BadRequest(new { Error = "Division by zero is not allowed." });
                }
            }

            try
            {
                double result = calculator.PerformOperation();
                return Ok(new { Result = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

    }
}
