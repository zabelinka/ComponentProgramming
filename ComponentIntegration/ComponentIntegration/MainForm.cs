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
        double lowerLimit;
        double upperLimit;
        double eps;
        double[] coefs;          // the coefficients given by parser from function
        IQuadratureMethod[] method;     // the method of integration
        Container cont;                 // the container for components
        double result;
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
            answerTB.Text += "ОШИБКА!" + message + Environment.NewLine;
        }

        // read entered data
        private void functionTB_TextChanged(object sender, EventArgs e)
        {
            function = functionTB.Text;
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

        private bool checkInputData()
        {
            bool result = true;
            // ln(0), ln(negative)
            if (!double.TryParse(lowerLimitTB.Text, out lowerLimit))
            {
                errorMessage("Некорректный нижний предел интегрирования!");
                result = false;
            }
            if (!double.TryParse(upperLimitTB.Text, out upperLimit))
            {
                errorMessage("Некорректный верхний предел интегрирования!");
                result = false;
            }
            if (!double.TryParse(epsTB.Text, out eps))
            {
                errorMessage("Некорректное значение требуемой точности!");
                result = false;
            }
            if (coefs[1] * upperLimit + coefs[2] <= 0 || coefs[1] * lowerLimit + coefs[2] <= 0)
            {
                errorMessage("Невозможно вычислить логарифм при данных коэффициентах и пределах интегрирования!");
                result = false;
            }

            return result;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            answerTB.Clear();

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
            // wrong parameters
            if (!checkInputData())
            {
                return;
            }
           
            // calculate and write answer
            for (int i = 0; i < method.Length; i++)
            {
                result = method[i].calculate(lowerLimit, upperLimit, coefs, eps);
                answerTB.Text += method[i].name + Environment.NewLine + result.ToString() + Environment.NewLine;
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


