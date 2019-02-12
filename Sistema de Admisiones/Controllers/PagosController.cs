using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Admisiones.Data;
using Sistema_de_Admisiones.Models;

namespace Sistema_de_Admisiones.Controllers
{
    public class PagosController : Controller
    {

        private ApplicationDbContext _db;
    
        SQLController SQL = new SQLController();
        public PagosController(ApplicationDbContext db)
        {
            
            _db = db;
        }


        public IActionResult Index()
        {
            var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();
            var pago = _db.Pagos.Where(p => p.ID_Usuario == usuario.ID_Usuario).FirstOrDefault();
            if (pago != null) { 
            var retornar = new Pagos
            {

                Usuario = pago.Usuario,
                Cantidad = pago.Cantidad,
                Concepto = pago.Concepto,
                Total = pago.Total,
                Fecha = pago.Fecha,
                Recibe = pago.Recibe

            };
                return View(retornar);
            }
            else
            {
                return RedirectToAction("Inicio","Home");
            }


            
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