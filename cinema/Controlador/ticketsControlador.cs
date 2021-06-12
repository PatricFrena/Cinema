using cinema.Modelo;
using cinema.Repositório;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace cinema.Controlador
{
    public class ticketsControlador
    {
        ticketsRepositorio _ticketsRepositorio;

        public ticketsControlador() 
        {
            _ticketsRepositorio = new ticketsRepositorio();
        }

        public RetornoFuncao CadastrarTicket(int idSala, int idFilme,
                int sessaoFinalizada, List<Button> Listabotoes)

        {     
                if (idSala == 0)
                    return new RetornoFuncao()
                    {
                        sucesso = false,
                        Descricao = "Nenhuma sala informada!"
                    };

            if (idFilme == 0)
                return new RetornoFuncao()
                {
                    sucesso = false,
                    Descricao = "Nenhum filme informado!"
                };

            List<PoltronasModelo> poltronas = new List<PoltronasModelo>();
            foreach (var botoes in Listabotoes)
            {
                PoltronasModelo poltrona = new PoltronasModelo()
                {
                    poltrona = botoes.Text.Trim(),
                    disponivel = botoes.BackColor == Color.Red ? 0 : 1
                };
                poltronas.Add(poltrona);
            };

            var JsonPoltronas = new JavaScriptSerializer().Serialize(poltronas);

            ticketsModelo ticket = new ticketsModelo()
            {
                idSala = idSala,
                idFilme = idFilme,
                sessaoFinalizada = sessaoFinalizada,
                poltronas = JsonPoltronas
            };
            return _ticketsRepositorio.cadastrarTicket(ticket);
        }

        public RetornoFuncao buscaSessaoAtiva(int idSala, int idFilme) 
        {
            try 
            {
                if (idSala == 0)
                    return new RetornoFuncao()
                    {
                        sucesso = false,
                        Descricao = "Nenhuma sala informada!"
                    };

                if (idFilme == 0)
                    return new RetornoFuncao()
                    {
                        sucesso = false,
                        Descricao = "Nenhum filme informado!"
                    };

                var sessoes = _ticketsRepositorio.verificarSessaoFilmesSalaAtiva(idSala, idFilme);
                bool sessaoNaoFinalizada = false;
                foreach (var sessao in sessoes)
                {
                    if (sessao.sessaoFinalizada == 0)
                    {
                        sessaoNaoFinalizada = true;
                        break;
                    }
                }

                if (sessaoNaoFinalizada)
                {
                    return new RetornoFuncao()
                    {
                        sucesso = true,
                        Descricao = ""
                    };
                }
                else 
                {
                    return new RetornoFuncao()
                    {
                        sucesso = false,
                        Descricao = "Existe sessão em aberto!"
                    };
                }
            }
            catch (Exception ex)
            {
                return
                   new RetornoFuncao()
                   {
                      sucesso = true,
                      Descricao = "Erro ao verificar sessão: " + ex
                   };
            }
        }

        public List<PoltronasModelo> buscaPoltronaSessao(int idSala, int idFilme)
        {
            try 
            {
                if (idSala == 0)
                    return null;

                if (idFilme == 0)
                    return null;
                
                var sessoes = _ticketsRepositorio.verificarSessaoFilmesSalaAtiva(idSala, idFilme);
                string poltronas = "";
                foreach (var sessao in sessoes)
                {
                    if (sessao.sessaoFinalizada == 0)
                    {
                        poltronas = sessao.poltronas;
                        break;
                    }
                }

                var listaPoltronas = JsonConvert.DeserializeObject<List<PoltronasModelo>>(poltronas);
                return listaPoltronas;
            }
            catch 
            {
                return null;
            }
        }
    }
}
    

