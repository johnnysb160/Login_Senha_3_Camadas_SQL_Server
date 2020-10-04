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
            try
            {
                cmd.Connection = conec.Conectar();
                cmd = new SqlCommand("Proc_CRUD", conec.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Acao", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
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
            try
            {
                if (senha.Equals(confSenha))
                {
                    cmd.Connection = conec.Conectar();
                    cmd = new SqlCommand("Proc_CRUD", conec.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Acao", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                    cmd.ExecuteNonQuery();
                    this.mensagem = "Cadastrado com sucesso";
                    conec.Desconectar();
                    VerificaAcesso = true;
                }
                else
                {
                    this.mensagem = "Senhas diferentes";
                }
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }

            return mensagem;
        }

        public string VerificaCadastro(string login)
        {
            VerificaAcesso = false;
            try
            {
                cmd.Connection = conec.Conectar();
                cmd = new SqlCommand("Proc_CRUD", conec.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Acao", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    VerificaAcesso = true;
                    this.mensagem = "Login já cadastrado";
                }
                dr.Close();
                conec.Desconectar();
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dadoooooos";
            }
            return mensagem;
        }

        public string Editar(string login, string senha, string confSenha)
        {
            VerificaAcesso = false;
            try
            {
                if (senha.Equals(confSenha))
                {
                    cmd.Connection = conec.Conectar();
                    cmd = new SqlCommand("Proc_CRUD", conec.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Acao", SqlDbType.Int).Value = 2;
                    cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                    cmd.ExecuteNonQuery();
                    this.mensagem = "Senha alterada com sucesso";
                    conec.Desconectar();
                    VerificaAcesso = true;
                }
                else
                {
                    this.mensagem = "Senhas diferentes";
                }
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
            return mensagem;
        }

        public string Deletar(string login)
        {
            try
            {
                cmd.Connection = conec.Conectar();
                cmd = new SqlCommand("Proc_CRUD", conec.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Acao", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                cmd.ExecuteNonQuery();
                this.mensagem = "Usuário deletado com sucesso";
                conec.Desconectar();
                VerificaAcesso = true;
            }
            catch (SqlException)
            {

                this.mensagem = "Erro com o Banco de Dados";
            }
            return mensagem;
        }
    }
}
