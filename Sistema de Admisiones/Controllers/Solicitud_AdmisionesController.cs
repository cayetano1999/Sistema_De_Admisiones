using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_de_Admisiones.Data;
using Sistema_de_Admisiones.Models;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Sistema_de_Admisiones.ViewModel;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Admisiones.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace Sistema_de_Admisiones.Controllers
{
    [Authorize(Roles = RolesUsers.usuarioestudiante)]
    public class Solicitud_AdmisionesController : Controller
    {

        private ApplicationDbContext _db;
        private readonly IHostingEnvironment he;
        SQLController SQL = new SQLController();
        public Solicitud_AdmisionesController(ApplicationDbContext db, IHostingEnvironment e)
        {
            he = e;
            _db = db;
        }



        
        public IActionResult Index()
        {

            var comprobarproceso = _db.proceso.Where(p => p.Nombre == "Solicitud de Admisión").FirstOrDefault();

            var estado = comprobarproceso.Estado;

            if (estado == "Abierto")
            {

                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var completar = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();

                var comprobarsolicitud = _db.Solicitud_Admisiones.Where(admisiones => admisiones.Email == completar.Email);

                if (comprobarsolicitud.Count() > 0)
                {

                    RedirectToAction(nameof(vista));



                }

                else
                {

                    var datos = new Solicitud_Admisiones
                    {

                        Nombre = completar.Nombre,
                        Apellido = completar.Apellido,
                        Email = completar.Email,
                        Telefono = completar.Telefono,


                    };

                    return View(datos);

                }


                return View(nameof(vista));
            }
            else
            {

                return View("ProcesoCerrado");

            }

        }



        public void EliminarArchivo(string archivo, string tipoarchivo)
        {
            if (archivo != null)
            {
                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var nombrearchivo = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();


                var filename = Path.Combine(he.WebRootPath + "/Documentos", archivo);

                if (System.IO.File.Exists(filename))
                {

                    System.IO.File.Delete(filename);

                }
            }
            //archivo.CopyTo(new FileStream(filename, FileMode.Create));


        }

       
        public string ArchivosDocmentos(IFormFile archivo, string tipoarchivo)
        {
            string retornar = "";
            try
            {

                if (archivo != null && tipoarchivo != null)
                {
                    var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var nombrearchivo = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();

                    var ruta = archivo.FileName;

                    string[] extencion = ruta.Split('.');

                    var filename = Path.Combine(he.WebRootPath + "/Documentos", tipoarchivo+"-"+nombrearchivo.Nombre+"-"+nombrearchivo.ID_Usuario + "." + extencion[1]);

                    if (System.IO.File.Exists(filename))
                    {

                        System.IO.File.Delete(filename);

                    }

                    archivo.CopyTo(new FileStream(filename, FileMode.Create));


                    retornar = Path.GetFileName(filename);
                }
            }

            catch {


            }
            return retornar;

        }



        
        public IActionResult vista(string fullname, IFormFile pic)
        {

            if (pic != null)
            {
                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var nombrearchivo = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();

                var exrencion = pic.FileName;



                string[] extencion = exrencion.Split('.');

                var filename = Path.Combine(he.WebRootPath + "/FotosPerfil", "perfil-" + nombrearchivo.Email + "." + extencion[1]);

                if (System.IO.File.Exists(filename)) {

                    System.IO.File.Delete(filename);

                }

                pic.CopyTo(new FileStream(filename, FileMode.Create));
                ViewData["Ruta"] = filename.ToString();
                ViewData["Foto"] = Path.GetFileName(filename);

            }
            else
            {
                RedirectToAction(nameof(Index));
            }



            return View();






        }



       
        public IActionResult Verdocumento(string documento)
        {
            if (documento != null)
            {
                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var datos = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();
                var archivos = _db.Solicitud_Admisiones.Where(s => s.ID_Usuario == datos.ID_Usuario).FirstOrDefault();
                if (archivos != null) { 
                if (documento == archivos.URL_Acta_Nacimiento || documento == archivos.URL_Certificado_Medico || documento == archivos.URL_Foto || documento == archivos.URL_Record_Notas)
                {

                    var archivo = new Documentos
                    {

                        Tipo_Documento = documento

                    };
                    return View(archivo);
                }
                else
                {
                    return View("Error");
                }
                }
            }
            else
            {
                return View("Error");
            }

            return View();
            
            


        }




      
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index(Solicitud_Admisiones sa, IFormFile ACTA, IFormFile FOTO, IFormFile CERTIFICADO, IFormFile RECORD) {

            if(VerificarPeso(ACTA, FOTO, CERTIFICADO, RECORD) == false)
            {
                Alertas.sobrecarga = "existe";
                return View();
            }

            var comprobarproceso = _db.proceso.Where(p => p.Nombre == "Solicitud de Admisión").FirstOrDefault();
            var estado = comprobarproceso.Estado;

            if (estado == "Abierto")
            {

                if (ModelState.IsValid)
                {

                    var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var usuario = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();

                    sa.Nombre = usuario.Nombre;
                    sa.Apellido = usuario.Apellido;
                    sa.Email = usuario.Email;
                    sa.Telefono = usuario.Telefono;
                    sa.ID_Usuario = usuario.ID_Usuario;
                    sa.Usuario = usuario.Email;
                    sa.URL_Acta_Nacimiento = ArchivosDocmentos(ACTA, "ACTA");
                    sa.URL_Record_Notas = ArchivosDocmentos(RECORD, "RECORDENOTAS");
                    sa.URL_Certificado_Medico = ArchivosDocmentos(CERTIFICADO, "CERTIFICADOMEDICO");
                    sa.URL_Foto = ArchivosDocmentos(FOTO, "FOTO2X2");

                    _db.Add(sa);
                    await _db.SaveChangesAsync();

                    var procesos = new Procesos
                    {

                        Estado = "En Curso",
                        ID_Usuario = sa.ID_Usuario,
                        Nombre_Proceso = "Entrega de Documentos",
                        Porcentaje = 0


                    };

                    _db.Add(procesos);
                    await _db.SaveChangesAsync();
                    Alertas.solicitudenviada = "true";
                    return RedirectToAction(nameof(vista));
                }

                else
                {
                    Alertas.solicitudenviada = "false";
                    return View();
                }
            }
            else
            {
                return View("ProcesoCerrado");
            }


        
            

            




        }




        public IActionResult Estado()
        {



            return View();
        }









        public IActionResult Editar() {

            try {
                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var usuario = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();
                var solicitud = _db.Solicitud_Admisiones.Where(s => s.ID_Usuario == usuario.ID_Usuario).FirstOrDefault();

                if (solicitud != null)
                {
                    if(solicitud.Estado_Solicitud != "Revision" && solicitud.Estado_Solicitud != "Aprobada")
                    {
                        return View(solicitud);
                    }

                    else
                    {
                        return View("Editarerror");
                    }

                    

                }
            }
            catch
            {
                return View(nameof(vista));
            }
            Alertas.editarsolicitudnorealizada = "No se encontro ninguna solicitud para mostrar. ¿Ya realizaste tu solicitud de admisión?";
            return RedirectToAction("Inicio", "Home");


        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(
            Solicitud_Admisiones sa, 
            IFormFile ACTA, 
            IFormFile FOTO, 
            IFormFile CERTIFICADO, 
            IFormFile RECORD, 
            string accion,
            string ACTAOLD,
            string FOTOOLD,
            string CERTIFICADOOLD,
            string RECORDOLD
            )
        {

            if (VerificarPeso(ACTA, FOTO, CERTIFICADO, RECORD) == false)
            {
                Alertas.sobrecarga = "existe";
                return View();
            }


            if (sa!=null)
            {
                var solitud = await _db.Solicitud_Admisiones.SingleOrDefaultAsync(u => u.ID_Solicitud == sa.ID_Solicitud);

                if (accion == "Editar")
                {

                    if (solitud == null)
                    {
                        return NotFound();
                    }

                    else if (solitud.Estado_Solicitud == "Revision")
                    {
                        return View("Editarerror");
                    }


                    else
                    {
                        try
                        {
                            solitud.Nombre = sa.Nombre;
                            solitud.Apellido = sa.Apellido;
                            solitud.Aula = sa.Aula;
                            solitud.Centro_Procedencia = sa.Centro_Procedencia;
                            solitud.Curso = sa.Curso;
                            solitud.Direccion = sa.Direccion;
                            solitud.Edad = sa.Edad;
                            solitud.Fecha_Nacimiento = sa.Fecha_Nacimiento;
                            solitud.Lugar_Nacimiento = sa.Lugar_Nacimiento;
                            solitud.Nivel = sa.Nivel;
                            solitud.Nombre_Padre = sa.Nombre_Padre;
                            solitud.Nombre_Madre = sa.Nombre_Madre;
                            solitud.Periodo_Escolar = sa.Periodo_Escolar;
                            solitud.Tanda = sa.Tanda;
                            solitud.Telefono = sa.Telefono;
                            solitud.Telefono_Padres = sa.Telefono_Padres;

                            if (ACTA != null)
                            {
                                solitud.URL_Acta_Nacimiento = ArchivosDocmentos(ACTA, "ACTA");
                            }
                            else
                            {

                                if (ACTAOLD != null)
                                {
                                    solitud.URL_Acta_Nacimiento = ACTAOLD.ToString();
                                }
                                else
                                {
                                    solitud.URL_Acta_Nacimiento = "";
                                }
                            }


                            if (RECORD != null)
                            {
                                solitud.URL_Record_Notas = ArchivosDocmentos(RECORD, "RECORDENOTAS");
                            }

                            else
                            {
                                if (RECORDOLD != null)
                                {
                                    solitud.URL_Record_Notas = RECORDOLD.ToString();
                                }

                                else
                                {
                                    solitud.URL_Record_Notas = "";
                                }


                            }

                            if (CERTIFICADO != null)
                            {
                                solitud.URL_Certificado_Medico = ArchivosDocmentos(CERTIFICADO, "CERTIFICADOMEDICO");
                            }

                            else
                            {
                                if (CERTIFICADOOLD != null)
                                {
                                    solitud.URL_Certificado_Medico = CERTIFICADOOLD.ToString();
                                }

                                else
                                {
                                    solitud.URL_Certificado_Medico = "";
                                }
                            }

                            if (FOTO != null)
                            {
                                solitud.URL_Foto = ArchivosDocmentos(FOTO, "FOTO2X2");
                            }

                            else
                            {
                                if (FOTOOLD != null)
                                {
                                    solitud.URL_Foto = FOTOOLD.ToString();
                                }
                                else
                                {
                                    solitud.URL_Certificado_Medico = "";
                                }

                            }

                            solitud.Sexo = sa.Sexo;


                            await _db.SaveChangesAsync();
                            Alertas.editarsolicitud = "yes";
                            return RedirectToAction(nameof(Editar));
                        }
                        catch(DbUpdateException cs)
                        {
                            Alertas.editarsolicitud = "no";
                            return View(solitud);
                        }
                    }
                }
            }

            else
            {
                sa.URL_Acta_Nacimiento = "null";
                sa.URL_Certificado_Medico = "null";
                sa.URL_Foto = "null";
                sa.URL_Record_Notas = "null";
                return View(sa);
            }

            if (accion == "Eliminar")
            {
                var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var usuario = await _db.Users.SingleOrDefaultAsync(u => u.Id == iduser);
                var solicitud = await _db.Solicitud_Admisiones.Where(s => s.ID_Usuario == usuario.ID_Usuario).FirstOrDefaultAsync();
                try
                {



                    EliminarArchivo(ACTAOLD, "ACTA");
                    EliminarArchivo(RECORDOLD, "RECORDENOTAS");
                    EliminarArchivo(CERTIFICADOOLD, "CERTIFICADOMEDICO");
                    EliminarArchivo(FOTOOLD, "FOTO2X2");
                    SQL.Limpieza(usuario.ID_Usuario, "Procesos");
                    SQL.Limpieza(usuario.ID_Usuario, "Evaluaciones");



                    _db.Remove(solicitud);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Inicio", "Home");
                }
                catch (IOException x)
                {

                    RedirectToAction(nameof(vista));

                }


            }
            

            return RedirectToAction(nameof(Index));

    }
            


            
        public IActionResult HojadeAdmision()
        {
            var iduser = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var usuario = _db.Users.Where(u => u.Id == iduser).FirstOrDefault();

            var datos = _db.Solicitud_Admisiones.Where(a => a.ID_Usuario == usuario.ID_Usuario).Where(a=>a.Estado_Solicitud=="Aprobada").FirstOrDefault();

            if (datos != null)
            {
                var retornar = new Hojadeadmision
                {

                    Nombre = datos.Nombre + " " + datos.Apellido,
                    Aula = datos.Aula,
                    Curso = datos.Curso,
                    Nivel = datos.Nivel,
                    Periodo = datos.Periodo_Escolar,
                    Tanda = datos.Tanda


                };


                return View(retornar);
            }

            else
            {
                Alertas.verhoja = "no";
                return RedirectToAction("Inicio","Home");
            }
        }
        


       
     

        public bool VerificarPeso(IFormFile ACTA, IFormFile FOTO, IFormFile CERTIFICADO, IFormFile RECORD)
        {
           
            bool retornar = true;

            try
            {
                if (ACTA.Length > 5000000)
                {
                    retornar = false;
                }

                else if (FOTO.Length > 5000000)
                {
                    retornar = false;
                }

                else if (FOTO.Length > 5000000)
                {
                    retornar = false;
                }
                else if (FOTO.Length > 5000000)
                {
                    retornar = false;
                }
            }
            catch(NullReferenceException x)
            {

            }

            return retornar;

        }








        protected override void Dispose(bool disposing)
        {
            if (disposing) {

                _db.Dispose();

            }
        }


    }
}