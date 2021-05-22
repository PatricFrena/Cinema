using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Modelo
{
    public class ticketsModelo
    {
        public int id { get; set; }
        public int idSala { get; set; }
        public int idFilme { get; set; }
        public int sessaoFinalizada { get; set; }
        public string poltronas { get; set; }


    }
}
