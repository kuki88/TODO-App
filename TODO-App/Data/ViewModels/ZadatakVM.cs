using TODO_App.Data.Models;

namespace TODO_App.Data.ViewModels
{
    public class ZadatakVM
    {
        public string Opis { get; set; }
        public bool Status { get; set; }
        public DateTime ZavrsniDatum { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
        public int KorisnikId { get; set; }
    }
}
