using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace rarExamen
{
    public partial class Base_de_datos
    {
        public static int ConsultarDetallesDeReparacion(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_DETALLESREPARACION", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarReparacionesDetallesDeReparacion(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["ReparacionID"].ToString();
                                dg.DataValueField = dt.Columns["ReparacionID"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        public static int ConsultarDetallesDeReparacionPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_DETALLESREPARACION_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int BorrarDetallesDeReparacionPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_DETALLESREPARACION_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarDetalleDeReparacion(int reparacionId, string descripcion)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_DETALLESREPARACION", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionId));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarDetallesDeReparacionPorId(int id, int reparacionId, string descripcion, string fechaFin)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_DETALLESREPARACION_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionId));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechaFin));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        /************************** Asignaciones ********************/
        public static int ConsultarAsignaciones(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_ASIGNACIONES", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarReparacionesAsignaciones(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["ReparacionID"].ToString();
                                dg.DataValueField = dt.Columns["ReparacionID"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarTecnicosAsignaciones(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_TECNICOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["Nombre"].ToString();
                                dg.DataValueField = dt.Columns["TecnicoID"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        public static int ConsultarAsignacionesPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_ASIGNACIONES_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int borrarAsignacionesPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_ASIGNACIONES_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarAsignacion(int reparacionId, int tecnicoId)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_ASIGNACION", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionId));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoId));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarAsignacionPorId(int id, int reparacionId, int tecnicoId)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_ASIGNACION_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionId));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoId));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        /************************** Reparaciones ********************/
        public static int ConsultarReparaciones(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarEquiposReparaciones(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_EQUIPOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["TipoEquipo"].ToString();
                                dg.DataValueField = dt.Columns["EquipoID"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        public static int ConsultarReparacionesPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_REPARACIONES_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int BorrarReparacionesPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_REPARACIONES_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarReparacion(int equipId, char estado)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_REPARACION", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipId));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarReparacionPorId(int id, int equipId, char estado)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EQUIPO_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipId));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        /************************** Equipos ********************/
        public static int ConsultarEquipos(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_EQUIPOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarUsuariosEquipos(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_USUARIOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["Nombre"].ToString();
                                dg.DataValueField = dt.Columns["UsuarioID"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
        public static int ConsultarEquiposPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_EQUIPOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int BorrarEquiposPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_EQUIPOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarEquipo(string tipo, string modelo, int usuario)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_EQUIPO", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuario));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarEquipoPorId(int id, string tipo, string modelo, int usuario)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EQUIPO_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@USUARIOID", usuario));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        /************************** Tecnicos ********************/
        public static int ConsultarTecnicos(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_TECNICOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarTecnicosPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_TECNICOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int BorrarTecnicosPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_TECNICOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarTecnico(string nombre, string especialidad)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_TECNICO", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarTecnicoPorId(int id, string nombre, string especialidad)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_TECNICO_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        /*************** Usuarios ***************/
        public static int ConsultarUsuarios(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_USUARIOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarUsuariosPorId(int id, GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_USUARIOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        cmd.Parameters.Add(new SqlParameter("@ID", id));
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int BorrarUsuariosPorId(int id)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_USUARIOS_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int InsertarUsuario(string nombre, string correo, string telefono)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }

        public static int ActualizarUsuarioPorId(int id, string nombre, string correo, string telefono)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Conector.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_USUARIO_ID", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", id));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Conector.closeConnection(cnx);
            }

            return ret;
        }
    }
}