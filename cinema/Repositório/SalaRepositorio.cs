using cinema.Contexto;
using cinema.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Repositório
{
    public class SalaRepositorio
    {
        public int geraSala()
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var serializa = @"SELECT id FROM sala ORDER BY codigo DESC LIMIT 1";
                return bancoDados.Query<int>(serializa).FirstOrDefault() + 1;
            }
            catch
            {
                return 0;
            }
        }
        public RetornoFuncao cadastro(string nome, string apelido, string localizacao) 
        {
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var codigo = geraSala();
                if (codigo == 0)
                    return new RetornoFuncao() { sucesso = false, Descricao = "Erro ao Serializar usuário!" };

                var usuario = new UsuarioModelo()
                {
                    codigo = codigo,
                    nome = nome,
                    apelido = apelido,
                    localizacao = localizacao

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
