using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton llama al metodo Limpiar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Limpia los 2 parametros, el operador y el resultado
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.SelectedIndex = -1;
        }

        /// <summary>
        /// Opera los parametros recibidos
        /// </summary>
        /// <param name="numero1">Primer parametro</param>
        /// <param name="numero2">Segundo parametro</param>
        /// <param name="operador">Operador</param>
        /// <returns>Retorna el resultado de la operacion</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            char.TryParse(operador, out char oper);

            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);

            resultado = Entidades.Calculadora.Operar(num1, num2, oper);

            return resultado;
        }

        /// <summary>
        /// Boton llama al metodo Operar()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtNumero1.Text, out double num1) && double.TryParse(txtNumero2.Text, out double num2))
            {

                if (cmbOperador.Text == "")
                {
                    cmbOperador.Text = "+";
                }

                txtNumero1.Text = txtNumero1.Text.Replace('.', ',');
                txtNumero2.Text = txtNumero2.Text.Replace('.', ',');
                

                if (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text) != double.MinValue)
                {
                    lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                    lstOperaciones.Items.Add($"{txtNumero1.Text} {cmbOperador.Text} {txtNumero2.Text} = {lblResultado.Text}");
                }
                else
                {
                    lblResultado.Text = "No se puede dividir por 0";
                    lstOperaciones.Items.Add("No se puede dividir por 0");
                }

            }
            else
            {
                lblResultado.Text = "Datos incorrectos. Ingrese solo numeros";
                lstOperaciones.Items.Add("Tipo de datos incorrectos.");
                lstOperaciones.Items.Add("Por favor ingrese solo numeros");
            }
        }

        /// <summary>
        /// Pregunta si quiere cerrar la calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Esta seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
                
        }

        /// <summary>
        /// Convierte un decimal en Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string mensajeError = "Valor invalido";

            int.TryParse(lblResultado.Text, out int resultado);

            if (resultado > 0 && double.TryParse(txtNumero1.Text, out double num1) && double.TryParse(txtNumero2.Text, out double num2))
            {
                Operando binario = new Operando();

                string strDecimal = lblResultado.Text;
                lblResultado.Text = binario.DecimalBinario(lblResultado.Text);

                lstOperaciones.Items.Add($"{strDecimal} to bin = {lblResultado.Text}");
            }
            else
            {
                lblResultado.Text = mensajeError;
                lstOperaciones.Items.Add($"{mensajeError}");
            }
        }

        /// <summary>
        /// Convierte un Binario en Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string mensajeError = "Valor invalido";

            if (double.TryParse(lblResultado.Text, out double resultado) && double.TryParse(txtNumero1.Text, out double num1) && double.TryParse(txtNumero2.Text, out double num2))
            {
                Operando valorDecimal = new Operando();

                string strDecimal = lblResultado.Text;
                lblResultado.Text = valorDecimal.BinarioDecimal(lblResultado.Text);
                lstOperaciones.Items.Add($"{strDecimal} to dec = {lblResultado.Text}");
            }
            else
            {
                lblResultado.Text = mensajeError;
                lstOperaciones.Items.Add($"{mensajeError}");
            }
        }
    }
}
