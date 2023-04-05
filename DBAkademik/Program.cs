using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAkademik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().koneksi();
        }
        public void koneksi()
        {
            using (
                //membuat koneksi
                SqlConnection conn = new SqlConnection("data source=LAPTOP-G2F55ONU\\EHZANDHERRY;user ID=sa;password=Conex999"
                ))
            {
                conn.Open();
                Console.Write("Koneksi Ke Data Base");
                Console.Read();
            }
        }
        
    }
}
