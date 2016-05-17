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
        float calculate(float lowerLimit, float upperLimit, float[] coefs, float eps);
        string name { get; }  
    }

    public class RectangleMethod : Component, IQuadratureMethod
    {
        public float calculate(float lowerLimit, float upperLimit, float[] coefs, float eps)
        {
            return 1.0f;
        }
        string IQuadratureMethod.name { 
            get { return "Метод прямоугольников: "; }
        }
    }

    public class TrapezeMethod : Component, IQuadratureMethod
    {
        public float calculate(float lowerLimit, float upperLimit, float[] coefs, float eps)
        {
            return 2.0f;
        }
        string IQuadratureMethod.name
        {
            get { return "Метод трапеций: "; }
        }
    }

    public class SimpsonMethod : Component, IQuadratureMethod
    {
        public float calculate(float lowerLimit, float upperLimit, float[] coefs, float eps)
        {
            return 3.0f;
        }
        string IQuadratureMethod.name
        {
            get { return "Метод Симпсона: "; }
        }
    }
  
}
