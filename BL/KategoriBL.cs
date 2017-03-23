using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class KategoriBL
    {
        public async Task<IEnumerable<Kategori>> GetAllKategori()
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return await kategoriDAL.GetAllKategori();
        }

        public async Task<Kategori> GetKategoriByID(int kategoriID)
        {
            KategoriDAL kategoriDAL = new KategoriDAL();
            return await kategoriDAL.GetKategoriByID(kategoriID);
        }

        public async Task InsertKategori(Kategori kategori)
        {
            try
            {
                KategoriDAL kategoriDAL = new KategoriDAL();
                await kategoriDAL.InsertKategori(kategori);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateKategori(Kategori kategori)
        {
            try
            {
                KategoriDAL kategoriDAL = new KategoriDAL();
                await kategoriDAL.UpdateKategori(kategori);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteKategori(int kategoriID)
        {
            try
            {
                KategoriDAL kategoriDAL = new KategoriDAL();
                await kategoriDAL.DeleteKategori(kategoriID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
