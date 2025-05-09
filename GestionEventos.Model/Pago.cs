using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventos.Model
{
    public class Pago
    {
        [Key]
        public int Codigo { get; set; }

        public string MetodoPago { get; set; }

        [ForeignKey("Inscripcion")]
        public int InscripcionCodigo { get; set; }

        public Inscripcion? Inscripcion { get; set; }
    }
}
