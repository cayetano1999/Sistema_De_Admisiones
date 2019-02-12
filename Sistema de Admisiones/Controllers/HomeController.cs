using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Admisiones.Data;
using Sistema_de_Admisiones.Models;
using Sistema_de_Admisiones.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Sistema_de_Admisiones.Utility;

namespace Sistema_de_Admisiones.Controllers
{
    [Authorize(Roles = RolesUsers.usuarioestudiante)]
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        public SQLController SQL = new SQLController();
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //return View();

            var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (iduser == null)
            {
                return RedirectToAction("Login", "Account");

            }
            else
            {
                return RedirectToAction("Inicio", "Home");
            }

            return View();
            

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Inicio()
        {
            var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            var datos = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();
            if (datos != null)
            {
                string Nombre_Completo = datos.Nombre + " " + datos.Apellido;
                string estado = "";
                string editar = "";
                string proceso = "";
                bool solicitudadmision = false;
                var solicitud = _db.Solicitud_Admisiones.Where(s => s.ID_Usuario == datos.ID_Usuario).FirstOrDefault();
                var procesactual = _db.Procesos.Where(p => p.ID_Usuario == datos.ID_Usuario).Where(p => p.Estado == "En Curso").FirstOrDefault();

                

                var cantidaddenotificaciones = _db.Notificaciones.Where(n => n.ID_Usuario == datos.ID_Usuario).Where(n => n.Estado == "Sin Leer").Count();
                Alertas.cantidaddenotificacion = cantidaddenotificaciones;

                if (solicitud != null)
                {

                     estado = solicitud.Estado_Solicitud;

                    if (estado == "Revision" || estado=="Aprobada")
                    {
                        editar = "NO";
                    }
                    else
                    {
                        editar = "SI";
                    }
                    if (procesactual != null)
                    {
                        proceso = procesactual.Nombre_Proceso;
                    }
                    else
                    {
                        proceso = "No estas en ningún proceso.";
                    }
                    solicitudadmision = true;


                }

               

                var modelo = new InicioViewModel
                {

                    NombreCompleto = Nombre_Completo,
                    Email = datos.Email,
                    Telefono = datos.Telefono,
                    Rol = "ESTUDIANTE",
                    Imagen = datos.Imagen,
                    Entrega = SQL.CargarPorcentajes(datos.ID_Usuario, "Entrega de Documentos"),
                    Revicion = SQL.CargarPorcentajes(datos.ID_Usuario, "Revisión de Documentos"),
                    Psicologica = SQL.CargarPorcentajes(datos.ID_Usuario, "Evaluación Psicológica"),
                    Conocimientos = SQL.CargarPorcentajes(datos.ID_Usuario, "Evaluación de Conocimientos"),
                    Respuesta = SQL.CargarPorcentajes(datos.ID_Usuario, "Respuesta Admisión"),
                    Pago = SQL.CargarPorcentajes(datos.ID_Usuario, "Pago Inscripción"),
                    Estado = estado,
                    Puedeeditar = editar,
                    Procesoactual = proceso,
                    solititudadmision = solicitudadmision,
                    Notificaciones = cantidaddenotificaciones,
                    ID_Usuario = datos.ID_Usuario
                    



                };




                return View(modelo);
            }

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                _db.Dispose();

            }
        }


    }
}
