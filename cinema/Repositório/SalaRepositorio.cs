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
    public class SalaRepositorio
    {
        public List<SalaModelo> buscaSalas()
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();

                var bancoDados = conexao.conexaobanco();

                var sala = bancoDados.Query<SalaModelo>("Select * from sala;").ToList();

                return sala;


            }
            catch { return null; }
        }

        public int geraSala()
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var serializa = @"SELECT id FROM sala ORDER BY id DESC LIMIT 1";
                return bancoDados.Query<int>(serializa).FirstOrDefault() + 1;
            }
            catch
            {
                return 0;
            }
        }
        public RetornoFuncao cadastro(string nome, string apelido, string localizacao) 
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var bancoDados = conexao.conexaobanco();
                var codigo = geraSala();
                if (codigo == 0)
                    return new RetornoFuncao() { sucesso = false, Descricao = "Erro ao cadastrar sala!" };

                var usuario = new SalaModelo()
                {
                    id = codigo,
                    nome = nome,
                    apelido = apelido,
                    localizacao = localizacao

                };
                bancoDados.Execute(@"INSERT INTO sala(id, nome, apelido, localizacao)values(@id, @nome, @apelido, @localizacao)", usuario);
                return new RetornoFuncao() { sucesso = false, Descricao = "Sala cadastrada com sucesso" };
            }
            catch (Exception erro)
            {
                return new RetornoFuncao() { sucesso = false, Descricao = erro.Message };
            }
        }

    }
}
