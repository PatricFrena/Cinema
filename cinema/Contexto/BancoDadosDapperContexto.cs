using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Contexto
{
   public class BancoDadosDapperContexto
    {
        public BancoDadosDapperContexto() { }

        MySqlConnection conexao = new MySqlConnection()
        { 
            ConnectionString = ConfigurationManager.ConnectionStrings["CinemaSucesso"].ConnectionString
        };
        public MySqlConnection conexaobanco() 
            {
                try
                {
                if (conexao.State == System.Data.ConnectionState.Closed)
                    conexao.Open();

                    return conexao;
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);

                }
        }
        public void Deconecabanco()
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                    conexao.Close();

            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);

            }
        }
    }
}

    