using cinema.Modelo;
using cinema.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controlador
{
    public class FilmeControlador
    {
        FilmeRepositorio _FilmeRepositorio;

        public FilmeControlador()
        {
            _FilmeRepositorio = new FilmeRepositorio();
        }

        public RetornoFuncao cadastroFilme( string nome, string descricao, string situacao) 
        {
            var retorno = _FilmeRepositorio.cadastro(nome, descricao, situacao);
            return retorno;
        }
    }
}
