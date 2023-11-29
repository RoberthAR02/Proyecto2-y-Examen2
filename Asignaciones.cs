using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Asignaciones
    {
        public int AsignacionID { get; set; }
        public int ReparacionID { get; set; }

        public int TecnicoID { get; set; }

        public string FechaAsignacion { get; set; }

        public Asignaciones()
        {
            ReparacionID = 0;
            TecnicoID = 0;
            FechaAsignacion = string.Empty;
        }

        public bool AgregarAsignacion()
        {
            int success = Base_de_datos.InsertarAsignacion(ReparacionID, TecnicoID);

            return success > 0;
        }

        public bool BorrarAsignacion()
        {
            int success = Base_de_datos.borrarAsignacionesPorId(ReparacionID);

            return success > 0;
        }

        public bool ModificarAsignacion()
        {
            int success = Base_de_datos.ActualizarAsignacionPorId(AsignacionID, ReparacionID, TecnicoID);

            return success > 0;
        }

        public bool ConsultarAsignacion(GridView dg)
        {
            int success = Base_de_datos.ConsultarAsignacionesPorId(AsignacionID, dg);

            return success > 0;
        }
    }
}