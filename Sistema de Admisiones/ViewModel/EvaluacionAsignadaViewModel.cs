using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sistema_de_Admisiones.ViewModel
{
    public class EvaluacionAsignadaViewModel
{
        public int Id_Evaluacion { get; set; }
        public string Nombre_Evaluacion { get; set; }
        public string Usuario { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int ID_Usuario { get; set; }



}
}
