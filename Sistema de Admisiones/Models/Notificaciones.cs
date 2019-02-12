using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Admisiones.Models
{
    public class Notificaciones
    {
        [Key]
        public int ID_Notificacion { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [ForeignKey("ID_Usuario")]
        public int ID_Usuario { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string Fecha { get; set; }
        [Required]
        public string Estado { get; set; }



    }
}
