using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_de_Admisiones.Models
{
    public class Solicitud_Admisiones
    {



        //Agregados por el Sistema
        [Key]
        [Required(ErrorMessage = "El ID es obligatorio")]

        public int ID_Solicitud { get; set; }

        [Required(ErrorMessage = "El Fehca es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha_Solicitud { get; set; } = Convert.ToDateTime( DateTime.Now.ToShortDateString());

        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El ID_Usuario es obligatorio")]
        [ForeignKey ("ID_Usuario")]
        public int ID_Usuario { get; set; }

        [Required(ErrorMessage = "El Estado es obligatorio")]
        public string Estado_Solicitud { get; set; }


        //Datos de Solicitantes

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public string Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El lugar de nacimiento es obligatorio")]
        public string Lugar_Nacimiento { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "El numero de telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El E-Mail es obligatorio")]
        public string Email { get; set; }



        //Datos de estudio

        [Required(ErrorMessage = "El centro de procedencia es obligatorio")]
        public string Centro_Procedencia { get; set; }

        [Required(ErrorMessage = "Debes de seleccionar el periodo escolar en el que deseas inscribirte")]
        public string Periodo_Escolar { get; set; }

        [Required(ErrorMessage = "Debes seleccionar el nivel académico en el que deseas escribirte")]
        public string Nivel { get; set; }

        [Required(ErrorMessage = "Debes seleccionar el curso en el que deseas inscribirte")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Debes seleccionar el aula")]
        public string Aula { get; set; }
        [Required(ErrorMessage = "Debes seleccionar ela tanda")]
        public string Tanda { get; set; }




        //Datos de Padres 
        [Required(ErrorMessage = "El Nombre del PADRE es obligatorio")]
        public string Nombre_Padre { get; set; }

        [Required(ErrorMessage = "El Nombre del la MADRE es obligatorio")]
        public string Nombre_Madre { get; set; }

        [Required(ErrorMessage = "El Telefono de contacto es obligatorio")]
        public string Telefono_Padres { get; set; }



        //Datos de Documentos
        public string URL_Acta_Nacimiento { get; set; }
        
        public string URL_Foto { get; set; }
        
        public string URL_Certificado_Medico { get; set; }
        
        public string URL_Record_Notas { get; set; }








    }
}
