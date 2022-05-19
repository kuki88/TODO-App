namespace TODO_App.Data.Models
{
    public class Zadatak
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public bool Status { get; set; }
        public DateTime ZavrsniDatum { get; set; }
        public DateTime? DatumZavrsetka { get; set; }

        public int? KorisnikId { get; set; }
        public Korisnik? Korisnik { get; set; }

    }
}
