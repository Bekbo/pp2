using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCalc
{
    public class Calculator
    {
        public double num1;
        public double num2;
        public string oper;
        public double res=0;

        public void Calculate()
        {
            switch (oper)
            {

                case "+":
                    res = num1 + num2;
                    break;
                case "-":
                    res = num1 - num2;
                    break;
                case "*":
                    res = num1 * num2;
                    break;
                case "/":
                    res = num1 / num2;
                    break;
                case "sin":
                    res = Math.Sin(num1 * Math.PI / 180);
                    break;
                case "cos":
                    res = Math.Cos(num1 * Math.PI / 180);
                    break;
                case "х²":
                    res = num1*num1;
                    break;
                case "√":
                    res = Math.Sqrt(num1);
                    break;
            }
            num1 = num2;
        }
    }
}
