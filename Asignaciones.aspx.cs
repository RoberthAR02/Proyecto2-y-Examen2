using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Asignaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
                fillReparaciones();
                fillTecnicos();
            }
        }

        protected void fillGrid()
        {
            int success = rarExamen.Base_de_datos.ConsultarAsignaciones(dgAsignaciones);

            if (success > 0)
            {
                Console.WriteLine(success);
            }
        }

        protected void fillReparaciones()
        {
            int success = rarExamen.Base_de_datos.ConsultarReparacionesAsignaciones(ddRepracion);

            if (success > 0)
            {
                Console.WriteLine(success);
            }
        }

        protected void fillTecnicos()
        {
            int success = rarExamen.Base_de_datos.ConsultarTecnicosAsignaciones(ddTecnico);

            if (success > 0)
            {
                Console.WriteLine(success);
            }
        }

        protected void add()
        {
            rarExamen.Asignaciones asignacion = new rarExamen.Asignaciones();
            if (!ddRepracion.SelectedValue.Trim().Equals(string.Empty))
            {
                asignacion.ReparacionID = int.Parse(ddRepracion.SelectedValue.Trim());
            }
            else { return; }
            if (!ddTecnico.SelectedValue.Trim().Equals(string.Empty))
            {
                asignacion.TecnicoID = int.Parse(ddTecnico.SelectedValue.Trim());
            }
            else { return; }
            if (!txtFecha.Text.Trim().Equals(string.Empty))
            {
                asignacion.FechaAsignacion = txtFecha.Text.Trim();
            }
            else { return; }

            if (asignacion.AgregarAsignacion())
            {
                fillGrid();
            }

        }

        protected void delete()
        {
            rarExamen.Asignaciones asignacion = new rarExamen.Asignaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                asignacion.AsignacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (asignacion.BorrarAsignacion())
            {
                fillGrid();
            }
        }

        protected void modificar()
        {
            rarExamen.Asignaciones asignacion = new rarExamen.Asignaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                asignacion.AsignacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }
            if (!ddRepracion.SelectedValue.Trim().Equals(string.Empty))
            {
                asignacion.ReparacionID = int.Parse(ddRepracion.SelectedValue.Trim());
            }
            else { return; }
            if (!ddTecnico.SelectedValue.Trim().Equals(string.Empty))
            {
                asignacion.TecnicoID = int.Parse(ddTecnico.SelectedValue.Trim());
            }
            else { return; }
            if (!txtFecha.Text.Trim().Equals(string.Empty))
            {
                asignacion.FechaAsignacion = txtFecha.Text.Trim();
            }
            else { return; }

            if (asignacion.ModificarAsignacion())
            {
                fillGrid();
            }
        }

        protected void consultar()
        {
            rarExamen.Asignaciones asignacion = new rarExamen.Asignaciones();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                asignacion.AsignacionID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (asignacion.ConsultarAsignacion(dgAsignaciones))
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