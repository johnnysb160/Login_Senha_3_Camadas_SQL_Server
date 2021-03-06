﻿using Login_Senha_3_Camadas_SQL_Server.Apresentacao;
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

namespace Login_Senha_3_Camadas_SQL_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Controle controle = new Controle();
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cadastrar cad = new Cadastrar();
                cad.ShowDialog();
            }
            catch (Exception)
            {

                MessageBox.Show(controle.mensagem);
            }

        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                controle.Acesso(txtLogin.Text, txtSenha.Text);
                if (controle.mensagem.Equals(""))
                {
                    if (controle.VerificarAcesso)
                    {
                        MessageBox.Show("Logado com Sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BemVindo bemvindo = new BemVindo();
                        this.Hide();
                        bemvindo.Show();
                        bemvindo.lblloginEditar.Text = txtLogin.Text.Substring(0, 1).ToUpper() + txtLogin.Text.Substring(1, txtLogin.Text.IndexOf("@") - 1);
                        bemvindo.txtLogin.Text = txtLogin.Text;
                        bemvindo.txtSenha.Text = txtSenha.Text;
                        bemvindo.txtConfirmar.Text = txtSenha.Text;
                    }
                    else
                    {
                        MessageBox.Show("Login ou senha incorreto", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show(controle.mensagem);
                }
            }
            catch (Exception)
            {

                MessageBox.Show(controle.mensagem); ;
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
