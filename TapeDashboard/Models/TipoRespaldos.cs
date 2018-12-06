using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TapeDashboard.Models
{
    public class TipoRespaldos
    {
        [Key]
        [Required]
        public int TipoRespaldoID { get; set; }
        [Required]
        public string TipoRespaldo { get; set; }
        [Required]
        public string Estatus { get; set; }

    }
}