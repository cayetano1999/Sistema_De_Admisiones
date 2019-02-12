using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema_de_Admisiones.Models
{
    public class Evaluaciones
{

        [Key]
        public int ID_Evaluacion { get; set; }

        public string Nombre_Evaluacion { get; set; }
        [ForeignKey("ID_Usuario")]
        public int ID_Usuario { get; set; }

        public string Estado { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha { get; set; }


    }
}
