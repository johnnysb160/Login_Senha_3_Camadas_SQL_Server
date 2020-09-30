using Login_Senha_3_Camadas_SQL_Server.Apresentacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Senha_3_Camadas_SQL_Server.DAL
{
    class LoginComandos
    {
        public bool VerificaAcesso = false;
        public string mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao conec = new Conexao();
        SqlDataReader dr;
        public bool VerificarLogin(string login, string senha)
        {
            cmd.CommandText = "SELECT * FROM logins WHERE login=@login AND senha=@senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = conec.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    VerificaAcesso = true;
                }
                dr.Close();
                conec.Desconectar();
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
            return VerificaAcesso;
        }

     public string Cadastrar(string login, string senha, string confSenha)
    {
        VerificaAcesso = false;
        if (senha.Equals(confSenha))
        {
            cmd.CommandText = "INSERT INTO logins (login, senha) VALUES (@login, @senha)";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = conec.Conectar();
                cmd.ExecuteNonQuery();
                this.mensagem = "Cadastrado com sucesso";
                conec.Desconectar();
                VerificaAcesso = true;
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
        }
        else
        {
            this.mensagem = "Senhas diferentes";
        }

        return mensagem;
    }

    public string Editar(string login, string senha, string confSenha)
    {
        VerificaAcesso = false;
        if (senha.Equals(confSenha))
        {
            cmd.CommandText = "UPDATE logins SET senha=@senha WHERE login=@login";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = conec.Conectar();
                cmd.ExecuteNonQuery();
                this.mensagem = "Senha alterada com sucesso";
                conec.Desconectar();
                VerificaAcesso = true;
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
        }
        else
        {
            this.mensagem = "Senhas diferentes";
        }

        return mensagem;
    }
}
}
