using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_ivolucion.Contracts;
using Microsoft.AspNetCore.Http;

namespace API_ivolucion.Controllers
{
    
    [ApiController]
    public class TestController : Controller
    {
        /// <summary>
        /// Gets the Current Colombia DateTime 
        /// </summary>
        /// <returns>UTC(-5) DateTime in format dd-MM-yyyy HH:mm:ss</returns>
        [HttpGet(ApiRoutes.Test.Get)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCurrentTime()
        {
            DateTime CurrentTime = DateTime.UtcNow.AddHours(-5);
            return Ok(CurrentTime.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        /// <summary>
        /// Generate a division between two numbers
        /// </summary>
        /// <param name="numbers">Numbers object contains two decimal number properties</param>
        /// <response code="200">Return result of operation</response>
        /// <response code="500">If operation produces a math exception</response>
        /// <response code="400">If client sends wrong object</response>
        /// <returns>result</returns>
        [HttpPost(ApiRoutes.Test.Post)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<decimal> NumberDivision([FromBody] Numbers numbers)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    decimal result = (numbers.Number1/numbers.Number2);
                    return Ok(result);
                }
                catch (DivideByZeroException)
                {
                    return StatusCode(500, "Math error, division by zero");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public class Numbers
        {
            public decimal Number1 { get; set; }
            public decimal Number2 { get; set; }
        }
    }
}
