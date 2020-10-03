using Login_Senha_3_Camadas_SQL_Server.DAL;
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
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        Controle controle = new Controle();
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLogin.Text != "" && txtSenha.Text != "" && txtConfirmar.Text != "" && txtLogin.Text.Contains("@"))
                {
                    LoginComandos loginComandos = new LoginComandos();
                    string mensagem = loginComandos.VerificaCadastro(txtLogin.Text);
                    if (loginComandos.VerificaAcesso == false)
                    {
                        string mensagem2 = controle.Cadastro(txtLogin.Text, txtSenha.Text, txtConfirmar.Text);
                        if (controle.VerificarAcesso)
                        {
                            this.Close();
                            MessageBox.Show(mensagem2, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(controle.mensagem);
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    if (txtLogin.Text == "")
                    {
                        MessageBox.Show("Campo Login vazio", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                        return;
                    }
                    if (!txtLogin.Text.Contains("@"))
                    {
                        MessageBox.Show("Preencha um Email", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtLogin.Focus();
                        return;
                    }
                    if (txtSenha.Text == "")
                    {
                        MessageBox.Show("Campo Senha vazio", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenha.Focus();
                        return;
                    }
                    if (txtConfirmar.Text == "")
                    {
                        MessageBox.Show("Campo Confirmar Senha vazio", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtConfirmar.Focus();
                        return;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
