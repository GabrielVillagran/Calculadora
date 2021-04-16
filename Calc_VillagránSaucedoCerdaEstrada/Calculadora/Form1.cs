using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        bool reslt;
        bool operando = false;
        string operador;
        double num1;        

        public Form1()
        {
            InitializeComponent();
        }

        private void numClick(object sender, EventArgs e)
        {
            Button numero = (Button)sender;
            if (pantalla.Text == "0")
                pantalla.Clear();
            if(reslt)
            {
                reslt = false;
                pantalla.Clear();
            }
            pantalla.Text = pantalla.Text + numero.Text;
            historial.Text = historial.Text + numero.Text;

        }

        private void opClick(object sender, EventArgs e)
        {
            Button op = (Button)sender;
            if (operando)
            {
                igual(num1, Double.Parse(pantalla.Text), operador);
                operador = op.Text;
            }
            else
            {
                operando = true;
                num1 = Double.Parse(pantalla.Text);
                pantalla.Clear();
                operador = op.Text;
                
            }
            historial.Text = historial.Text + op.Text;

        }

        private void raizClick(object sender, EventArgs e)
        {
            Button raiz = (Button)sender;
            if(operando)
            {
                int l = historial.Text.Length;
                igual(Double.Parse("0"+historial.Text[l-3]), Double.Parse("0"+historial.Text[l-1]),"" + historial.Text[l-2]);
            }
            this.num1 = Math.Sqrt(Double.Parse(pantalla.Text));
            pantalla.Text = this.num1.ToString();
            historial.Text = raiz.Text + "(" + historial.Text + ")";
            operando = false;
        }

        private void igual(double num1, double num2, string operador)
        {
            switch(operador)
            {
                case "+":
                    this.num1 = num1 + num2;
                    pantalla.Text = this.num1.ToString();
                    break;
                case "-":
                    this.num1 = num1 - num2;
                    pantalla.Text = this.num1.ToString();
                    break;
                case "X":
                    this.num1 = num1 * num2;
                    pantalla.Text = this.num1.ToString();
                    break;
                case "/":
                    if (num2 == 0)
                        pantalla.Text = "0";
                    else
                    {
                        this.num1 = num1 / num2;
                        pantalla.Text = this.num1.ToString();
                    }
                    break;
                case "^":
                    this.num1 = Math.Pow(num1, num2);
                    pantalla.Text = this.num1.ToString();
                    break;
            }
            reslt = true;
        }

        private void igualClick(object sender, EventArgs e)
        {
            if (operando)
            {
                igual(num1, Double.Parse(pantalla.Text), operador);
                operando = false;
                historial.Text = "";
            }
            
        }

        private void limpiarClick(object sender, EventArgs e)
        {
            pantalla.Text = "0";
            historial.Text = "";
        }
    }
}
