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
        public bool acesso(string login, string senha)
        {
            VerificarAcesso = loginDaoComandos.VerificarLogin(login, senha);
            if (!loginDaoComandos.mensagem.Equals(""))
            {
                this.mensagem = loginDaoComandos.mensagem;
            }
            return VerificarAcesso;
        }

        public string Cadastro(string login, string senha, string confSenha)
        {
            this.mensagem = loginDaoComandos.Cadastrar(login, senha, confSenha);
            if (loginDaoComandos.VerificaAcesso)
            {
                this.VerificarAcesso = true;
            }
            return mensagem;
        }
    }
}
