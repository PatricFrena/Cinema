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
    public partial class CadastroDeUsuario : Form
    {
        UsuarioControlador _UsuarioControlador;
        public CadastroDeUsuario()
        {
            InitializeComponent();
            _UsuarioControlador = new UsuarioControlador();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var retorno = _UsuarioControlador.cadastroUsuario(txtusuario.Text, txtsenha.Text, txtconfsenha.Text);
                if (retorno.sucesso)
                {
                    Menu newform2 = new Menu();
                    this.Hide();
                    newform2.ShowDialog();
                }
                else
                    MessageBox.Show(retorno.Descricao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
