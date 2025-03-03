﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=E_COMMERCE_REFRI ; integrated security=true");
            comando = new SqlCommand("");
        }
        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear(); // Utilizo este metodo para limpiar el comando
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)
        {
            comando.Parameters.Clear();
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void setearParametroSalida(string nombre, SqlDbType tipo)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.SqlDbType = tipo;
            parametro.Direction = ParameterDirection.Output;
            comando.Parameters.Add(parametro);
        }

        // Metodo para obtener el valor del parametro de salida del sp
        public object obtenerParametroSalida(string nombre)
        {
            return comando.Parameters[nombre].Value;
        }
    }
}
