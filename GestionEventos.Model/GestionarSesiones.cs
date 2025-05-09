using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Model
{
    public class GestionarSesiones
    {
        [Key]
        public int Codigo { get; set; }

        public string Hora { get; set; }

        public string Sala { get; set; }

        [ForeignKey("Evento")]
        public int EventoCodigo { get; set; }

        public Evento? Evento { get; set; }
    }
}
