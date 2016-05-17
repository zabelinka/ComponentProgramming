using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLibrary
{
    public class FunctionValueComponent : Component
    {
        private double a;
        private double b;
        private double c;

        public FunctionValueComponent()
        {
            a = 0;
            b = 0;
            c = 0;
        }
        public FunctionValueComponent(double[] coefs)
        {
            a = coefs[0];
            b = coefs[1];
            c = coefs[2];
        }
        // calculate the value of the function of type ax*ln(bx+c) with argument x
        public double calculate(double x)
        {
            if (b * x + c <= 0)
            {
                return Double.NaN;
            }
            double result;
            result = a * x * Math.Log(b * x + c);
            return result;
        }
    }

}
