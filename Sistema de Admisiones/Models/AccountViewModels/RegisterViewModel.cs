using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Admisiones.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La contraseña debe ser más larga.", MinimumLength = 6)]
      
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required (ErrorMessage ="Debes introducir tu nombre")]
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
