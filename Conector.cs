﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace rarExamen
{
    public class Conector
    {
        public static SqlConnection getConnection()
        {
            string conexion = ConfigurationManager.ConnectionStrings["cnx1"].ConnectionString;
            SqlConnection cnx = new SqlConnection(conexion);
            cnx.Open();

            return cnx;
        }

        public static void closeConnection(SqlConnection cnx)
        {
            cnx.Close();
        }
    }
}