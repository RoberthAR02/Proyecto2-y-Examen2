using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

        public Usuarios()
        {
            Nombre = string.Empty;
            CorreoElectronico = string.Empty;
            Telefono = string.Empty;
        }

        public Usuarios(string nombre, string correoElectronico, string telefono)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }

        public bool agregarUsuario()
        {
            int success = Base_de_datos.InsertarUsuario(Nombre, CorreoElectronico, Telefono);

            return success > 0;
        }

        public bool borrarUsuario()
        {
            int success = Base_de_datos.BorrarUsuariosPorId(Id);

            return success > 0;
        }

        public bool modificarUsuario()
        {
            int success = Base_de_datos.ActualizarUsuarioPorId(Id, Nombre, CorreoElectronico, Telefono);

            return success > 0;
        }

        public bool consultarUsuario(GridView dg)
        {
            int success = Base_de_datos.ConsultarUsuariosPorId(Id, dg);

            return success > 0;
        }
    }
}