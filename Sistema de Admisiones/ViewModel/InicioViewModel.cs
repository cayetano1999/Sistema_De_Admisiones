using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Admisiones.ViewModel
{
    public class InicioViewModel
{

        public string NombreCompleto { get; set; }
        public string Rol { get; set; } = "ESTUDIANTE";
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }

        public int Entrega { get; set; }
        public int Revicion { get; set; }
        public int Psicologica { get; set; }
        public int Conocimientos { get; set; }
        public int Respuesta { get; set; }
        public int Pago { get; set; }
        public string Estado { get; set; }
        public string Puedeeditar { get; set; }
        public string Procesoactual { get; set; }
        public bool solititudadmision { get; set; }
        public int Notificaciones { get; set; }
        public int ID_Usuario { get; set; }


}
}
