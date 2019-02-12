using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Admisiones.Models
{
    public class proceso
{
        [Key]
        public int ID_Poces { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Estado { get; set; }


}
}
