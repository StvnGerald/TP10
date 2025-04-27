using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tpmodul10_103022300155;

namespace tpmodul10_103022300155.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Steven Gerald", Nim = "103022300155" },
            new Mahasiswa { Nama = "Fadhli Rabbi", Nim = "103022300055" },
            new Mahasiswa { Nama = "I Gede Agung Peramerta", Nim = "103022300087" }
        };

        // GET: api/Mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return Ok(daftarMahasiswa);
        }

        // GET: api/Mahasiswa/{id}
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetById(int id)
        {
            if (id < 0 || id >= daftarMahasiswa.Count)
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });

            return Ok(daftarMahasiswa[id]);
        }

        // POST
        [HttpPost]
        public ActionResult<IEnumerable<Mahasiswa>> Post([FromBody] Mahasiswa mhs)
        {
            if (mhs == null)
                return BadRequest(new { message = "Data mahasiswa tidak valid." });

            daftarMahasiswa.Add(mhs);
            return Ok(daftarMahasiswa);
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Mahasiswa>> Delete(int id)
        {
            if (id < 0 || id >= daftarMahasiswa.Count)
                return NotFound(new { message = "Mahasiswa tidak ditemukan." });

            daftarMahasiswa.RemoveAt(id);
            return Ok(daftarMahasiswa);
        }
    }
}
