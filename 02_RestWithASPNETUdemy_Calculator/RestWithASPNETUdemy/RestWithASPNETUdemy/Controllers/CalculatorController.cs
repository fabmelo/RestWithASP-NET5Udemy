using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("{operation}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operation, string firstNumber, string secondNumber)
        {
           if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal value;

                switch (operation)
                {
                    case "sum":
                        {
                            value = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                            return Ok(value.ToString());
                        }
                    case "sub":
                        {
                            value = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                            return Ok(value.ToString());
                        }
                    case "mult":
                        {
                            value = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                            return Ok(value.ToString());
                        }
                    case "div":
                        {
                            value = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                            return Ok(value.ToString());
                        }
                }
               
                
            }
            return BadRequest("Invalid input");
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

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
      
    }
}
