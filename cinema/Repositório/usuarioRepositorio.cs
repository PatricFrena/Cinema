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
    public class usuarioRepositorio
    {
        public usuarioRepositorio() { }

        public RetornoFuncao realizaLogin(int codigoUsuario, string senhaUsuario) 
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var consulta = @"SELECT 1 FROM usuarios WHERE codigo = @codigo AND senha = @senha";
                var usuarioSucesso = bancoDados.Query<int>(consulta, new { codigo = codigoUsuario, senha = senhaUsuario }).FirstOrDefault() == 0 ? 0
                    : bancoDados.Query<int>(consulta, new { codigo = codigoUsuario, senha = senhaUsuario }).FirstOrDefault();

                conexao.Desconectabanco();

                if (usuarioSucesso == 0)
                    return new RetornoFuncao() { sucesso = false, Descricao = "Usuário ou Senha inválidos" };
                    return new RetornoFuncao() { sucesso = true, Descricao = "Login feito com sucesso!" };
            }
            
            catch (Exception erro) 
            {
                return new RetornoFuncao() { sucesso = false, Descricao = erro.Message };
            }

        }

        public int geraUsuario() 
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var serializa = @"SELECT codigo FROM usuarios ORDER BY codigo DESC LIMIT 1";
                return bancoDados.Query<int>(serializa).FirstOrDefault() + 1;
            }
            catch 
            {
                return 0;
            }
        }

        public RetornoFuncao cadastro(string nome, string senha)
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var codigo = geraUsuario();
                if (codigo == 0)
                    return new RetornoFuncao() { sucesso = false, Descricao = "Erro ao Serializar usuário!" };

                var usuario = new UsuarioModelo()
                {
                    codigo = codigo,
                    nome = nome,
                    senha = senha

                };
                bancoDados.Execute(@"INSERT INTO usuarios(codigo, nome, senha)values(@codigo, @nome, @senha)", usuario);
                return new RetornoFuncao() { sucesso = false, Descricao = "Usuário cadastrado com sucesso" };
            }
            catch (Exception erro)
            {
                return new RetornoFuncao() { sucesso = false, Descricao = erro.Message };
            }
        }

    }
}
