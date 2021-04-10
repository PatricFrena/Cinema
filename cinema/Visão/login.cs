using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cinema
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            
            Menu newMenu = new Menu();
            this.Hide();
            newMenu.Show();
            

        }
    }
}
