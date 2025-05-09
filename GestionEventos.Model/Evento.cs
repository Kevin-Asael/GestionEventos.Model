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
    public class Evento
    {
        [Key]
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        public string Fecha { get; set; }

        public string Lugar { get; set; }

        [ForeignKey("Tipo")]
        public int TipoCodigo { get; set; }

        public Tipo? Tipo { get; set; }

        [JsonIgnore]
        public ICollection<AsignarPonente>? Asignaciones { get; set; }

        [JsonIgnore]
        public ICollection<GestionarSesiones>? Sesiones { get; set; }

        [JsonIgnore]
        public ICollection<Inscripcion>? Inscripciones { get; set; }
    }
}
