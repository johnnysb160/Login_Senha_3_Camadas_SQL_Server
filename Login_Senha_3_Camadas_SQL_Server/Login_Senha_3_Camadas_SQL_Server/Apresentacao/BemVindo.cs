using Login_Senha_3_Camadas_SQL_Server.Modelo;
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
            txtLogin.Enabled = false;

            lblSenha.Visible = true;
            txtSenha.Visible = true;

            lblConfirmar.Visible = true;
            txtConfirmar.Visible = true;

            btnSalvar.Visible = true;
            btnSalvar.Enabled = true;
            btnVoltar.Visible = true;
            btnEditar.Enabled = false;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            string mensagem = controle.Editar(txtLogin.Text, txtSenha.Text, txtConfirmar.Text);
            if (controle.VerificarAcesso)
            {
                MessageBox.Show(mensagem, "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }

            btnSalvar.Enabled = false;

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            lblLogin.Visible = false;
            txtLogin.Visible = false;

            lblSenha.Visible = false;
            txtSenha.Visible = false;

            lblConfirmar.Visible = false;
            txtConfirmar.Visible = false;

            btnSalvar.Visible = false;
            btnEditar.Enabled = true;
            btnVoltar.Visible = false;

        }
    }
}
