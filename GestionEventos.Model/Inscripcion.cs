using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEventos.Model
{
    public class Inscripcion
    {
        [Key]
        public int Codigo { get; set; }

        [ForeignKey("Evento")]
        public int EventoCodigo { get; set; }

        [ForeignKey("Participante")]
        public int ParticipanteCodigo { get; set; }

        public string Estado { get; set; }

        public DateTime Fecha { get; set; }

        public Evento? Evento { get; set; }

        public Participante? Participante { get; set; }

        public Certificado? Certificado { get; set; }

        [JsonIgnore]
        public ICollection<Pago>? Pagos { get; set; }
    }
}
