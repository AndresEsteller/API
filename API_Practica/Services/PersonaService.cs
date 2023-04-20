using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Services.Sql;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace Services
{
    public static class PersonaService
    {
        public static List<Persona> ListaPersona()
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("Sp_Lista", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);

            List<Persona> lista = new List<Persona>();
            foreach (DataRow fila in data.Tables[0].Rows)
            {
                lista.Add(new Persona()
                {
                    cedula = fila.Field<string>("cedula"),
                    nombre = fila.Field<string>("nombre"),
                    profesion = fila.Field<string>("profesion")
                });
            }
            connection.Close();
            return lista;
        }

        public static List<Persona> BuscarPersona(string cedula)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("Sp_Buscar", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pCedula", cedula);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);

            List<Persona> lista = new List<Persona>();
            foreach (DataRow fila in data.Tables[0].Rows)
            {
                lista.Add(new Persona()
                {
                    cedula = fila.Field<string>("cedula"),
                    nombre = fila.Field<string>("nombre"),
                    profesion = fila.Field<string>("profesion")
                });
            }
            connection.Close();
            return lista;
        }

        public static string AgregarPersona(Persona modelo)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("Sp_Agregar", connection);
                cmd.Parameters.AddWithValue("@pCedula", modelo.cedula);
                cmd.Parameters.AddWithValue("@pNombre", modelo.nombre);
                cmd.Parameters.AddWithValue("@pProfesion", modelo.profesion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                connection.Close();
                return "Persona agregada...";
            }
            catch (Exception)
            {
                return "Error, No se logro agregar...";
                throw;
            }
        }

        public static string ActualizarPersona(Persona modelo, string cedula)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("Sp_Actualizar", connection);
                cmd.Parameters.AddWithValue("@pNombre", modelo.nombre);
                cmd.Parameters.AddWithValue("@pProfesion", modelo.profesion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCedula", cedula);
                cmd.ExecuteNonQuery();

                connection.Close();
                return "Datos actualizados...";
            }
            catch (Exception)
            {
                return "Error, No se logro actualizar...";
                throw;
            }
        }

        public static string EliminarPersona(string cedula)
        {
            try
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("Sp_Eliminar", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pCedula", cedula);
                cmd.ExecuteNonQuery();

                connection.Close();
                return "Persona eliminada...";
            }
            catch (Exception)
            {
                return "Error, No se logro eliminar...";
                throw;
            }
        }
    }
}
