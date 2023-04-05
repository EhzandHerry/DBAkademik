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
        public void InsertData(string nama, int id, string jurusan, string jeniskelamin, int notelp, string alamat)
        {
            
            string connectionString = "Data Source=LAPTOP-G2F55ONU\\EHZANDHERRY;Initial Catalog=LAPTOP-G2F55ONU\\EHZANDHERRY;User ID=sa;Password=Conex999";
            SqlConnection connection = new SqlConnection(connectionString);

            
            string sql = "INSERT INTO mahasiswa (id_mhs, nama_mhs, id_jurusan, jenis_kelamin, no_telepon, alamat) VALUES (@id_mhs, @nama_mhs, @jurusan, @jenis_kelamin, @notelp, @alamat)";
            SqlCommand command = new SqlCommand(sql, connection);

            
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@nama", nama);
            command.Parameters.AddWithValue("@jurusan", jurusan);
            command.Parameters.AddWithValue("@jenis kelamin", jeniskelamin);
            command.Parameters.AddWithValue("@no telpon", notelp);
            command.Parameters.AddWithValue("@alamat", alamat);

            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
