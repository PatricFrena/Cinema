using cinema.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema.Visão
{
    public partial class CadastroDeFilme : Form
    {
        FilmeControlador _filmeControlador;
        public CadastroDeFilme()
        {
            InitializeComponent();

            MontarComboBox();

            _filmeControlador = new FilmeControlador();
        }

        public void MontarComboBox()
        {
            cb.Items.Clear();
            cb.Items.Insert(0, "inativo");
            cb.Items.Insert(1, "ativo");
            if (cb.Items.Count >= 1)
            {
                cb.SelectedIndex = -1;
            }
            else
                cb.SelectedIndex = -1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CadastroDeFilme_Load(object sender, EventArgs e)
        {

        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = _filmeControlador.cadastroFilme(txtnome.Text, txtdescricao.Text, Convert.ToInt32(cb.SelectedIndex));
                if (retorno.sucesso)
                {
                    /*Menu newform2 = new Menu();
                    this.Hide();
                    newform2.ShowDialog();*/
                }
                else
                    MessageBox.Show(retorno.Descricao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
