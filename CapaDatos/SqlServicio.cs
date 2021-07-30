using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlServicio
    {
        public static int Insertar(TablaServicio myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Servicio_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
   
                cmd.Parameters.Add(new SqlParameter("@con_tipoServicio", SqlDbType.Int)).Value = myTabla.con_tipoServicio;
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;
                cmd.Parameters.Add(new SqlParameter("@precioManoObra", SqlDbType.Decimal)).Value = myTabla.precioManoObra;
                cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal)).Value = myTabla.descuento;
                cmd.Parameters.Add(new SqlParameter("@con_estado", SqlDbType.Int)).Value = myTabla.con_estado;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaServicio myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Servicio_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@con_tipoServicio", SqlDbType.Int)).Value = myTabla.con_tipoServicio;
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;
                cmd.Parameters.Add(new SqlParameter("@precioManoObra", SqlDbType.Decimal)).Value = myTabla.precioManoObra;
                cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal)).Value = myTabla.descuento;
                cmd.Parameters.Add(new SqlParameter("@con_estado", SqlDbType.Int)).Value = myTabla.con_estado;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaServicio GetListServicioEliminar(int con)
        {
            ListaServicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Servicio_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaServicio GetListServicioAll()
        {
            ListaServicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Servicio_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaServicio();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaServicio GetListServicioConsecutivo(int con)
        {
            ListaServicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Servicio_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaServicio();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaServicio GetListServicioConCliente(int con)
        {
            ListaServicio Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Servicio_Select_porConCliente", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaServicio();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }


        private static TablaServicio FillDataRecord(IDataRecord myDataRecord)
        {
            TablaServicio myServicio = new TablaServicio();
            myServicio.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            myServicio.con_tipoServicio = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_tipoServicio"));
            myServicio.con_cliente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_cliente"));
            myServicio.precioManoObra = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("precioManoObra"));
            myServicio.descuento = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("descuento"));
            myServicio.con_estado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_estado"));
            return myServicio;
        }


    }
}
