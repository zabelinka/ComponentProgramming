using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentLibrary;

namespace ComponentIntegration
{
    public partial class MainForm : Form
    {
        string function;
        float lowerLimit;
        float upperLimit;
        float eps;
        float[] coefs;          // the coefficients given by parser from function
        IQuadratureMethod[] method;     // the method of integration
        Container cont;                 // the container for components
        float result;
        bool inputError;                // true when input data are incorrect and need to display error message

        public MainForm()
        {
            InitializeComponent();

            function = "";
            method = null;
            cont = null;
            inputError = false;
        }

        private void errorMessage(string message)
        {
            answerTB.Clear();
            answerTB.Text = "ОШИБКА!" + Environment.NewLine + message;
        }

        // read entered data
        private void functionTB_TextChanged(object sender, EventArgs e)
        {
            function = functionTB.Text;
        }
        private void lowerLimitTB_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(lowerLimitTB.Text, out lowerLimit))
            {
                errorMessage("Некорректный нижний предел интегрирования!");
            }
        }
        private void upperLimitTB_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(upperLimitTB.Text, out upperLimit))
            {
                errorMessage("Некорректный верхний предел интегрирования!");
            }
        }
        private void epsTB_TextChanged(object sender, EventArgs e)
        {
            if (!float.TryParse(epsTB.Text, out eps))
            {
                errorMessage("Некорректное значение точности!");
            }
        }


        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // get which radio button is checked
            var checkedRB = radioButtonsGroup.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            switch (checkedRB.Name)
            {
                case "rectangleRB":
                    method = new IQuadratureMethod[1];
                    method[0] = new RectangleMethod();
                    break;
                case "trapezeRB":
                    method = new IQuadratureMethod[1];
                    method[0] = new TrapezeMethod();
                    break;
                case "simpsonRB":
                    method = new IQuadratureMethod[1];
                    method[0] = new SimpsonMethod();
                    break;
                case "allVariantsRB":
                    method = new IQuadratureMethod[3];
                    cont = new Container();
                    method[0] = new RectangleMethod();
                    method[1] = new TrapezeMethod();
                    method[2] = new SimpsonMethod();

                    for (int i = 0; i < method.Length; ++i){
                        cont.Add(method[i]);
                    }
                    break;
            }

            
            
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Parser p = new Parser();
            coefs = p.parse(function);
            p.Dispose();

            // wrong function
            if (coefs.Length != 3)
            {
                errorMessage("Неверный формат функции!");
                return;
            }
            // method not chosen
            if (method == null)
            {
                errorMessage("Выберите метод интегрирования!");
                return;
            }
           
            // calculate and write answer
            answerTB.Clear();
            answerTB.Text = "Коэффициенты: " + Environment.NewLine;
            for (int i = 0; i < coefs.Length; ++i)
            {
                answerTB.Text += coefs[i] + " ";
            }

            answerTB.Text += Environment.NewLine + "Требуемая точность: " + eps + Environment.NewLine;
            answerTB.Text += "Пределы интегрирования: " + lowerLimit + " " + upperLimit + Environment.NewLine;


            for (int i = 0; i < method.Length; i++)
            {
                result = method[i].calculate(lowerLimit, upperLimit, coefs, eps);
                answerTB.Text += method[i].name + result.ToString() + Environment.NewLine;
            }

            // высвобождение ресурсов компонентов
            if (cont != null)
            {
                cont.Dispose();
            }
            else
            {
                method[0].Dispose();
            }
               
        }
     
        
    }

}


