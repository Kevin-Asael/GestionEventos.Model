using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEventos.Model
{
    public class Ponente
    {
        [Key]
        public int Codigo { get; set; }

        public string Nombre { get; set; }

        [JsonIgnore]
        public ICollection<AsignarPonente>? Asignaciones { get; set; }
    }
}
