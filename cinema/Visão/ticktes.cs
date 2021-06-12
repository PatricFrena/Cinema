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
    public partial class tickets : Form
    {
        SalaControlador _salaControlador;
        FilmeControlador _filmeControlador;
        ticketsControlador _ticketControlador;
        public List<Button> botoesPoltrona = new List<Button>();
        private bool novaSessao = true;
        private bool verificaSessao = false;


        public tickets()
        {
            InitializeComponent();
            Iniciabotoes();
            _salaControlador = new SalaControlador();
            _filmeControlador = new FilmeControlador();
            _ticketControlador = new ticketsControlador();
            montarComboFilmes();
            montarComboSala();
        }

        private void ListaBoteos()
        {
            botoesPoltrona.Clear();
            botoesPoltrona.Add(A1);
            botoesPoltrona.Add(A2);
            botoesPoltrona.Add(A3);
            botoesPoltrona.Add(B1);
            botoesPoltrona.Add(B2);
            botoesPoltrona.Add(B3);
            botoesPoltrona.Add(C1);
            botoesPoltrona.Add(C2);
            botoesPoltrona.Add(C3);
            botoesPoltrona.Add(D1);
            botoesPoltrona.Add(D2);
            botoesPoltrona.Add(D3);
        }


        private void Iniciabotoes() 
        {
            A1.BackColor = Color.Green;
            A2.BackColor = Color.Green;
            A3.BackColor = Color.Green;
            B1.BackColor = Color.Green;
            B2.BackColor = Color.Green;
            B3.BackColor = Color.Green;
            C1.BackColor = Color.Green;
            C2.BackColor = Color.Green;
            C3.BackColor = Color.Green;
            D1.BackColor = Color.Green;
            D2.BackColor = Color.Green;
            D3.BackColor = Color.Green;
        }

        private void montarComboFilmes()
        {
            var filmes = _filmeControlador.BuscaFilmes();

            cbfilmes.Items.Clear();

            Dictionary<int, string> itenscombobox = new Dictionary<int, string>();
            foreach (var filme in filmes)
            { 
                if(filme.id > 0)
                 itenscombobox.Add(filme.id, filme.nome);
            }

            cbfilmes.DataSource = new BindingSource(itenscombobox, null);
            cbfilmes.DisplayMember = "Value";
            cbfilmes.ValueMember = "Key";

            if (cbfilmes.Items.Count <= 0)
                MessageBox.Show("Nenhum filme cadastrado. Favor, verificar!!");
        }

        private void montarComboSala() 
        {
            var salas = _salaControlador.buscaSalas();

            cbsalas.Items.Clear();

            Dictionary<int, string> itenscombobox = new Dictionary<int, string>();
            foreach (var sala in salas)
            {
                if (sala.id > 0)
                itenscombobox.Add(sala.id, sala.nome);
            }

            cbsalas.DataSource = new BindingSource(itenscombobox, null);
            cbsalas.DisplayMember = "Value";
            cbsalas.ValueMember = "key";

            if (cbsalas.Items.Count <= 0)
                MessageBox.Show("Nenhuma sala cadastrada. Favor, verificar!!");

        }

        private void A1_Click(object sender, EventArgs e)
        {
            if (A1.BackColor == Color.Green)
            {
                A1.BackColor = Color.Red;
            }
            else
                A1.BackColor = Color.Green;
        }

        private void A2_Click(object sender, EventArgs e)
        {
            if (A2.BackColor == Color.Green)
            {
                A2.BackColor = Color.Red;
            }
            else
                A2.BackColor = Color.Green;
        }

        private void A3_Click(object sender, EventArgs e)
        {
            if (A3.BackColor == Color.Green)
            {
                A3.BackColor = Color.Red;
            }
            else
                A3.BackColor = Color.Green;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            if (B1.BackColor == Color.Green)
            {
                B1.BackColor = Color.Red;
            }
            else
                B1.BackColor = Color.Green;
        }

        private void B2_Click(object sender, EventArgs e)
        {
            if (B2.BackColor == Color.Green)
            {
                B2.BackColor = Color.Red;
            }
            else
                B2.BackColor = Color.Green;
        }

        private void B3_Click(object sender, EventArgs e)
        {
            if (B3.BackColor == Color.Green)
            {
                B3.BackColor = Color.Red;
            }
            else
                B3.BackColor = Color.Green;
        }

        private void C1_Click(object sender, EventArgs e)
        {
            if (C1.BackColor == Color.Green)
            {
                C1.BackColor = Color.Red;
            }
            else
                C1.BackColor = Color.Green;
        }

        private void C2_Click(object sender, EventArgs e)
        {
            if (C2.BackColor == Color.Green)
            {
                C2.BackColor = Color.Red;
            }
            else
                C2.BackColor = Color.Green;
        }

        private void C3_Click(object sender, EventArgs e)
        {
            if (C3.BackColor == Color.Green)
            {
                C3.BackColor = Color.Red;
            }
            else
                C3.BackColor = Color.Green;
        }

        private void D1_Click(object sender, EventArgs e)
        {
            if (D1.BackColor == Color.Green)
            {
                D1.BackColor = Color.Red;
            }
            else
                D1.BackColor = Color.Green;
        }

        private void D2_Click(object sender, EventArgs e)
        {
            if (D2.BackColor == Color.Green)
            {
                D2.BackColor = Color.Red;
            }
            else
                D2.BackColor = Color.Green;
        }

        private void D3_Click(object sender, EventArgs e)
        {
            if (D3.BackColor == Color.Green)
            {
                D3.BackColor = Color.Red;
            }
            else
                D3.BackColor = Color.Green;
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tickets_Load(object sender, EventArgs e)
        {

        }

        private void cbfilmes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ListaBoteos();

            var retornoCadastro = _ticketControlador.CadastrarTicket(Convert.ToInt32(cbsalas.SelectedValue),
                Convert.ToInt32(cbfilmes.SelectedValue),cbsessaofinalizada.Checked ? 1 : 0,
                botoesPoltrona);
            if (retornoCadastro.sucesso)
            {
                MessageBox.Show(retornoCadastro.Descricao);
            }
            else 
            {
                MessageBox.Show("Ocorreu um erro!!");
            }

        }

        private void btnverificarsessao_Click(object sender, EventArgs e)
        {
            try 
            {
                var retornoSessaoAtiva = _ticketControlador.buscaSessaoAtiva
                    (Convert.ToInt32(cbsalas.SelectedValue),Convert.ToInt32(cbfilmes.SelectedValue));

                if (!retornoSessaoAtiva.sucesso)
                {
                    MessageBox.Show("Será iniciada uma nova sessão!");
                    novaSessao = true;
                    verificaSessao = true;
                }
                else 
                {
                    novaSessao = false;
                    ListaBoteos();
                    var poltronas = _ticketControlador.buscaPoltronaSessao
                        (Convert.ToInt32(cbsalas.SelectedValue), Convert.ToInt32(cbfilmes.SelectedValue));

                    foreach (var poltrona in poltronas)
                    {
                        var btnpoltrona = poltrona.poltrona;
                        var disponivel = poltrona.disponivel;
                        foreach (var botoes in botoesPoltrona)
                        {
                            if (botoes.Name == btnpoltrona)
                                botoes.BackColor = disponivel == 1 ? Color.Green : Color.Red;
                        }
                    }
                }
            }
            catch 
            {
            
            }
        }
    }
}
