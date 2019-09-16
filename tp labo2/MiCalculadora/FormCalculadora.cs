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
        /// <summary>
        /// Constructor de la clase FormCalculadora, inicializa todos los componentes del forms.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton cerrar que pregunta al usuario si en verdad desea cerrar la aplicacion
        /// en caso de contestar 'yes', la cierra, caso contrario sigue ejecutandose
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult cerrar;
            cerrar = MessageBox.Show("¿Desea salir de la Calculadora?", "Salir?", MessageBoxButtons.YesNo);
            if (cerrar == DialogResult.Yes)
                this.Close();
        }

        /// <summary>
        /// metodo utilizado solo para limpiar los txtboxs, labels, y cmbos del programa
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }
        /// <summary>
        /// implementa el metodo privado "limpiar" y cuando el usuario hace click, limpia los campos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// implementa el metodo operar de la clase "Calculadora" y devuelve un numero flotante mediante un label de resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numeros numero1 = new Numeros(txtNumero1.Text);
            Numeros numero2 = new Numeros(txtNumero2.Text);
            string operador = cmbOperador.Text;

            double total;

            total = Calculadora.Operar(numero1, numero2, operador);
            lblResultado.Text = total + "";
        }

        /// <summary>
        /// convierte un nro decimal en binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirBinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numeros.DecimalBinario(lblResultado.Text);
        }

        /// <summary>
        /// convierte un numero binario en decimal 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConvertirDecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numeros.BinarioDecimal(lblResultado.Text);
        }

        /// <summary>
        /// Pobre intento de validacion al momento de salir de el txtbox Numero1, si no es un double o espacio vacio, muestra un mensaje de error (pero no hace nada)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNumero1_Leave(object sender, EventArgs e)
        {
            double result;
            if((!double.TryParse(this.txtNumero1.Text,  out result)) && this.txtNumero1.Text != "")
            {
                MessageBox.Show("Ese no es un numero valido","Error", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// Pobre intento de validacion al momento de salir de el txtbox Numero2, si no es un double o espacio vacio, muestra un mensaje de error (pero no hace nada)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtNumero2__Leave(object sender, EventArgs e)
        {
            double result;
            if ((!double.TryParse(this.txtNumero2.Text, out result)) && this.txtNumero2.Text != "")
            {
                MessageBox.Show("Ese no es un numero valido", "Error", MessageBoxButtons.OK);
            }
            
        }
    }
}

