using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Lab2._2.Models;

namespace Web_Lab2._2.Service
{
    public class CalcService
    {
        public static string Convert(Calc calc)
        {
            return calc.operation switch
            {
                "+" => $"{calc.a} + {calc.b} = {calc.a + calc.b}",
                "-" => $"{calc.a} - {calc.b} = {calc.a - calc.b}",
                "*" => $"{calc.a} * {calc.b} = {calc.a * calc.b}",
                "/" when calc.b != 0 => $"{calc.a} / {calc.b} = {calc.a / calc.b}",
                "/" when calc.b == 0 => "Ошибка: деление на нуль",
                _ => "Неизвестная операция"
            };
        }
    }
}
