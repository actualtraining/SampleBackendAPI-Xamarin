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

        public IEnumerable<Kategori> GetAllKategori()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori order by NamaKategori asc";
                return conn.Query<Kategori>(strSql);
            }
        }

        public Kategori GetKategoriByID(int kategoriID)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Kategori where KategoriID=@KategoriID";
                var param = new { KategoriID = kategoriID };
                return conn.QuerySingle<Kategori>(strSql, param);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
