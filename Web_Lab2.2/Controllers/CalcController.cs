using System;
using Microsoft.AspNetCore.Mvc;
using Web_Lab2._2.Models;
using Web_Lab2._2.Service;

namespace lab2.Controllers
{
    public class CalcController : Controller
    {
        [Route("Manual")]
        public IActionResult Manual()
        {
            if (HttpContext.Request.Method == "GET")
                return View("WindowInput");

            int a, b;
            string operation;
            if (!int.TryParse(HttpContext.Request.Form["a"], out a))
                return BadRequest();
            if (!int.TryParse(HttpContext.Request.Form["b"], out b))
                return BadRequest();
            operation = HttpContext.Request.Form["operation"];
            if (String.IsNullOrEmpty(operation))
                return BadRequest();

            ViewBag.Result = CalcService.Convert(new Calc { a = a, b = b, operation = operation });
            
            return View("Result");
        }

        [HttpGet]
        [Route("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparate()
        {
            return View("WindowInput");
        }
        [HttpPost]
        [Route("ManualParsingSeparate")]
        public IActionResult ManualParsingSeparateResult()
        {
            int a, b;
            string operation;
            if (!int.TryParse(HttpContext.Request.Form["a"], out a))
                return BadRequest();
            if (!int.TryParse(HttpContext.Request.Form["b"], out b))
                return BadRequest();
            operation = HttpContext.Request.Form["operation"];
            if (String.IsNullOrEmpty(operation))
                return BadRequest();

            ViewBag.Result = CalcService.Convert(new Calc {a = a, b = b, operation = operation});

            return View("Result");
        }

        [Route("ModelBindingParameters")]
        [HttpGet]
        public IActionResult ModelBindingParameters()
        {
            return View("WindowInput");
        }

        [Route("ModelBindingParameters")]
        [HttpPost]
        public IActionResult ModelBindingParametersResult(int a, string operation, int b)
        {
            if (!ModelState.IsValid)
                BadRequest();
            ViewBag.Result = CalcService.Convert(new Calc{ a = a, b = b, operation = operation });

            return View("Result");
        }

        [Route("ModelBindingSeparate")]
        [HttpGet]
        public IActionResult ModelBindingSeparate()
        {
            return View("WindowInput");
        }

        [Route("ModelBindingSeparate")]
        [HttpPost]
        public IActionResult ModelBindingSeparateResult(Calc calc)
        {
            ViewBag.Result = CalcService.Convert(calc);

            return View("Result");
        }
    }
}
