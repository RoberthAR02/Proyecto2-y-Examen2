using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class DetallesDeReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
                fillReparaciones();
            }
        }
        protected void clearTxts()
        {
            txtId.Text = string.Empty;
            txtId.Focus();
            txtDescripcion.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
        }

        protected void fillGrid()
        {
            int success = rarExamen.Base_de_datos.ConsultarDetallesDeReparacion(dgDetalles);

            if (success > 0)
            {
                Console.WriteLine(success.ToString());

            }

            clearTxts();
        }

        protected void fillReparaciones()
        {
            int success = rarExamen.Base_de_datos.ConsultarReparacionesDetallesDeReparacion(ddRepracion);

            if (success > 0)
            {
                Console.WriteLine(success.ToString());
            }
        }

        protected void add()
        {
            rarExamen.DetallesDeReparacion detalle = new rarExamen.DetallesDeReparacion();
            if (!ddRepracion.SelectedValue.Trim().Equals(string.Empty))
            {
                detalle.ReparacionID = int.Parse(ddRepracion.SelectedValue.Trim());
            }
            else { return; }
            if (!txtDescripcion.Text.Trim().Equals(string.Empty))
            {
                detalle.Descripcion = txtDescripcion.Text.Trim();
            }
            else { return; }

            if (detalle.AgregarDetallesDeReparacion())
            {
                fillGrid();
            }
        }

        protected void delete()
        {
            rarExamen.DetallesDeReparacion detalle = new rarExamen.DetallesDeReparacion();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                detalle.DetalleID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (detalle.BorrarDetallesDeReparacion())
            {
                fillGrid();
            }
        }

        protected void modificar()
        {
            rarExamen.DetallesDeReparacion detalle = new rarExamen.DetallesDeReparacion();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                detalle.DetalleID = int.Parse(txtId.Text.Trim());
            }
            else { return; }
            if (!ddRepracion.SelectedValue.Trim().Equals(string.Empty))
            {
                detalle.ReparacionID = int.Parse(ddRepracion.SelectedValue.Trim());
            }
            else { return; }
            if (!txtDescripcion.Text.Trim().Equals(string.Empty))
            {
                detalle.Descripcion = txtDescripcion.Text.Trim();
            }
            else { return; }
            if (!txtFechaFin.Text.Trim().Equals(string.Empty))
            {
                detalle.FechaFin = txtFechaFin.Text.Trim();
            }

            if (detalle.ModificarDetallesDeReparacion())
            {
                fillGrid();
            }
        }

        protected void consultar()
        {
            rarExamen.DetallesDeReparacion detalle = new rarExamen.DetallesDeReparacion();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                detalle.DetalleID = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (detalle.ConsultarDetallesDeReparacion(dgDetalles))
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

        protected void dgDetalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueID = dgDetalles.Rows[dgDetalles.SelectedIndex].Cells[1].Text.ToString();
            string valueReparacion = dgDetalles.Rows[dgDetalles.SelectedIndex].Cells[2].Text.ToString();
            string valueDescripcion = dgDetalles.Rows[dgDetalles.SelectedIndex].Cells[3].Text.ToString();

            txtId.Text = valueID;
            ddRepracion.SelectedValue = valueReparacion;
            txtDescripcion.Text = valueDescripcion;
        }
    }
}