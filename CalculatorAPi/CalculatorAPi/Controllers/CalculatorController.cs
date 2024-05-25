using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{fNumber}/{sNumber}")]
        public IActionResult soma(string fNumber, string sNumber)
        {
            if (IsNumeric(fNumber) && IsNumeric(sNumber))
            {
                var sum = ConvertToInt(fNumber) + ConvertToInt(sNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtracao/{fNumber}/{sNumber}")]
        public IActionResult subtracao(string fNumber, string sNumber)
        {
            if (IsNumeric(fNumber) && IsNumeric(sNumber))
            {
                var sum = ConvertToInt(fNumber) - ConvertToInt(sNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplicacao/{fNumber}/{sNumber}")]
        public IActionResult multiplicacao(string fNumber, string sNumber)
        {
            if (IsNumeric(fNumber) && IsNumeric(sNumber))
            {
                var sum = ConvertToInt(fNumber) * ConvertToInt(sNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divisao/{fNumber}/{sNumber}")]
        public IActionResult divisao(string fNumber, string sNumber)
        {
            if (IsNumeric(fNumber) && IsNumeric(sNumber))
            {
                var sum = ConvertToInt(fNumber) / ConvertToInt(sNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number); 

            return isNumber;
        }

        private decimal ConvertToInt(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) {
                return decimalValue;
            }
            return 0;
        }
    }
}
