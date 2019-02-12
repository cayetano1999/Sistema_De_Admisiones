using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Admisiones.Models
{
    public class Cursos
{
        [Key]
        public string ID_Curso { get; set; }
        [Required]
        public string Nivel { get; set; }
        [Required]
        public string Nombre_Curso { get; set; }


}
}
