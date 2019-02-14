using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Sistema_de_Admisiones.ViewModel;
using System.Web;


/*
 
    Este controlador es solo para realizar consultas de procesos almacenados y de vistas 
     
 */

namespace Sistema_de_Admisiones.Controllers
{
    public class SQLController : Controller
    {

        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlConnection cn;
        public DataTable dt;


        public SQLController()
        {
            try
            {
                cn = new SqlConnection("");
                cn.Open();
            }

            catch (SqlException X) {

                

            }
        }


       

        public IActionResult Index()
        {
            
            dt = new DataTable();
            cmd = cn.CreateCommand();
            cmd.CommandText = ("select *from EVALUACIONPSICOLOGICAASIGNADA");
            dr = cmd.ExecuteReader();
            //dt.Load(dr);

            var listaevaluacion = new List<EvaluacionAsignadaViewModel>();

            // DataRow registro = dt.Rows[0];

            
            
            while (dr.Read()) {

                var EVALUACION = new EvaluacionAsignadaViewModel
                {


                    Id_Evaluacion = int.Parse(dr["ID_Evaluacion"].ToString()),
                    Nombre_Evaluacion = dr["Nombre_Evaluacion"].ToString(),
                    Usuario = dr["Usuario"].ToString(),
                    Fecha = Convert.ToDateTime(Convert.ToDateTime(dr["Fecha"].ToString()).ToShortDateString()),
                    Estado = dr["Estado"].ToString(),
                    ID_Usuario = int.Parse(dr["ID_Usuario"].ToString())


                };

                listaevaluacion.Add(EVALUACION);




            }

            


            
            cn.Close();
            dr.Close();
            return View(listaevaluacion.ToList());
        }


        public string AspUserId()
        {
            string retornar = "1";
            dt = new DataTable();
            cmd = cn.CreateCommand();
            cmd.CommandText = ("select max(ID_Usuario) as Maximo from AspNetUsers");
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            if (dt.Rows.Count > 0) { 
            DataRow maximo = dt.Rows[0];

                retornar = maximo["Maximo"].ToString();

            }
            dr.Close();
            cn.Close();
            return retornar;
        }



        public  int CargarPorcentajes(int idusuario, string proceso)
        {
            int retornar = 0;

            dt = new DataTable();
            cmd = cn.CreateCommand();
            cmd.CommandText = ("Select Porcentaje from Procesos where ID_Usuario =@idusuario and Nombre_Proceso =@proceso ");
            cmd.Parameters.AddWithValue("@idusuario", idusuario);
            cmd.Parameters.AddWithValue("@proceso", proceso);
            dr = cmd.ExecuteReader();
            dt.Load(dr);

            if (dt.Rows.Count > 0)
            {
                DataRow registro = dt.Rows[0];
                retornar = int.Parse(registro["Porcentaje"].ToString());
            }
            else
            {
                retornar = 0;
            }


            return retornar;
        }

        public void EliminarNotificacion( int? id)
        {
            try
            {
                cmd = cn.CreateCommand();
                cmd.CommandText = ("delete Notificaciones where ID_Notificacion=@id");
                cmd.Parameters.AddWithValue("@id", id);
                
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }

        public void Limpieza(int id, string tabla)
        {

            cmd = cn.CreateCommand();
            cmd.CommandText = ("delete from "+tabla+" where ID_Usuario=@id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }



    }


    }

