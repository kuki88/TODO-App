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
    public class ZadatakController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ZadatakService _zadatakService;

        public ZadatakController(ZadatakService zadatakService, AppDbContext context)
        {
            _zadatakService = zadatakService;
            _context = context;
        }
        [HttpPost("dodaj-zadatak")]
        public IActionResult DodajZadatak([FromBody]ZadatakVM zadatak)
        {
            try
            { 
                var noviZadatak = _zadatakService.DodajZadatak(zadatak);
                return Created(nameof(DodajZadatak), noviZadatak);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("dohvati-zadatke")]
        public IActionResult DohvatiZadatke()
        {
            var sviZadaci = _zadatakService.DohvatiZadatak();
            return Ok(sviZadaci);
        }
        [HttpGet("dohvati-zadatke-by-id/{id}")]
        public IActionResult DohvatiZadatakById(int id)
        {
            var zadatak = _zadatakService.DohvatiZadatakById(id);
            return Ok(zadatak);
        }
        [HttpGet("dohvati-zadatke-by-status/{status}")]
        public IActionResult DohvatiZadatkePoStatusu(bool status)
        {
            try
            {
                var zadaci = _zadatakService.DohvatiZadatkePoStatusu(status);
                return Ok(zadaci);
            }
            catch (Exception ex)
            {

            }
        }
        [HttpGet("dohvati-zadatke-by-korisnik/{id}")]
        public IActionResult DohvatiZadatkePoKorisniku(int? id)
        {
            try
            {
                var zadaci = _zadatakService.DohvatiZadatkePoKorisniku(id);
                return Ok(zadaci);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-zadatak-by-id/{id}")]
        public IActionResult UpdateZadatakById(int id, [FromBody]ZadatakVM zadatak)
        {
            var updateZadatak = _zadatakService.UpdateZadatakById(id, zadatak);
            return Ok(updateZadatak);
        }
        [HttpDelete("izbrisi-zadatak-by-id/{id}")]
        public IActionResult IzbrisiZadatakById(int id)
        {
            try
            {
                _zadatakService.IzbrisiZadatakById(id);
                return Ok(_zadatakService);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
