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
    public partial class login : Form
    {
        LoginControlador _Logincontrolador;
        public login()
        {
            InitializeComponent();
            _Logincontrolador = new LoginControlador();
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            try 
            {
                var retorno = _Logincontrolador.realizaLogin(Convert.ToInt32(txtusuario.Text), txtsenha.Text);
                if (retorno.sucesso) {
                    Menu newform2 = new Menu();
                    this.Hide();
                    newform2.ShowDialog();
                }
                else
                    MessageBox.Show(retorno.Descricao);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
            
            
            
            

        }
    }
}
