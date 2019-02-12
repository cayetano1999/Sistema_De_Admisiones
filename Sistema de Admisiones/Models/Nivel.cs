using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Admisiones.Models
{
    public class Nivel
{
        [Key]
        public int ID_Nivel { get; set; }
        [Required]
        public string Nombre_Nivel { get; set; }


}
}
