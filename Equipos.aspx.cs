﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGrid();
                fillUsers();
            }

        }

        protected void fillGrid()
        {
            int success = rarExamen.Base_de_datos.ConsultarEquipos(dgEquipos);

            if (success > 0)
            {
                Console.Write(success.ToString());
            }
        }

        protected void fillUsers()
        {
            int success = rarExamen.Base_de_datos.ConsultarUsuariosEquipos(ddUsuario);
        }

        protected void add()
        {
            rarExamen.Equipos equipo = new rarExamen.Equipos();
            if (!txtTipoEquipo.Text.Trim().Equals(string.Empty))
            {
                equipo.TipoEquipo = txtTipoEquipo.Text.Trim();
            }
            else { return; }

            if (!txtModelo.Text.Trim().Equals(string.Empty))
            {
                equipo.Modelo = txtModelo.Text.Trim();
            }
            else { return; }

            if (!ddUsuario.SelectedValue.Trim().Equals(string.Empty))
            {
                equipo.UsuarioID = int.Parse(ddUsuario.SelectedValue.Trim());
            }
            else { return; }

            if (equipo.AgregarEquipo())
            {
                fillGrid();
            }


        }

        protected void delete()
        {
            rarExamen.Usuarios equipo = new rarExamen.Usuarios();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                equipo.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (equipo.borrarUsuario())
            {
                fillGrid();
            }

        }

        protected void modificar()
        {
            rarExamen.Equipos equipo = new rarExamen.Equipos();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                equipo.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }
            if (!txtTipoEquipo.Text.Trim().Equals(string.Empty))
            {
                equipo.TipoEquipo = txtTipoEquipo.Text.Trim();
            }
            else { return; }

            if (!txtModelo.Text.Trim().Equals(string.Empty))
            {
                equipo.Modelo = txtModelo.Text.Trim();
            }
            else { return; }


            equipo.UsuarioID = int.Parse(ddUsuario.SelectedValue);

            if (equipo.ModificarEquipo())
            {
                fillGrid();
            }
        }

        protected void consultar()
        {
            rarExamen.Usuarios equipo = new rarExamen.Usuarios();
            if (!txtId.Text.Trim().Equals(string.Empty))
            {
                equipo.Id = int.Parse(txtId.Text.Trim());
            }
            else { return; }

            if (equipo.consultarUsuario(dgEquipos))
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