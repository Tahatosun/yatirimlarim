using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yatirimlarim.API.Data;
using Yatirimlarim.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yatirimlarim.API.Controllers
{
    [Route("api/users/{userid}/[controller]")]
    [ApiController]
    public class InvestmentsController : ControllerBase
    {
        private YatirimlarimDBContext dbContext;
        public InvestmentsController(YatirimlarimDBContext _dBContext)
        {
            this.dbContext = _dBContext;
        }
        // GET: api/<InvestmentsController>
        [HttpGet]
        public  ActionResult GetInvestments(int userid)
        {
            var investments =  dbContext.Yatirimlar.Where(y=>y.KullaniciID==userid);
            return Ok(investments);
        }

        // GET api/<InvestmentsController>/5
        [HttpGet("{yatirimid}")]
        public ActionResult GetInvestment(int userid,int yatirimId)
        {
            var investment = dbContext.Yatirimlar.FirstOrDefault(i => i.YatirimID == yatirimId && i.KullaniciID == userid);
            if (investment is null) return NotFound();

            return Ok(investment);
        }

        // POST api/<InvestmentsController>
        [HttpPost]
        public ActionResult Post(int userId,Yatirim yatirim)
        {
            var investment = new Yatirim
            {
                KullaniciID = userId,
                UrunAdet = yatirim.UrunAdet,
                UrunID = yatirim.UrunID,
                YatirimTarihi = yatirim.YatirimTarihi,
                YatirimMaliyeti=yatirim.YatirimMaliyeti
            };
            dbContext.Yatirimlar.Add(investment);
            dbContext.SaveChanges();
            return CreatedAtAction("GetInvestment", new { userid = userId, yatirimid = investment.YatirimID }, investment);
        }

        // PUT api/<InvestmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int yatirimId,int userId,Yatirim yatirim)
        {
            var user = dbContext.Kullanicilar.FirstOrDefault(u => u.KullaniciID == userId);
            if (user is null) return NotFound();

            var investment = dbContext.Yatirimlar.FirstOrDefault(i => i.YatirimID == yatirimId);
            if (investment is null) return NotFound();

            investment.UrunID = yatirim.UrunID;
            investment.YatirimTarihi = yatirim.YatirimTarihi;
            investment.UrunAdet = yatirim.UrunAdet;
            dbContext.SaveChanges();

            return NoContent();


        }

        // DELETE api/<InvestmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int userId, int yatirimId)
        {
            var investment = dbContext.Yatirimlar.Where(p => p.KullaniciID == userId && p.YatirimID == yatirimId);
            if (investment is null) return NotFound();

            return Ok();

        }
    }
}
