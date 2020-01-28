using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySql.Data.MySqlClient;
using ogrencibilgileri.Modullers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ogrencibilgileri.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IConfiguration _configuration;
        private string constr;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
            constr = _configuration.GetConnectionString("ogrencidbconstr");

        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Ogrenci>> Get()
        {
            IEnumerable<Ogrenci>Ogrencis = new List<Ogrenci>();
            using (var con = new MySqlConnection(constr))
            {
                con.Open();
                Ogrencis = con.Query<Ogrenci>("Select * from ogrenci order by ad");

            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]




        // POST api/<controller>
        [HttpPost]


        public IActionResult Post([FromBody] Ogrenci payload)
        {
            try
            {
                using (var con = new MySqlConnection(constr))
                {
                    con.Open();
                    con.Execute(@"INSERT INTO ogrenci (tc,ad,soyad,dtarih,cinsiyet) VALUES (@tc,@ad,@soyad,@dtarih,@cinsiyet)", payload);
                    return Ok(payload);
                }
            }
            catch (MySqlException excp)
            {
                return BadRequest(excp.Message);
            }
        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Ogrenci payload)
        {
            try
            {
                using (var conn = new MySqlConnection(constr))
                {
                    conn.Open();
                    var result = conn.Execute(@"UPDATE ogrenci SET ad=@ad ,soyad=@soyad,dtarih=@dtarih,cinsiyet=@cinsiyet WHERE tc=@tc",
                        new
                        {
                            tc = payload.Tc,
                            ad = payload.Ad,
                            soyad = payload.Soyad,
                            dtarih = payload.Dtarih,
                            cinsiyet = payload.Cinsiyet
                        });
                    if (result == 1)
                        return Ok(payload);
                    else
                        return NotFound();
                }
            }
            catch (MySqlException excp)
            {
                return BadRequest(excp);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int tc)
        {
            using (var con = new MySqlConnection(constr))
            {
                con.Open();
                var result = con.Execute(@"DELETE FROM ogrenci WHERE tc=@tc", new {Tc = tc });
                if (result == 1)
                    return Ok();
                else
                    return NotFound();
            }
        }
    }
}
