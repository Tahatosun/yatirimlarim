﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yatirimlarim.API.Data;
using Microsoft.EntityFrameworkCore;

using Yatirimlarim.API.Models;

namespace Yatirimlarim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private YatirimlarimDBContext dbContext;
        public UsersController(YatirimlarimDBContext _dBContext)
        {
            this.dbContext = _dBContext;
        }
       
        // GET api/users
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = await dbContext.Kullanicilar.Select(k => new { k.KullaniciID, k.KullaniciAdi, k.Ad, k.Soyad, k.Telefon, k.Eposta }).ToListAsync();
            return Ok(users);
        }
        // GET api/users/1

        [HttpGet("{id}")]
        public async Task<ActionResult<Kullanici>> GetUser(int id)
        {
            var user = await dbContext.Kullanicilar.Where(u => u.KullaniciID == id).Select(k => new { k.KullaniciID, k.KullaniciAdi, k.Ad, k.Soyad, k.Telefon, k.Eposta }).FirstOrDefaultAsync();
            if (user is null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Kullanici>> Post(Kullanici kullanici)
        {

            var user = new Kullanici
            {
                Ad = kullanici.Ad,
                Soyad = kullanici.Soyad,
                KullaniciAdi = kullanici.KullaniciAdi,
                Sifre = kullanici.Sifre,
                Eposta = kullanici.Eposta,
                Telefon = kullanici.Telefon

            };
            var userCheck = await dbContext.Kullanicilar.FirstOrDefaultAsync(u => u.KullaniciAdi == user.KullaniciAdi || u.Eposta==user.Eposta);

            if(userCheck is null)
            {
                dbContext.Kullanicilar.Add(user);
                await dbContext.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = user.KullaniciID }, new { KullaniciID=user.KullaniciID, KullaniciAdi = user.KullaniciAdi, Ad=user.Ad, Soyad=user.Soyad, Telefon= user.Telefon, Eposta=user.Eposta });
            }
            else
            {
                return Conflict();
            }
         


           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Kullanici kullanici)
        {
            var user = await dbContext.Kullanicilar.FirstOrDefaultAsync(u => u.KullaniciID == id);
            if(user is null)
            {
                return NotFound();
            }
            user.KullaniciAdi = kullanici.KullaniciAdi;
            user.Ad = kullanici.Ad;
            user.Soyad = kullanici.Soyad;
            user.Telefon = kullanici.Telefon;
            user.Sifre = kullanici.Sifre;
            user.Eposta = kullanici.Eposta;
            await  dbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kullanici>> Delete(int id)
        {
            var user = await dbContext.Kullanicilar.FirstOrDefaultAsync(u => u.KullaniciID == id);
            if (user is null)
            {
                return NotFound();
            }

            dbContext.Kullanicilar.Remove(user);
            await  dbContext.SaveChangesAsync();
            return NoContent();

        }
    }
}
