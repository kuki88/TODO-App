using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO_App.Data;
using TODO_App.Data.Models;
using TODO_App.Data.Services;
using TODO_App.Data.ViewModels;

namespace TODO_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly AppDbContext _context;
        public KorisnikService _korisnikService;


        public KorisnikController(AppDbContext context, KorisnikService korisnik)
        {
            _korisnikService = korisnik;
            _context = context;
        }

        [HttpPost("dodaj-korisnika")]
        public IActionResult DodajKorisnika([FromBody]KorisnikVM korisnik)
        {
            _korisnikService.DodajKorisnika(korisnik);
            return Ok();
        }

        [HttpGet("dohvati-korisnike")]
        public IActionResult DohvatiKorisnike()
        {
            var sviKorisnici = _korisnikService.DohvatiKorisnike();
            return Ok(sviKorisnici);
        }

        [HttpGet("dohvati-korisnike-by-id/{id}")]
        public IActionResult DohvatiKorisnike(int id)
        {
            var korisnik = _korisnikService.DohvatiKorisnikaById(id);
            return Ok(korisnik);
        }
    }
}
