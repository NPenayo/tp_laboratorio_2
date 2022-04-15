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

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Operando numero1 = new Operando(txtNumero1.Text);
            Operando numero2 = new Operando(txtNumero2.Text);
            char operador = Convert.ToChar(cmbOperador.SelectedItem);
            lblResultado.Text = Calculadora.Operar(numero1, numero2, operador).ToString();
            StringBuilder operaciones = new StringBuilder();
            lstOperaciones.Items.Insert(0, operaciones.AppendLine($"{txtNumero1.Text} {operador} {txtNumero2.Text} = {lblResultado.Text}"));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();
            lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);
        }
        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.SelectedIndex = 0;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Salir de la calculadora",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
