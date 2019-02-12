using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Admisiones.Models
{
    public class Periodo
{
    
     [Key]
    public int ID_Periodo { get; set; }
    [Required]
    public string Periodo_Escolar { get; set; }

}
}
