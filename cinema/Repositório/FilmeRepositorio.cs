using cinema.Contexto;
using cinema.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace cinema.Repositório
{
    public class FilmeRepositorio
    {
        public List<FilmeModelo> BuscaFilmes()
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();

                var bancoDados = conexao.conexaobanco();

                var filme = bancoDados.Query<FilmeModelo>("Select * from filmes Where ativo = 1;").ToList();

                return filme;


            }
            catch { return null; }
        }

        public int geraFilme()
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var serializa = @"SELECT id FROM filmes ORDER BY id DESC LIMIT 1";
                return bancoDados.Query<int>(serializa).FirstOrDefault() + 1;
            }
            catch
            {
                return 0;
            }
        }
        public RetornoFuncao cadastroFilme(string nome, string descricao, int situacao) 
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var codigo = geraFilme();
                if (codigo == 0)
                    return new RetornoFuncao() { sucesso = false, Descricao = "Erro ao cadastrar filme!" };

                var usuario = new FilmeModelo()
                {
                    id = codigo,
                    nome = nome,
                    descricao = descricao,
                    ativo = situacao

                };
                bancoDados.Execute(@"INSERT INTO filmes(id, nome, descricao, ativo)values(@id, @nome, @descricao, @ativo)", usuario);
                return new RetornoFuncao() { sucesso = false, Descricao = "Filme cadastrado com sucesso" };
            }
            catch (Exception erro)
            {
                return new RetornoFuncao() { sucesso = false, Descricao = erro.Message };
            }
        }
    }
}
