using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Reparaciones
    {
        public int ReparacionID { get; set; }
        public int EquipoID { get; set; }
        public string FechaSolicitud { get; set; }
        public char Estado { get; set; }

        public Reparaciones()
        {
            EquipoID = 0;
            FechaSolicitud = string.Empty;
            Estado = 'z';
        }

        public bool agregarReparacion()
        {
            int success = Base_de_datos.InsertarReparacion(EquipoID, Estado);

            return success > 0;
        }

        public bool borrarReparacion()
        {
            int success = Base_de_datos.BorrarReparacionesPorId(ReparacionID);

            return success > 0;
        }

        public bool modificarReparacion()
        {
            int success = Base_de_datos.ActualizarReparacionPorId(ReparacionID, EquipoID, Estado);

            return success > 0;
        }

        public bool consultarReparacion(GridView dg)
        {
            int success = Base_de_datos.ConsultarReparacionesPorId(ReparacionID, dg);

            return success > 0;
        }
    }
}