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
    public class ticketsRepositorio
    {
        public ticketsRepositorio() { }

        public int serializaTicket()
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();
                var BancoDados = conexao.conexaobanco();

                var serializa = @"SELECT id FROM ticket ORDER by id DESC LIMIT 1";

                var idTicket = BancoDados.Query<int>(serializa).FirstOrDefault() + 1;

                return idTicket;
            }
            catch 
            {
                return 0;
            }
        }

        public RetornoFuncao cadastrarTicket(ticketsModelo ticket) 
        {
            try 
            {
                var conexao = new BancoDadosDapperContexto();
                var BancoDados = conexao.conexaobanco();

                var idTicket = serializaTicket();
                if (idTicket == 0)
                    return new RetornoFuncao()
                    {
                        sucesso = false,
                        Descricao = "Ocorreu um erro na serialização!"
                    };

                ticket.id = idTicket;

                BancoDados.Execute(@"insert INTO ticket(id, idsala, idfilme, sessaoFinalizada, poltronas)
                                  values (@id, @idsala, @idfilme, @sessaoFinalizada, @poltronas)", ticket);

                return new RetornoFuncao()
                {
                    sucesso = true,
                    Descricao = "Cadastro com sucesso!!"
                };

            }
            catch(Exception ex) 
            {
                return new RetornoFuncao()
                {
                    sucesso = false,
                    Descricao = ex.Message
                };
            }
        }

        public RetornoFuncao atualizarTicket(ticketsModelo tickets)
        {
            try
            {
                var conexao = new BancoDadosDapperContexto();
                var BancoDados = conexao.conexaobanco();

                BancoDados.Execute(@"UPDATE ticket SET idFilme =
                @idFilme, idSala = @idSala, sessaoFinalizada =
                @sessaoFinalizada, poltronas = @poltronas  WHERE id = @id", tickets);

                return new RetornoFuncao()
                {
                    sucesso = true,
                    Descricao = "Atualizado ticket da sessão!"
                };
            }
            catch(Exception ex) 
            {
                return new RetornoFuncao()
                {
                    sucesso = false,
                    Descricao = ex.Message
                };
            }
        }

    }
}
