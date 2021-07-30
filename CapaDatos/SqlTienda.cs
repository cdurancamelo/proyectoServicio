using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlTienda
    {
      

        public static ListaTienda GetListTiendaAll()
        {
            ListaTienda Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tienda_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaTienda();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaTienda GetListTiendaConsecutivo(int con)
        {
            ListaTienda Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Tienda_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaTienda();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaTienda FillDataRecord(IDataRecord myDataRecord)
        {
            TablaTienda myTienda = new TablaTienda();
            myTienda.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            myTienda.nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("nombre"));

           
            return myTienda;
        }


    }
}
