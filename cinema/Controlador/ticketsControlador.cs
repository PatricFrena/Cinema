using cinema.Modelo;
using cinema.Repositório;
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

        }
    }
}
    

