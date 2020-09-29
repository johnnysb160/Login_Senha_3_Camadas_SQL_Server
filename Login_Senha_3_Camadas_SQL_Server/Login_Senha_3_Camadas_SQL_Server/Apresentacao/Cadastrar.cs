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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.Cadastro(txtLogin.Text, txtSenha.Text, txtConfirmar.Text);
            Cadastrar cadastrar = new Cadastrar();
            cadastrar.Close();
            MessageBox.Show(controle.mensagem);
        }
    }
}
