using Microsoft.AspNetCore.Mvc;

namespace WebMVCEjemplos.Controllers
{
    public class CalculatorController : Controller
    {
        //GET: /calculator/MultByTwo/25

        public IActionResult MultByTwo(int num)
        {
            int result = num * 2;
            return Content(result.ToString());
        }

        [Route("Calc/Mult/{num1:int}/{num2:int}")]

        //GET: /Calculator/Mult/100/200

        public IActionResult Mult(int num1, int num2)
        {
            int result = num1 * num2;
            return Content(result.ToString());
        }


        [HttpGet("Divide/{param?}")]

        //GET: calculator/DivideByTen/33

        public IActionResult DivideByTen(int param)
        {
            int result = param / 10;
            return Content(result.ToString());
        }
    }
}


