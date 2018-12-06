using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TapeDashboard.Models
{
    public class Respaldos
    {
        [Key]
        public int RespaldoID { get; set; }
        [Required]
        public string Secuencia { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }

        public string Ubicacion { get; set; }

        public bool AplicaPolitica { get; set; }

        public string Comentario { get; set; }
        [Required]
        public List<Tape> Formato { get; set; }
        [Required]
        public IEnumerable<TipoRespaldos> TipoRespaldo { get; set; }

    }
}