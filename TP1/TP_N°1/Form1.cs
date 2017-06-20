using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_N_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            textNumero1.Text = "";
            textNumero2.Text = "";
            lblResult.Text = "";
        }

        private void botonOperar_Click(object sender, EventArgs e)
        {
            string num1Aux, num2Aux, operadorAux;
            num1Aux = textNumero1.Text;
            num2Aux = textNumero2.Text;
            operadorAux = cmbOperacion.Text;
            Clases.Numero numero1 = new Clases.Numero(num1Aux);
            Clases.Numero numero2 = new Clases.Numero(num2Aux);

            if (numero1.GetNumero() == 0) textNumero1.Text = "0"; // Muestra 0 si se pasa texto en los operandos
            if (numero2.GetNumero() == 0) textNumero2.Text = "0";

            lblResult.Text = Clases.Calculadora.Operar(numero1, numero2, operadorAux).ToString();
            
        }
    }
}
