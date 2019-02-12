using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Admisiones.Data;
using System.Security.Claims;
using Sistema_de_Admisiones.Models;
using Sistema_de_Admisiones.Utility;
using Microsoft.AspNetCore.Authorization;

namespace Sistema_de_Admisiones.Controllers
{
    [Authorize(Roles = RolesUsers.usuarioestudiante)]
    public class EvaluacionesController : Controller
    {

        private ApplicationDbContext _db;

        public EvaluacionesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usurio = _db.Users.Where(u => u.Id == userid).FirstOrDefault();          
            var Evaluaciones = _db.Evaluaciones.Where(e=>e.ID_Usuario == usurio.ID_Usuario);            
            return View(Evaluaciones.ToList());

        }

        public IActionResult VerNotificacion(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var notificacion = _db.Notificaciones.Where(n => n.ID_Notificacion == id).FirstOrDefault();

            if (notificacion != null) {

                var detalles = new Notificaciones {

                    Fecha = notificacion.Fecha,
                    Titulo = notificacion.Titulo,
                    Descripcion = notificacion.Descripcion

                };

                return View(detalles);

            }

            else
            {
                return View("Error");
            }
            

            
        }
    }
}