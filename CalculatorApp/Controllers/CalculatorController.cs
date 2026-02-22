using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
