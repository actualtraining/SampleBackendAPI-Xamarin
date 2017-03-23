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
    public class KategoriController : ApiController
    {
        // GET: api/Kategori
        public async Task<IEnumerable<Kategori>> Get()
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetAllKategori();
        }

        // GET: api/Kategori/5
        public async Task<Kategori> Get(int id)
        {
            KategoriBL kategoriBL = new KategoriBL();
            return await kategoriBL.GetKategoriByID(id);
        }

        // POST: api/Kategori
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Kategori/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Kategori/5
        public void Delete(int id)
        {
        }
    }
}
