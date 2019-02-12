using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sistema_de_Admisiones.Models
{
    public class Pagos
    {
        [Key]
        public int ID_Pago { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string Concepto { get; set; }
        [Required]
        public int Total { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha { get; set; } =Convert.ToDateTime(DateTime.Now.ToShortDateString());
        [Required]
        public string Recibe { get; set; }
        [Required]
        [ForeignKey("ID_Usuario")]
        public int ID_Usuario { get; set; }



}
}
