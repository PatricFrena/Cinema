using cinema.Modelo;
using cinema.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controlador
{
    public class LoginControlador
    {
        usuarioRepositorio _Usuariorepositorio;
        public LoginControlador() 
        {
            _Usuariorepositorio = new usuarioRepositorio();
        }

            public RetornoFuncao realizaLogin(int codigo, string senha) 
            {
            var retorno = _Usuariorepositorio.realizaLogin(codigo, senha);    
            return retorno;
            
            } 
    }
}
