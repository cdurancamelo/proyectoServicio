using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlFactura
    {
        public static int Insertar(TablaFactura myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;

                cmd.Parameters.Add(new SqlParameter("@con_mecanico", SqlDbType.Int)).Value = myTabla.con_mecanico;

                cmd.Parameters.Add(new SqlParameter("@con_tienda", SqlDbType.Int)).Value = myTabla.con_tienda;

                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = myTabla.fecha;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaFactura myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;

                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;

                cmd.Parameters.Add(new SqlParameter("@con_mecanico", SqlDbType.Int)).Value = myTabla.con_mecanico;

                cmd.Parameters.Add(new SqlParameter("@con_tienda", SqlDbType.Int)).Value = myTabla.con_tienda;

                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = myTabla.fecha;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaFactura GetListFacturaEliminar(int con)
        {
            ListaFactura Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Factura_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaFactura GetListFacturaAll()
        {
            ListaFactura Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaFactura GetListFacturaConsecutivo(int con)
        {
            ListaFactura Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaFactura GetListFacturaconpersonaMecanico(int con)
        {
            ListaFactura Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Select_porConPersonaMecanico", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_mecanico", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaFactura GetListFacturaPorCliente(int con)
        {
            ListaFactura Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Select_porConCliente", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaFactura FillDataRecord(IDataRecord myDataRecord)
        {
            TablaFactura myFactura = new TablaFactura();
            myFactura.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            myFactura.con_cliente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_cliente"));
            myFactura.con_mecanico = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_mecanico"));
            myFactura.con_tienda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_tienda"));
            myFactura.fecha = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("fecha"));
            return myFactura;
        }


    }
}
