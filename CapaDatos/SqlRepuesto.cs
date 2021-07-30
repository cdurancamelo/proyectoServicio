using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlRepuesto
    {
        public static int Insertar(TablaRepuesto myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;

                cmd.Parameters.Add(new SqlParameter("@unidad", SqlDbType.Int)).Value = myTabla.unidad;

                cmd.Parameters.Add(new SqlParameter("@precioUnitario", SqlDbType.Decimal)).Value = myTabla.precioUnitario;
                cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal)).Value = myTabla.descuento;

                cmd.Parameters.Add(new SqlParameter("@con_tienda", SqlDbType.Decimal)).Value = myTabla.con_tienda;
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaRepuesto myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;

                cmd.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar)).Value = myTabla.descripcion;

                cmd.Parameters.Add(new SqlParameter("@unidad", SqlDbType.Int)).Value = myTabla.unidad;

                cmd.Parameters.Add(new SqlParameter("@precioUnitario", SqlDbType.Decimal)).Value = myTabla.precioUnitario;
                cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal)).Value = myTabla.descuento;

                cmd.Parameters.Add(new SqlParameter("@con_tienda", SqlDbType.Decimal)).Value = myTabla.con_tienda;
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaRepuesto GetListRepuestoEliminar(int con)
        {
            ListaRepuesto Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Repuesto_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaRepuesto GetListRepuestoAll()
        {
            ListaRepuesto Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Repuesto_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaRepuesto();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaRepuesto GetListRepuestoConsecutivo(int con)
        {
            ListaRepuesto Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Repuesto_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaRepuesto();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaRepuesto GetListRepuestoConTienda(int con)
        {
            ListaRepuesto Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Repuesto_Select_porConTienda", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_tienda", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaRepuesto();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaRepuesto FillDataRecord(IDataRecord myDataRecord)
        {
            TablaRepuesto myRepuesto = new TablaRepuesto();
            myRepuesto.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));

            myRepuesto.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));

            myRepuesto.unidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("unidades"));

            myRepuesto.precioUnitario= myDataRecord.GetDecimal(myDataRecord.GetOrdinal("precioUnitario"));

            myRepuesto.descuento = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("descuento"));

            myRepuesto.con_tienda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_tienda"));

            return myRepuesto;
        }


    }
}
