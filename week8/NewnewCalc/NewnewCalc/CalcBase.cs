using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewnewCalc
{
    class CalcBase
    {
        public double num1;
        public double num2;
        public double res;
        public string oper;

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
                case "±":
                    res = num1 * (-1);
                    break;
                case "х²":
                    res = num1 * num1;
                    break;
                case "%":
                    res = num1 % num2;
                    break;
                case "√":
                    res = Math.Sqrt(num1);
                    break;
                case "1/x":
                    res = 1 / num1;
                    break;
                case "n!":
                    res = 1;
                    for (int i = 1; i <= num1; i++)
                        res *= i;
                    break;
            }
        }
    }
}
