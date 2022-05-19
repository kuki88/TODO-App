using TODO_App.Data.Models;

namespace TODO_App.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Korisnici.Any())
                {
                    context.Korisnici.AddRange(
                    new Korisnik()
                    {
                        ImePrezime = "Marko Markovic"
                    },
                    new Korisnik()
                    {
                        ImePrezime = "Pero Peric"
                    });
                    context.SaveChanges();
                }
                if (!context.Zadaci.Any())
                {
                    context.Zadaci.AddRange(
                    new Zadatak()
                    {
                        Opis = "Prvi zadatak",
                        Status = true,
                        ZavrsniDatum = DateTime.Now.AddDays(1),
                        DatumZavrsetka = DateTime.Now,
                        KorisnikId = 3
                    },
                    new Zadatak()
                    {
                        Opis = "Drugi zadatak",
                        Status = true,
                        ZavrsniDatum = DateTime.Now.AddDays(4),
                        DatumZavrsetka = DateTime.Now.AddDays(-2),
                        KorisnikId = 4
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
