using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Admisiones.Models
{
    public class BotonesIndividuales
{

        public string tipo_boton { get; set; }
        public string action { get; set; }
        public string icono { get; set; }
        public string bonton_texto { get; set; }

        public int? ID_Notificacion { get; set; }
        public int? ID_Evaluacion { get; set; }
        public int? ID_Pago { get; set; }



        public string ParametrosdeAction
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (ID_Notificacion != 0 && ID_Notificacion != null)
                {
                    param.Append(String.Format("{0}", ID_Evaluacion));
                }

                if (ID_Evaluacion != null && ID_Evaluacion > 0)
                {
                    param.Append(String.Format("{0}", ID_Evaluacion));
                }

                if (ID_Pago != 0 && ID_Pago != null)
                {
                    param.Append(String.Format("{0}", ID_Pago));
                }


                return param.ToString().Substring(0, param.Length);
            }
        }




    }
}
