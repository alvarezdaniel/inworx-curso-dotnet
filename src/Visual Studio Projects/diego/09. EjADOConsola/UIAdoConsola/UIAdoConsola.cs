using System;
using System.Data;
using System.Data.SqlClient;

namespace UIAdoConsola
{
    /// <summary>
    /// Summary description for UIAdoConsola.
    /// </summary>
    class UIAdoConsola
    {
        public void ImprimirDesconectado()
        {
            SqlConnection con;
            SqlDataAdapter da;
            DataSet ds;
            try
            {
                con = new SqlConnection("server=localhost; database=pubs; User ID=sa; Password=inworx");
                da = new SqlDataAdapter("select * From Authors", con);
                ds = new DataSet();

                da.Fill(ds);
                Console.WriteLine("Desconectado:");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Console.WriteLine(dr["au_lname"].ToString());
                }
                Console.WriteLine("");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        public void ImprimirConectado()
        {
            SqlConnection con;
            SqlCommand co;
            SqlDataReader dr;
            try
            {
                con = new SqlConnection("server=localhost; database=pubs; User ID=sa; Password=inworx");
                co = new SqlCommand("select * From Authors", con);
                int i = 0;
                con.Open();
                dr = co.ExecuteReader();
                i = dr.GetOrdinal("au_lname");
                Console.WriteLine("Conectado:");
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(i));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //
            // TODO: Add code to start application here
            //
            UIAdoConsola ac = new UIAdoConsola();
            ac.ImprimirDesconectado();
            ac.ImprimirConectado();
        }
    }
}
