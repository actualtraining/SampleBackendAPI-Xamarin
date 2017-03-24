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
    public class BarangDAL : IDisposable
    {
        public string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public async Task<IEnumerable<Barang>> GetAllBarang()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Barang left join Kategori on 
                                  Barang.KategoriID=Kategori.KategoriID ";

                var results = await conn.QueryAsync<Barang, Kategori, Barang>(strSql, (b, k) =>
                {
                    b.Kategori = k;
                    return b;
                }, splitOn: "KategoriID");

                return results;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
