using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public  partial class Equipos
    {
        public int Id { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int UsuarioID { get; set; }

        public Equipos()
        {
            TipoEquipo = string.Empty;
            Modelo = string.Empty;
        }

        public Equipos(int id, string tipoEquipo, string modelo, int usuarioID)
        {
            Id = id;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            UsuarioID = usuarioID;
        }

        public bool agregarEquipo()
        {
            int success = Base_de_datos.insertarEquipo(TipoEquipo, Modelo, UsuarioID);

            return success > 0;
        }

        public bool borrarEquipo()
        {
            int success = Base_de_datos.borrarEquiposPorId(Id);

            return success > 0;
        }

        public bool modificarEquipo()
        {
            int success = Base_de_datos.actualizarEquipoPorId(Id, TipoEquipo, Modelo, UsuarioID);

            return success > 0;
        }

        public bool consultarUsuario(GridView dg)
        {
            int success = Base_de_datos.consultarEquiposPorId(Id, dg);

            return success > 0;
        }
    }
}