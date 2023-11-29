using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Reparaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
                fillEquipos();
            }
        }
        protected void fillGrid()
        {
            int success = rarExamen.Base_de_datos.ConsultarReparaciones(dgReparaciones);

            if (success > 0)
            {
                Console.Write(success.ToString());
            }
        }

        protected void fillEquipos()
        {
            int success = rarExamen.Base_de_datos.ConsultarEquiposReparaciones(ddEquipo);

            if (success > 0)
            {
                Console.Write(success.ToString());
            }
        }

        protected void add()
        {
            rarExamen.Reparaciones reparacion = new rarExamen.Reparaciones();
            if (!txtFecha.Text.Trim().Equals(string.Empty))
            {
                reparacion.FechaSolicitud = txtFecha.Text.Trim();
            }
            else { return; }
            if (!txtEstado.Text.Trim().Equals(string.Empty))
            {
                reparacion.Estado = txtEstado.Text.Trim()[0];
            }
            else { return; }
            if (!ddEquipo.SelectedValue.Trim().Equals(string.Empty))
            {
                reparacion.EquipoID = int.Parse(ddEquipo.SelectedValue.Trim());
            }
            else { return; }

            if (reparacion.agregarReparacion())
            {
                fillGrid();
            }
        }

        protected void delete()
        {
            rarExamen.Reparaciones reparacion = new rarExamen.Reparaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                reparacion.ReparacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (reparacion.borrarReparacion())
            {
                fillGrid();
            }
        }

        protected void modificar()
        {
            rarExamen.Reparaciones reparacion = new rarExamen.Reparaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                reparacion.ReparacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }
            if (!txtFecha.Text.Trim().Equals(string.Empty))
            {
                reparacion.FechaSolicitud = txtFecha.Text.Trim();
            }
            else { return; }
            if (!txtEstado.Text.Trim().Equals(string.Empty))
            {
                reparacion.Estado = txtEstado.Text.Trim()[0];
            }
            else { return; }
            if (!ddEquipo.SelectedValue.Trim().Equals(string.Empty))
            {
                reparacion.EquipoID = int.Parse(ddEquipo.SelectedValue.Trim());
            }
            else { return; }

            if (reparacion.modificarReparacion())
            {
                fillGrid();
            }
        }

        protected void consultar()
        {
            rarExamen.Reparaciones reparacion = new rarExamen.Reparaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                reparacion.ReparacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (reparacion.consultarReparacion(dgReparaciones))
            {
                fillGrid();
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            add();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            delete();
        }

        protected void BtnModificar_Click(object senter, EventArgs e)
        {
            modificar();
        }

        protected void BtnConsultar_Click(object senter, EventArgs e)
        {
            consultar();
        }

        protected void BtnReset_Click(object senter, EventArgs e)
        {
            fillGrid();
        }
    }
}