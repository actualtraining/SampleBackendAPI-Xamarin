using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BO;
using BL;
using System.Threading.Tasks;

namespace SampleBackendAPI.Controllers
{
    public class BarangController : ApiController
    {
        // GET: api/Barang
        public async Task<IEnumerable<Barang>> Get()
        {
            BarangBL barangBL = new BarangBL();
            var results = await barangBL.GetAllBarang();
            return results;
        }

        // GET: api/Barang/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Barang
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Barang/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Barang/5
        public void Delete(int id)
        {
        }
    }
}
