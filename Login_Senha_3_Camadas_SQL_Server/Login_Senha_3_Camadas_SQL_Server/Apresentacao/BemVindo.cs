using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Senha_3_Camadas_SQL_Server.Apresentacao
{
    public partial class BemVindo : Form
    {
        public BemVindo()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lblLogin.Visible = true;
            txtLogin.Visible = true;

            lblSenha.Visible = true;
            txtSenha.Visible = true;

            lblConfirmar.Visible = true;
            txtConfirmar.Visible = true;

            btnSalvar.Visible = true;
            btnEditar.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
