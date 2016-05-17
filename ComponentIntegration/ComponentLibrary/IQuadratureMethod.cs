using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ComponentLibrary
{
    public interface IQuadratureMethod : IComponent
    {
        double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps);
        string name { get; }
    }



    public class RectangleMethod : Component, IQuadratureMethod
    {
        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            int N = 100;            // ОПРЕДЕЛИТЬ ЧИСЛО ШАГОВ ИЗ ПОГРЕШНОСТИ
            double h = (upperLimit - lowerLimit) / N;     // step
            double result = 0;

            FunctionValueComponent funValComp = new FunctionValueComponent(coefs);

            // left corner approximation
            for (int i = 0; i < N; i++)
            {
                double x = lowerLimit + h * i;
                result += funValComp.calculate(x); 
            }
            funValComp.Dispose();
            return result * h;
        }
        string IQuadratureMethod.name { 
            get { return "Метод прямоугольников: "; }
        }
    }

    public class TrapezeMethod : Component, IQuadratureMethod
    {
        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            int N = 100;            // ОПРЕДЕЛИТЬ ЧИСЛО ШАГОВ ИЗ ПОГРЕШНОСТИ
            double h = (upperLimit - lowerLimit) / N;     // step
            double result = 0;

            FunctionValueComponent funValComp = new FunctionValueComponent(coefs);

            // trapezoidal rule
            for (int i = 0; i < N; i++)
            {
                double x = lowerLimit + h * i;
                result += (funValComp.calculate(x) + funValComp.calculate(x + h)) / 2.0;
            }
            funValComp.Dispose();
            return result * h;
        }
        string IQuadratureMethod.name
        {
            get { return "Метод трапеций: "; }
        }
    }

    public class SimpsonMethod : Component, IQuadratureMethod
    {
        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            int N = 100;            // ОПРЕДЕЛИТЬ ЧИСЛО ШАГОВ ИЗ ПОГРЕШНОСТИ
            double h = (upperLimit - lowerLimit) / N;     // step
            double result = 0;

            FunctionValueComponent funValComp = new FunctionValueComponent(coefs);

            // Simpson's rule
            for (int i = 0; i < N; i++)
            {
                double x = lowerLimit + h * i;
                result += funValComp.calculate(x) + 4 * funValComp.calculate(x + h / 2.0) + funValComp.calculate(x + h);
            }
            funValComp.Dispose();
            return result * h / 6.0;
        }
        string IQuadratureMethod.name
        {
            get { return "Метод Симпсона: "; }
        }
    }
  
}
