using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SubirArchivos
{
    public class Conexion
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        

        public DataSet FunConsultarId(string nombre, string conexion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = con;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "sp_ConsultaDatos";
                        comm.Parameters.AddWithValue("@in_codigo", 0);
                        comm.Parameters.AddWithValue("@in_tCodigo", nombre);
                        comm.Parameters.AddWithValue("@in_tipo", 171);
                        con.Open();
                        da.SelectCommand = comm;
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return ds = null;
            }
        }

        public string InsertPersona(string cedula,string nombre1,string nombre2,string apellido1,string apellido2,
            string genero,string direccion,string nacimiento,string telcasa,string telofi,string celular,
            string email,string tipocliente,string parentesco,string fechainico,string fechafinco,string tipopolisa,int codpro,string conexion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = con;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "sp_InsertarPersonaTitular";
                        comm.Parameters.AddWithValue("@in_tipo", 0);
                        comm.Parameters.AddWithValue("@in_cedula", cedula);
                        comm.Parameters.AddWithValue("@in_nombre1", nombre1);
                        comm.Parameters.AddWithValue("@in_nombre2", nombre2);
                        comm.Parameters.AddWithValue("@in_apellido1", apellido1);
                        comm.Parameters.AddWithValue("@in_apellido2", apellido2);
                        comm.Parameters.AddWithValue("@in_genero", genero);
                        comm.Parameters.AddWithValue("@in_direccion", direccion);
                        comm.Parameters.AddWithValue("@in_nacimiento", nacimiento);
                        comm.Parameters.AddWithValue("@in_telcasa", telcasa);
                        comm.Parameters.AddWithValue("@in_telofi", telofi);
                        comm.Parameters.AddWithValue("@in_celular", celular);
                        comm.Parameters.AddWithValue("@in_email", email);
                        comm.Parameters.AddWithValue("@in_tipocliente", tipocliente);
                        comm.Parameters.AddWithValue("@in_parentesco", parentesco);
                        comm.Parameters.AddWithValue("@in_fechainico", fechainico);
                        comm.Parameters.AddWithValue("@in_fechafinco", fechafinco);
                        comm.Parameters.AddWithValue("@in_tipopolisa", tipopolisa);
                        comm.Parameters.AddWithValue("@in_codpro", codpro);
                        con.Open();
                        da.SelectCommand = comm;
                        da.Fill(ds);
                    }
                }
                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public string FunDesactivarTitulares(string conexion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = con;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "sp_ConsultaDatos";
                        comm.Parameters.AddWithValue("@in_codigo", 0);
                        comm.Parameters.AddWithValue("@in_tCodigo", "");
                        comm.Parameters.AddWithValue("@in_tipo", 177);
                        
                        con.Open();
                        da.SelectCommand = comm;
                        da.Fill(ds);
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public DataSet FunEstadoTitulares(string conexion)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = con;
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "sp_ConsultaDatos";
                        comm.Parameters.AddWithValue("@in_codigo", 0);
                        comm.Parameters.AddWithValue("@in_tCodigo", "");
                        comm.Parameters.AddWithValue("@in_tipo", 179);

                        con.Open();
                        da.SelectCommand = comm;
                        da.Fill(ds);
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
