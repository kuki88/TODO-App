using TODO_App.Data.Models;
using TODO_App.Data.ViewModels;

namespace TODO_App.Data.Services
{
    public class ZadatakService
    {
        private AppDbContext _context;
        public ZadatakService(AppDbContext context)
        {
            _context = context;
        }

        public Zadatak DodajZadatak(ZadatakVM zadatak)
        {
            var korisnik = _context.Korisnici.FirstOrDefault(k => k.Id == zadatak.KorisnikId);
            var _zadatak = new Zadatak()
            {
                Opis = zadatak.Opis,
                Status = zadatak.Status,
                ZavrsniDatum = zadatak.ZavrsniDatum,
                DatumZavrsetka = zadatak.Status ? zadatak.DatumZavrsetka : null,
                KorisnikId = isKorisnikNull(zadatak) ? null : zadatak.KorisnikId,
            };
            _context.Zadaci.Add(_zadatak);
            _context.SaveChanges();
            
            return _zadatak;
        }


        public List<Zadatak> DohvatiZadatak()
        {
            var _zadaci = _context.Zadaci.ToList();

            foreach (var item in _zadaci)
            {
                item.Korisnik = _context.Korisnici.FirstOrDefault(k => k.Id == item.KorisnikId);
            }

            return _zadaci;
        }
        public List<Zadatak> DohvatiZadatkePoStatusu(bool zavrsen)
        {
            try
            {
                var _zadaci = _context.Zadaci.Where(z => z.Status == zavrsen).ToList();
                foreach (var item in _zadaci)
                {
                    item.Korisnik = _context.Korisnici.FirstOrDefault(k => k.Id == item.KorisnikId);
                }
                return _zadaci;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Zadatak> DohvatiZadatkePoKorisniku(int? id)
        {
            var _zadaci = _context.Zadaci.Where(z => z.KorisnikId == id).ToList();
            foreach (var item in _zadaci)
            {
                item.Korisnik = _context.Korisnici.FirstOrDefault(k => k.Id == item.KorisnikId);
            }

            if (_zadaci != null) return _zadaci;
            else throw new Exception("Korisnik nema ni jedan zadatak!");
        }
        public Zadatak DohvatiZadatakById(int zadatakId)
        {
            try
            {
                var _zad = _context.Zadaci.FirstOrDefault(z => z.Id == zadatakId);
                if (_zad != null) return _zad;
                else throw new Exception("Ne postoji zadatak sa traženim ID-em");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        public Zadatak UpdateZadatakById(int zadatakId, ZadatakVM zadatak)
        {
            var _zad = _context.Zadaci.FirstOrDefault(z => z.Id == zadatakId);
            if (_zad != null)
            {
                _zad.Opis = zadatak.Opis;
                _zad.Status = zadatak.Status;
                _zad.ZavrsniDatum = zadatak.ZavrsniDatum;
                _zad.DatumZavrsetka = zadatak.Status ? zadatak.DatumZavrsetka : null;
                _zad.KorisnikId = isKorisnikNull(zadatak) ? null : zadatak.KorisnikId;

                _context.SaveChanges();
            }
            return _zad;
        }
        public void IzbrisiZadatakById(int zadatakId)
        {
            var _zadatak = _context.Zadaci.FirstOrDefault(z => z.Id == zadatakId);
            if (_zadatak != null)
            {
                _context.Zadaci.Remove(_zadatak);
                _context.SaveChanges();
            }
            else throw new Exception($"Zadatak sa ID: {zadatakId} ne postoji!");
        }
        
        public bool isKorisnikNull(ZadatakVM zadatak)
        {
            return _context.Korisnici.FirstOrDefault(k => k.Id == zadatak.KorisnikId) == null;
        }
    }
}
