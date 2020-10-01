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
            this.Close();
            Application.Restart();
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
            btnDeletar.Visible = true;
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
            btnDeletar.Visible = false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja deletar?", "Deleção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                BemVindo bemvindo = new BemVindo();
                Controle controle = new Controle();
                string mensagem = controle.Deletar(txtLogin.Text);
                if (controle.VerificarAcesso)
                {
                    MessageBox.Show(mensagem, "Deleção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bemvindo.Close();
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show(controle.mensagem);
                }
            }
        }
    }
}
