using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Admisiones.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }

        [Required(ErrorMessage = "Debes introducir tu nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debes introducir tu apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debes introducir el teléfono")]
        public string Telefono { get; set; }

        [Required]
        public string Tipo_Usuario { get; set; }

        public string Imgen { get; set; }

        public int ID_Usuario { get; set; }

    }
}
