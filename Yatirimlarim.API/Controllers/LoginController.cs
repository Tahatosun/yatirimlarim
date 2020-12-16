using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yatirimlarim.API.Data;
using Yatirimlarim.API.Models;

namespace Yatirimlarim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly YatirimlarimDBContext _context;

        public LoginController(YatirimlarimDBContext context)
        {
            _context = context;
        }

        // POST: api/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Kullanici>> PostKullanici(Login logindata)
        {
            var user= await _context.Kullanicilar
                .Where(u => (u.KullaniciAdi == logindata.Username || u.Eposta == logindata.Username) && u.Sifre == logindata.Password)
                .Select(k => new { k.KullaniciID, k.KullaniciAdi, k.Ad, k.Soyad, k.Telefon, k.Eposta })
                .FirstOrDefaultAsync();
            if (user is null) return NotFound();

            return Ok(user);
        }

        private bool KullaniciExists(int id)
        {
            return _context.Kullanicilar.Any(e => e.KullaniciID == id);
        }
    }
  
}
