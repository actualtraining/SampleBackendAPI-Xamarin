using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using DAL;

namespace BL
{
    public class BarangBL
    {
        public async Task<IEnumerable<Barang>> GetAllBarang()
        {
            BarangDAL barangDal = new BarangDAL();
            return await barangDal.GetAllBarang();
        }
    }
}
