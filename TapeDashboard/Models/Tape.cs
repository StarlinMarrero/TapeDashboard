using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TapeDashboard.Models
{
    public class Tape
    {
        [Key]
        public int TapeID { get; set; }
        [Required]
        public string Formato { get; set; }
        [Required]
        public decimal CantidadTotal { get; set; }
        [Required]
        public decimal CantidadEnUso { get; set; }
        [Required]
        public decimal CantidadDisponible { get; set; }

        [Required]
        public string LabelFisico { get; set; }
    }
}