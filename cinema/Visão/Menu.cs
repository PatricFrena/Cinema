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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ultilitriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroDeUsuario usuario = new CadastroDeUsuario();
            usuario.Show();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastroDeSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastroSala sala = new cadastroSala();
            sala.Show();
        }

        private void cadastroDeFilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroDeFilme filme = new CadastroDeFilme();
            filme.Show();
        }

        private void alterarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscaUsuario busca = new BuscaUsuario();
            busca.Show();

        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tickets tickets = new tickets();
            tickets.Show();
        }
    }
}
