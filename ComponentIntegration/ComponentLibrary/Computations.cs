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
            double result;
            result = a * x * Math.Log(b * x + c);
            return result;
        }
    }

    public class DerivativeComponent : Component
    {
        private double a;
        private double b;
        private double c;
        public DerivativeComponent(double[] coefs)
        {
            a = coefs[0];
            b = coefs[1];
            c = coefs[2];
        }

        public double calculate(double x, int order){
            if (order == 1)
            {
                return a * (b * x / (b * x + c) + Math.Log(b * x + c));
            }
            if (order > 4)
            {
                return Double.NaN;
            }
            else
            {
                double result = Math.Pow(-1, order - 1);
                result *= Math.Floor(order / 2.0);
                result *= a * Math.Pow(b, order - 1) * (b * x + order * c);
                result /= Math.Pow(b * x + c, order);
                return result;
            }
        }
        
    }

}
