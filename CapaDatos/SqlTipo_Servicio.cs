using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlTipo_Servicio
    {
        public static int Insertar(TablaTipo_Servicio myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Servicio_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;
                cmd.Parameters.Add(new SqlParameter("@valor_minimo", SqlDbType.Decimal)).Value = myTabla.valor_minimo;
                cmd.Parameters.Add(new SqlParameter("@valor_maximo", SqlDbType.Decimal)).Value = myTabla.valor_maximo;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaTipo_Servicio myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Servicio_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;
                cmd.Parameters.Add(new SqlParameter("@valor_minimo", SqlDbType.Decimal)).Value = myTabla.valor_minimo;
                cmd.Parameters.Add(new SqlParameter("@valor_maximo", SqlDbType.Decimal)).Value = myTabla.valor_maximo;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaTipo_Servicio GetListTipo_ServicioEliminar(int con)
        {
            ListaTipo_Servicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Tipo_Servicio_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaTipo_Servicio GetListTipo_ServicioAll()
        {
            ListaTipo_Servicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Servicio_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaTipo_Servicio();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaTipo_Servicio GetListTipo_ServicioConsecutivo(int con)
        {
            ListaTipo_Servicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tipo_Servicio_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaTipo_Servicio();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }


        private static TablaTipo_Servicio FillDataRecord(IDataRecord myDataRecord)
        {
            TablaTipo_Servicio myTipo_Servicio = new TablaTipo_Servicio();
            myTipo_Servicio.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            myTipo_Servicio.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
            myTipo_Servicio.valor_minimo = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("valor_minimo"));
            myTipo_Servicio.valor_maximo = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("valor_maximo"));

            return myTipo_Servicio;
        }


    }
}
