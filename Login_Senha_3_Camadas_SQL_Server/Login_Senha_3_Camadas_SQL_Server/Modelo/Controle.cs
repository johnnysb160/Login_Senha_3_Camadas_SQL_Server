using Login_Senha_3_Camadas_SQL_Server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Senha_3_Camadas_SQL_Server.Modelo
{
    public class Controle
    {
        public bool VerificarAcesso;
        public string mensagem="";
        LoginComandos loginDaoComandos = new LoginComandos();
        public bool Acesso(string login, string senha)
        {
            
            VerificarAcesso = loginDaoComandos.VerificarLogin(login, senha);
            try
            {
                if (!loginDaoComandos.mensagem.Equals(""))
                {
                    this.mensagem = loginDaoComandos.mensagem;
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
            return VerificarAcesso;
        }

        public string Cadastro(string login, string senha, string confSenha)
        {
            this.mensagem = loginDaoComandos.Cadastrar(login, senha, confSenha);
            try
            {
                if (loginDaoComandos.VerificaAcesso)
                {
                    this.VerificarAcesso = true;
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
            return mensagem;
        }


        public string Editar(string login, string senha, string confSenha)
        {
            this.mensagem = loginDaoComandos.Editar(login, senha, confSenha);
            try
            {
                if (loginDaoComandos.VerificaAcesso)
                {
                    this.VerificarAcesso = true;
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
            return mensagem;
        }

        public string Deletar(string login)
        {
            this.mensagem = loginDaoComandos.Deletar(login);
            try
            {
                if (loginDaoComandos.VerificaAcesso)
                {
                    this.VerificarAcesso = true;
                }
            }
            catch (Exception e)
            {
                this.mensagem = "Error" + e.Message;
            }
            return mensagem;
        }
    }
}
