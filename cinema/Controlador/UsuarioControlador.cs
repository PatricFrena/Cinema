using cinema.Modelo;
using cinema.Repositório;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Controlador
{
    public class UsuarioControlador
    {
        usuarioRepositorio _usuarioRepositorio;
        public UsuarioControlador() 
        {
            _usuarioRepositorio = new usuarioRepositorio();
        }
        public RetornoFuncao cadastroUsuario(string nome,string senha,string confirmarsenha) 
        {
            if ( senha != confirmarsenha ) 
            {
                return new RetornoFuncao() { sucesso = false, Descricao = "Senhas Diferentes!" };
            }

            var retorno = _usuarioRepositorio.cadastro(nome, senha);
            return retorno;
        }
    }
}
