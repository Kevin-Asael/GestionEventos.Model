using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Model
{
    public class AsignarPonente
    {
        [Key]
        public int Codigo { get; set; }

        [ForeignKey("Ponente")]
        public int PonenteCodigo { get; set; }

        [ForeignKey("Evento")]
        public int EventoCodigo { get; set; }

        public Ponente? Ponente { get; set; }

        public Evento? Evento { get; set; }
    }
}
