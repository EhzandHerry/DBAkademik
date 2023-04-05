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
        public void UpdateData(string nama, int id, string jurusan, string jeniskelamin, int notelp, string alamat)
        {
            
            string connectionString = "Data Source=LAPTOP-G2F55ONU\\EHZANDHERRY;Initial Catalog=LAPTOP-G2F55ONU\\EHZANDHERRY;User ID=sa;Password=Conex999";
            SqlConnection connection = new SqlConnection(connectionString);

            
            string sql = "UPDATE mahasiswa SET id_mhs = id_mhs, nama_mhs = @nama_mhs, id_jurusan = @id_jurusan, jenis_kelamin = @jeniskelamin, alamat = @alamat WHERE id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

           
            command.Parameters.AddWithValue("@id_mhs", id);
            command.Parameters.AddWithValue("@nama_mhs", nama);
            command.Parameters.AddWithValue("@id_jurusan", jurusan);
            command.Parameters.AddWithValue("@jenis_kelamin", jeniskelamin);
            command.Parameters.AddWithValue("@no_telp", notelp);
            command.Parameters.AddWithValue("@alamat", alamat);

            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteData(int id)
        {
            
            string connectionString = "Data Source=LAPTOP-G2F55ONU\\EHZANDHERRY;Initial Catalog=LAPTOP-G2F55ONU\\EHZANDHERRY;User ID=sa;Password=Conex999";
            SqlConnection connection = new SqlConnection(connectionString);

            
            string sql = "DELETE FROM mahasiswa WHERE id = @id";
            SqlCommand command = new SqlCommand(sql, connection);

            
            command.Parameters.AddWithValue("@id", id);

            
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }
        public void SearchData(string keyword)
        {
            // buat objek koneksi ke database
            string connectionString = "Data Source=LAPTOP-G2F55ONU\\EHZANDHERRY;Initial Catalog=LAPTOP-G2F55ONU\\EHZANDHERRY;User ID=sa;Password=Conex999";
            SqlConnection connection = new SqlConnection(connectionString);

            // buat perintah SQL SELECT
            string sql = "SELECT * FROM mahasiswa WHERE nama LIKE '%' + @keyword + '%'";
            SqlCommand command = new SqlCommand(sql, connection);

            // tambahkan parameter ke perintah SQL
            command.Parameters.AddWithValue("@keyword", keyword);

            // jalankan perintah SQL SELECT
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            // baca data dari objek SqlDataReader dan tampilkan hasil pencarian pada antarmuka pengguna
            while (reader.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader["id"], reader["nama"], reader["usia"], reader["jurusan"], reader["alamat"]);
            }

            reader.Close();
            connection.Close();
        }
    }
}
