using cinema.Contexto;
using cinema.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Repositório
{
    public class buscaUsuario
    {
        public buscaUsuario() { }

        //public string busca() {
        //    try
        //    { 
        //    var conexao = new BancoDadosDapperContexto();
        //    var bancoDados = conexao.conexaobanco();
        //        var usuario = bancoDados.Query < UsuarioModelo > @"SELECT * FROM usuarios WHERE codigo =  @codigo LIMIT 1", new { codigo = codigo }
        //    return bancoDados.Query<int>(serializa).FirstOrDefault() + 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}
    }
}
