using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Sistema_de_Admisiones.Models
{
    public class Usuarios
{

        [Key]
        public int ID_Usuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre_Usuario { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public string Referencia_Clave { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tipo_Usuario { get; set; }
        [Required]
        public string Imagen { get; set; }






    }
}
