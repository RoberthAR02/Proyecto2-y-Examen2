using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class DetallesDeReparacion
    {
        public int DetalleID { get; set; }
        public int ReparacionID { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        public DetallesDeReparacion()
        {
            ReparacionID = 0;
            Descripcion = string.Empty;
            FechaFin = string.Empty;
            FechaInicio = string.Empty;
        }

        public bool AgregarDetallesDeReparacion()
        {
            int success = Base_de_datos.InsertarDetalleDeReparacion(ReparacionID, Descripcion);

            return success > 0;
        }

        public bool BorrarDetallesDeReparacion()
        {
            int success = Base_de_datos.BorrarDetallesDeReparacionPorId(DetalleID);

            return success > 0;
        }

        public bool ModificarDetallesDeReparacion()
        {
            int success = Base_de_datos.ActualizarDetallesDeReparacionPorId(DetalleID, ReparacionID, Descripcion, FechaFin);

            return success > 0;
        }

        public bool ConsultarDetallesDeReparacion(GridView dg)
        {
            int success = Base_de_datos.ConsultarDetallesDeReparacionPorId(DetalleID, dg);

            return success >= 0;
        }
    }
}