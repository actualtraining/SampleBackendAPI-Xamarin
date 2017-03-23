using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Configuration;
using BO;
using Dapper;

namespace DAL
{
    public class KategoriDAL : IDisposable
    {
        public string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        //public IEnumerable<Kategori> GetAllKategori()
        //{
        //    using (SqlConnection conn = new SqlConnection(GetConnStr()))
        //    {
        //        List<Kategori> listKategori = new List<Kategori>();
        //        string strSql = @"select * from Kategori order by NamaKategori asc";
        //        SqlCommand cmd = new SqlCommand(strSql, conn);
                
        //        conn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if(dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                listKategori.Add(new Kategori
        //                {
        //                    KategoriID = Convert.ToInt32(dr["KategoriID"]),
        //                    NamaKategori = dr["NamaKategori"].ToString()
        //                });
        //            }
        //        }

        //        dr.Close();
        //        cmd.Dispose();
        //        conn.Close();

        //        return listKategori;
        //    }
        //}

        public async Task<IEnumerable<Kategori>> GetAllKategori()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori order by NamaKategori asc";
                return await conn.QueryAsync<Kategori>(strSql);
            }
        }

        public async Task<Kategori> GetKategoriByID(int kategoriID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori where KategoriID=@KategoriID";
                var param = new { KategoriID = kategoriID };
                return await conn.QuerySingleAsync<Kategori>(strSql, param);
            }
        }

        public async Task InsertKategori(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Kategori(NamaKategori) values(@NamaKategori)";
                var param = new { NamaKategori = kategori.NamaKategori };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error " + sqlEx.Message);
                }
            }
        }

        public async Task UpdateKategori(Kategori kategori)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Kategori set NamaKategori=@NamaKategori where KategoriID=@KategoriID";
                var param = new { NamaKategori = kategori.NamaKategori, KategoriID=kategori.KategoriID };
                try
                {
                    await conn.ExecuteAsync(strSql, param);
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception("Error " + sqlEx.Message);
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
