using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Senha_3_Camadas_SQL_Server.DAL
{
    class Conexao
    {
        public SqlConnection con = new SqlConnection();
        public string mensagem = "";
        public Conexao()
        {
            con.ConnectionString = @"Data Source=12V-5\SQLEXPRESS;Initial Catalog=ProjetoLogin;Integrated Security=True";
        }
        public SqlConnection Conectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
            return con;
        }

        public void Desconectar()
        {
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
        }

    }
}
