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
    public partial class cadastroSala : Form
    {
        SalaControlador _SalaControlador;
        public cadastroSala()
        {
            InitializeComponent();
            _SalaControlador = new SalaControlador();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = _SalaControlador.cadastro(txtnome.Text, txtapelido.Text, txtlocalizacao.Text);
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
