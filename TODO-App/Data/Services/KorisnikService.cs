using TODO_App.Data.Models;
using TODO_App.Data.ViewModels;

namespace TODO_App.Data.Services
{
    public class KorisnikService
    {
        private AppDbContext _context;

        public KorisnikService(AppDbContext context)
        {
            _context = context;
        }

        public void DodajKorisnika(KorisnikVM korisnik)
        {
            var _korisnik = new Korisnik()
            {
                ImePrezime = korisnik.ImePrezime
            };
            _context.Korisnici.Add(_korisnik);
            _context.SaveChanges();
        }
        public List<Korisnik> DohvatiKorisnike() => _context.Korisnici.ToList();
        public Korisnik DohvatiKorisnikaById(int korisnikId) => _context.Korisnici.FirstOrDefault(k => k.Id == korisnikId);
    }
}
