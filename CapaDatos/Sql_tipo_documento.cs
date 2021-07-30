using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class Sql_tipo_documento
    {
        public static int Insertar(Tabla_tipo_documento myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Documento_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(Tabla_tipo_documento myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Documento_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static Lista_tipo_documento GetList_tipo_documentoEliminar(int con)
        {
            Lista_tipo_documento Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Tipo_Documento_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static Lista_tipo_documento GetList_tipo_documentoAll()
        {
            Lista_tipo_documento Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Documento_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new Lista_tipo_documento();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static Lista_tipo_documento GetList_tipo_documentoPorConsecutivo(int con)
        {
            Lista_tipo_documento Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Documento_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new Lista_tipo_documento();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static Tabla_tipo_documento FillDataRecord(IDataRecord myDataRecord)
        {
            Tabla_tipo_documento my_tipo_documento = new Tabla_tipo_documento();
            my_tipo_documento.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            my_tipo_documento.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("my_tipo_documento"));
            
            return my_tipo_documento;
        }


    }
}
