using CapaEntidades.Tablas;
using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlMecanico
    {
        public static int Insertar(TablaMecanico myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Mecanico_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_persona", SqlDbType.Int)).Value = myTabla.con_persona;
                cmd.Parameters.Add(new SqlParameter("@con_estado", SqlDbType.Int)).Value = myTabla.con_estado;
                

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaMecanico myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Mecanico_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@con_persona", SqlDbType.Int)).Value = myTabla.con_persona;
                cmd.Parameters.Add(new SqlParameter("@con_estado", SqlDbType.Int)).Value = myTabla.con_estado;


                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static ListaMecanico GetListMecanicoEliminar(int con)
        {
            ListaMecanico Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Mecanico_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaMecanico GetListMecanicoAll()
        {
            ListaMecanico Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Mecanico_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaMecanico();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaMecanico GetListMecanicoConsecutivo(int con)
        {
            ListaMecanico Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Mecanico_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaMecanico();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }


        public static ListaMecanico GetListMecanicoConPersona(int con)
        {
            ListaMecanico Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Mecanico_Select_porConpersona", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@con_persona", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaMecanico();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaMecanico FillDataRecord(IDataRecord myDataRecord)
        {
            TablaMecanico myPersona = new TablaMecanico();
            myPersona.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
            myPersona.con_persona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_persona"));
            myPersona.con_estado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_estado"));

           
            return myPersona;
        }


    }
}
