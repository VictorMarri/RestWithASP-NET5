using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace RestWithASPNETFive.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtraction.ToString());
               
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multiplication.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult GetAverage(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var average = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;
                return Ok(average.ToString());

            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("squareRoot/{firstNumber}")]
        public IActionResult GetSquareNumber(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var SquareNumber = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(SquareNumber);
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string Number)
        {
            decimal decimalNumber;
            if(decimal.TryParse(Number, out decimalNumber))
            {
                return decimalNumber;
            }

            return 0;
        }

        //private double ConvertToDouble(string Number)
        //{
        //    double doubleNumber;
        //    if (double.TryParse(Number, out doubleNumber))
        //    {
        //        return doubleNumber;
        //    }

        //    return 0;
        //}

        private bool IsNumeric(string Number)
        {
            double number;
            bool IsNumber = double.TryParse(Number, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);

            return IsNumber;
        }
    }
}
