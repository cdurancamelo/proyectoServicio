using System;
using System.Data;
using System.Data.SqlClient;



namespace CapaDatos
{
    public class SqlPersona
    {
        public static int Insertar(TablaPersona myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Insert", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
               
               
                cmd.Parameters.Add(new SqlParameter("@primerNombre", SqlDbType.VarChar)).Value = myTabla.pri_nombre;
                if (myTabla.seg_nombre == null)
                    cmd.Parameters.Add(new SqlParameter("@segundoNombre", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@segundoNombre", SqlDbType.VarChar)).Value = myTabla.seg_nombre;
                cmd.Parameters.Add(new SqlParameter("@primerApellido", SqlDbType.VarChar)).Value = myTabla.pri_apellido;
                if (myTabla.seg_apellido == null)
                    cmd.Parameters.Add(new SqlParameter("@segundoApellido", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@segundoApellido", SqlDbType.VarChar)).Value = myTabla.seg_apellido;

                cmd.Parameters.Add(new SqlParameter("@con_tipoDocumento", SqlDbType.Int)).Value = myTabla.con_tipoDocumento;

                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value = myTabla.documento;
                if (myTabla.celular == null)
                    cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = myTabla.celular;

                cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar)).Value = myTabla.direccion;

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", SqlDbType.VarChar)).Value = myTabla.correoElectronico;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        public static int Actualizar(TablaPersona myTabla)
        {
            int result = 0;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Update", conectando);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = myTabla.consecutivo;
                cmd.Parameters.Add(new SqlParameter("@primerNombre", SqlDbType.VarChar)).Value = myTabla.pri_nombre;
                if (myTabla.seg_nombre == null)
                    cmd.Parameters.Add(new SqlParameter("@segundoNombre", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@segundoNombre", SqlDbType.VarChar)).Value = myTabla.seg_nombre;
                cmd.Parameters.Add(new SqlParameter("@primerApellido", SqlDbType.VarChar)).Value = myTabla.pri_apellido;
                if (myTabla.seg_apellido == null)
                    cmd.Parameters.Add(new SqlParameter("@segundoApellido", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@segundoApellido", SqlDbType.VarChar)).Value = myTabla.seg_apellido;

                cmd.Parameters.Add(new SqlParameter("@con_tipoDocumento", SqlDbType.Int)).Value = myTabla.con_tipoDocumento;

                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value = myTabla.documento;
                if (myTabla.celular == null)
                    cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(new SqlParameter("@celular", SqlDbType.VarChar)).Value = myTabla.celular;

                cmd.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar)).Value = myTabla.direccion;

                cmd.Parameters.Add(new SqlParameter("@correoElectronico", SqlDbType.VarChar)).Value = myTabla.correoElectronico;

                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return result;
        }


        public static ListaPersona GetListPersonaEliminar(int con)
        {
            ListaPersona Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                int result = 0;
                SqlCommand cmd = new SqlCommand("Persona_Delete", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                conectando.Open();
                result = cmd.ExecuteNonQuery();
            }
            return Templist;
        }

        public static ListaPersona GetListPersonaAll()
        {
            ListaPersona Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Select_All", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaPersona();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaPersona GetListPersonaConsecutivo(int con)
        {
            ListaPersona Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Select_porConsecutivo", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@consecutivo", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaPersona();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaPersona GetListPersonaConDocumento(string con)
        {
            ListaPersona Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Select_pordocumento", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.VarChar)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaPersona();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        public static ListaPersona GetListPersonaConPersona(int con)
        {
            ListaPersona Templist = null;
            Conexion.Conexion Con = new Conexion.Conexion();
            using (SqlConnection conectando = new SqlConnection(Con.Cadena))
            {
                SqlCommand cmd = new SqlCommand("Persona_Select_pordocumento", conectando);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@documento", SqlDbType.Int)).Value = con;
                conectando.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Templist = new ListaPersona();
                    while (dr.Read())
                        Templist.Add(FillDataRecord(dr));
                }
                dr.Close();
            }
            return Templist;
        }

        private static TablaPersona FillDataRecord(IDataRecord myDataRecord)
        {
            TablaPersona myPersona = new TablaPersona();
            myPersona.consecutivo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("consecutivo"));
           
           
            myPersona.pri_nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("primerNombre"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("segundoNombre")))
                myPersona.seg_nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("segundoNombre"));
            else
                myPersona.seg_nombre = " ";
            myPersona.pri_apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("primerApellido"));
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("segundoApellido")))
                myPersona.seg_apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("segundoApellido"));
            else
                myPersona.seg_apellido = " ";

            myPersona.con_tipoDocumento = myDataRecord.GetInt32(myDataRecord.GetOrdinal("con_tipoDocumento"));
            myPersona.documento = myDataRecord.GetString(myDataRecord.GetOrdinal("documento"));
            myPersona.celular = myDataRecord.GetString(myDataRecord.GetOrdinal("celular"));
            myPersona.direccion = myDataRecord.GetString(myDataRecord.GetOrdinal("direccion"));
            myPersona.correoElectronico = myDataRecord.GetString(myDataRecord.GetOrdinal("correoElectronico"));
            return myPersona;
        }


    }
}
