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
        double a;
        double b;
        double[] coefs;
        double eps;

        private int stepCount()
        {
            const int N = 100;
            double h = (b - a) / N;
            double[] xx = new double[N];
            double[] yy = new double[N];        // the array of derivative values

            DerivativeComponent derivative = new DerivativeComponent(coefs);
            for (int i = 0; i < N; i++)
            {
                xx[i] = a + h * i;
                yy[i] = Math.Abs(derivative.calculate(xx[i], 1));
            }
            derivative.Dispose();

            double MaxDerivative = yy.Max();

            double result = Math.Pow(b - a, 2) / (2 * eps) * MaxDerivative;
            if (Double.IsNaN(result) || result < 1)
            {
                return 1;
            }
            return (int)Math.Floor(result);
        }

        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            this.a = lowerLimit;
            this.b = upperLimit;
            this.coefs = coefs;
            this.eps = eps;


            int N = stepCount();      
            double h = (b - a) / N;     // step
            double result = 0;

            FunctionValueComponent funValComp = new FunctionValueComponent(coefs);

            // left corner approximation
            for (int i = 0; i < N; i++)
            {
                double x = a + h * i;
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
        double a;
        double b;
        double[] coefs;
        double eps;

        private int stepCount()
        {
            const int N = 100;
            double h = (b - a) / N;
            double[] xx = new double[N];
            double[] yy = new double[N];        // the array of derivative values

            DerivativeComponent derivative = new DerivativeComponent(coefs);
            for (int i = 0; i < N; i++)
            {
                xx[i] = a + h * i;
                yy[i] = Math.Abs(derivative.calculate(xx[i], 2));
            }
            derivative.Dispose();

            double MaxDerivative = yy.Max();

            double result = Math.Sqrt(Math.Pow(b - a, 3) / (12 * eps) * MaxDerivative);
            if (Double.IsNaN(result) || result < 1)
            {
                return 1;
            }
            return (int)Math.Floor(result);
        }

        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            this.a = lowerLimit;
            this.b = upperLimit;
            this.coefs = coefs;
            this.eps = eps;


            int N = stepCount();
            double h = (b - a) / N;     // step
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
        double a;
        double b;
        double[] coefs;
        double eps;

        private int stepCount()
        {
            const int N = 100;
            double h = (b - a) / N;
            double[] xx = new double[N];
            double[] yy = new double[N];        // the array of derivative values

            DerivativeComponent derivative = new DerivativeComponent(coefs);
            for (int i = 0; i < N; i++)
            {
                xx[i] = a + h * i;
                yy[i] = Math.Abs(derivative.calculate(xx[i], 4));
            }
            derivative.Dispose();

            double MaxDerivative = yy.Max();

            double result = Math.Pow(Math.Pow(b - a, 5) / (180 * eps) * MaxDerivative, 0.25);
            if (Double.IsNaN(result) || result < 1)
            {
                return 1;
            }
            return (int)Math.Floor(result);
        }

        public double calculate(double lowerLimit, double upperLimit, double[] coefs, double eps)
        {
            this.a = lowerLimit;
            this.b = upperLimit;
            this.coefs = coefs;
            this.eps = eps;

            
            int N = stepCount();
            double h = (b - a) / N;     // step
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
