using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Admisiones.Data;
using Sistema_de_Admisiones.Models;
using Sistema_de_Admisiones.Utility;

namespace Sistema_de_Admisiones.Controllers
{
    public class NotificacionController : Controller
    {

        private readonly ApplicationDbContext _db;


        public NotificacionController( ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = RolesUsers.usuarioestudiante)]
        public IActionResult Index()
        {
            var idusuario = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = _db.Users.Where(u => u.Id == idusuario).FirstOrDefault();

            var notificaciones = _db.Notificaciones.Where(n => n.ID_Usuario == usuario.ID_Usuario).ToList().OrderByDescending(n=>n.ID_Notificacion);

            if (notificaciones != null)
            {
                return View(notificaciones);

            }

            return View();
            

        }


        [Authorize(Roles = RolesUsers.usuarioestudiante)]
        [HttpGet]
        public IActionResult VerNotificacion(int? id)
        {

            if (id == null)
            {
                return View("Error");
            }

            var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();
            try
            {
                var notificacion = _db.Notificaciones.Where(n => n.ID_Notificacion == id).Where(n => n.ID_Usuario == usuario.ID_Usuario).FirstOrDefault();

                if (notificacion != null)
                {

                    var detalles = new Notificaciones
                    {

                        Fecha = notificacion.Fecha,
                        Titulo = notificacion.Titulo,
                        Descripcion = notificacion.Descripcion,
                        ID_Usuario = notificacion.ID_Usuario,
                        ID_Notificacion = notificacion.ID_Notificacion,
                        Estado = notificacion.Estado,


                    };

                    return View(detalles);

                }

                else
                {
                    return View("Error");
                }
            }
            catch (InvalidOperationException)
            {

            }

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesUsers.usuarioestudiante)]
        public async Task<IActionResult> Editar(Notificaciones nf)
        {
            // var noti = await _db.Notificaciones.SingleOrDefault(n=>n.ID_Notificacion == nf.ID_Notificacion);

            var Notificacion = await _db.Notificaciones.SingleOrDefaultAsync(n => n.ID_Notificacion == nf.ID_Notificacion);

            //var Notificacion = await _db.Notificacione.SingleOrDefaultAsync(u=>u. == nf.ID_Notificacion);


            Notificacion.Fecha = nf.Fecha;
            Notificacion.Estado = "Leida";
            Notificacion.Titulo = nf.Titulo;
            Notificacion.Descripcion = nf.Descripcion;
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        
        
        public IActionResult Eliminar(int? id)
        {
            SQLController sQL = new SQLController();
            sQL.EliminarNotificacion(id);
            var idusuario = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var datos = _db.Users.Where(u => u.Id == idusuario).FirstOrDefault();
            var cantidaddenotificaciones = _db.Notificaciones.Where(n => n.ID_Usuario == datos.ID_Usuario).Where(n => n.Estado == "Sin Leer").Count();
            Alertas.cantidaddenotificacion = cantidaddenotificaciones;
            return RedirectToAction(nameof(Index));
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