using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlVehiculo
    {
        public static int Insertar(TablaVehiculo myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;
                cmd.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = myTabla.marca;
                cmd.Parameters.Add(new SqlParameter("@modelo", SqlDbType.VarChar)).Value = myTabla.modelo;
                cmd.Parameters.Add(new SqlParameter("@placa", SqlDbType.VarChar)).Value = myTabla.placa;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaVehiculo myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@con_cliente", SqlDbType.Int)).Value = myTabla.con_cliente;
                cmd.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = myTabla.marca;
                cmd.Parameters.Add(new SqlParameter("@modelo", SqlDbType.VarChar)).Value = myTabla.modelo;
                cmd.Parameters.Add(new SqlParameter("@placa", SqlDbType.VarChar)).Value = myTabla.placa;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }


        public static ListaVehiculo GetListVehiculoEliminar(int con)
        {
            ListaVehiculo Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Vehiculo_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaVehiculo GetListClienteAll()
        {
            ListaVehiculo Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaVehiculo();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaVehiculo GetListVehiculoConsecutivo(int con)
        {
          
            ListaVehiculo Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaVehiculo();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaVehiculo GetListVehiculoConCliente(int con)
        {
            ListaVehiculo Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Select_porCon_cliente", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_persona", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaVehiculo();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaVehiculo GetListVehiculoConPersona(int con)
        {
            ListaVehiculo Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Vehiculo_Select_porCon_persona", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_persona", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaVehiculo();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaVehiculo FillDataRecord(IDataRecord myDataRecord)
        {
            TablaVehiculo myVehiculo = new TablaVehiculo();
            myVehiculo.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));

            myVehiculo.con_cliente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_cliente"));
            myVehiculo.marca = myDataRecord.GetString(myDataRecord.GetOrdinal("marca"));
            myVehiculo.modelo = myDataRecord.GetString(myDataRecord.GetOrdinal("modelo"));
            myVehiculo.placa = myDataRecord.GetString(myDataRecord.GetOrdinal("placa"));

            return myVehiculo;
        }


    }
}
