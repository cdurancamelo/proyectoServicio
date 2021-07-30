using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlFactura_Detalle
    {
        public static int Insertar(TablaFactura_Detalle myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
                cmd.Parameters.Add(new SqlParameter("@con_factura", SqlDbType.Int)).Value = myTabla.con_factura;
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = myTabla.cantidad;

                cmd.Parameters.Add(new SqlParameter("@concepto", SqlDbType.VarChar)).Value = myTabla.concepto;

                cmd.Parameters.Add(new SqlParameter("@valor_unitario", SqlDbType.Decimal)).Value = myTabla.valor_unitario;
                //cmd.Parameters.Add(new SqlParameter("@valor_total", SqlDbType.Decimal)).Value = myTabla.valor_total;
                cmd.Parameters.Add(new SqlParameter("@iva", SqlDbType.Decimal)).Value = myTabla.iva;
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaFactura_Detalle myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@con_factura", SqlDbType.Int)).Value = myTabla.con_factura;
                cmd.Parameters.Add(new SqlParameter("@cantidad", SqlDbType.Int)).Value = myTabla.cantidad;

                cmd.Parameters.Add(new SqlParameter("@concepto", SqlDbType.VarChar)).Value = myTabla.concepto;

                cmd.Parameters.Add(new SqlParameter("@valor_unitario", SqlDbType.Decimal)).Value = myTabla.valor_unitario;
                cmd.Parameters.Add(new SqlParameter("@valor_total", SqlDbType.Decimal)).Value = myTabla.valor_total;
                cmd.Parameters.Add(new SqlParameter("@iva", SqlDbType.Decimal)).Value = myTabla.iva;
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaFactura_Detalle GetListFactura_DetalleEliminar(int con)
        {
            ListaFactura_Detalle Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }


        public static ListaFactura_Detalle GetListFactura_DetalleAll()
        {
            ListaFactura_Detalle Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura_Detalle();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaFactura_Detalle GetListFactura_DetalleConsecutivo(int con)
        {
            ListaFactura_Detalle Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura_Detalle();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaFactura_Detalle GetListFactura_DetalleCon_Factura(int con)
        {
            ListaFactura_Detalle Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Factura_Detalle_Select_porCon_factura", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_factura", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaFactura_Detalle();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaFactura_Detalle FillDataRecord(IDataRecord myDataRecord)
        {
            TablaFactura_Detalle myFactura_Detalle = new TablaFactura_Detalle();
            myFactura_Detalle.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));

            myFactura_Detalle.con_factura = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_factura"));
            myFactura_Detalle.cantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("cantidad"));
            myFactura_Detalle.concepto = myDataRecord.GetString(myDataRecord.GetOrdinal("concepto"));
            myFactura_Detalle.valor_unitario = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("valor_unitario"));
            myFactura_Detalle.valor_total = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("valor_total"));
            myFactura_Detalle.iva = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("iva"));

            return myFactura_Detalle;
        }


    }
}
