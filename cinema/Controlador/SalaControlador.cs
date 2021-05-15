using cinema.Modelo;
using cinema.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controlador
{
    public class SalaControlador
    {
        SalaRepositorio _SalaRepositorio;

        public SalaControlador()
        {
            _SalaRepositorio = new SalaRepositorio();
        }

        public RetornoFuncao cadastro(string nome, string apelido, string localizacao) 
        {
            var retorno = _SalaRepositorio.cadastro(nome, apelido, localizacao);
            return retorno;
        }
    }
}
