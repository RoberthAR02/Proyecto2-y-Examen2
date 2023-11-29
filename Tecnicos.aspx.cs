using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Tecnicos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        protected void fillGrid()
        {
            int success = rarExamen.Base_de_datos.ConsultarTecnicos(dgTecnicos);

            if (success > 0)
            {
                Console.Write(success.ToString());
            }
        }

        protected void add()
        {
            rarExamen.Tecnicos tecnico = new rarExamen.Tecnicos();
            if (!txtNombre.Text.Trim().Equals(string.Empty))
            {
                tecnico.Nombre = txtNombre.Text.Trim();
            }
            else { return; }

            if (!txtEspecialidad.Text.Trim().Equals(string.Empty))
            {
                tecnico.Especialidad = txtEspecialidad.Text.Trim();
            }
            else { return; }

            if (tecnico.agregarTecnico())
            {
                fillGrid();
            }


        }

        protected void delete()
        {
            rarExamen.Tecnicos tecnico = new rarExamen.Tecnicos();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                tecnico.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (tecnico.borrarTecnico())
            {
                fillGrid();
            }

        }

        protected void modificar()
        {
            rarExamen.Tecnicos tecnico = new rarExamen.Tecnicos();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                tecnico.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }
            if (!txtNombre.Text.Trim().Equals(string.Empty))
            {
                tecnico.Nombre = txtNombre.Text.Trim();
            }
            else { return; }

            if (!txtEspecialidad.Text.Trim().Equals(string.Empty))
            {
                tecnico.Especialidad = txtEspecialidad.Text.Trim();
            }
            else { return; }

            if (tecnico.modificarTecnico())
            {
                fillGrid();
            }
        }

        protected void consultar()
        {
            rarExamen.Tecnicos tecnico = new rarExamen.Tecnicos();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                tecnico.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (tecnico.consultarTecnico(dgTecnicos))
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