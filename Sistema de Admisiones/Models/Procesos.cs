using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration.Assemblies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Admisiones.Models
{
    public class Procesos
{
        [Key]
        public int ID_Proceso { get; set; }
        [Required]
        public string Nombre_Proceso { get; set; }
        [Required]
        [ForeignKey("ID_Usuario")]
        public int ID_Usuario { get; set; }
        [Required]
        public int Porcentaje { get; set; }
        [Required]
        public string Estado { get; set; }



    }
}
