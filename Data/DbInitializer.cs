using Kolokvijum2.Models;

namespace Kolokvijum2.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            var db = context.Database.EnsureCreated();
            if (!db)
            {
                return;
            }
            else
            {
                var proizvodjaci = new Proizvodjac[]
                {
                    new Proizvodjac{ NazivProizvodjaca = "Audi" },
                    new Proizvodjac{ NazivProizvodjaca = "BMW" },
                    new Proizvodjac{ NazivProizvodjaca = "Mercedes" },
                    new Proizvodjac{ NazivProizvodjaca = "Subaru" },
                    new Proizvodjac{ NazivProizvodjaca = "Hyndai" }
                };
                context.Proizvodjaci.AddRange(proizvodjaci);
                context.SaveChanges();

                var automobili = new Automobil[]
                {
                    new Automobil{ NazivAutomobila = "A5", Proizvodjac = context.Proizvodjaci.FirstOrDefault(p => p.ProizvodjacID == 1) },
                    new Automobil{ NazivAutomobila = "SLK 600", Proizvodjac = context.Proizvodjaci.FirstOrDefault(p => p.ProizvodjacID == 3) },
                    new Automobil{ NazivAutomobila = "Imprezza", Proizvodjac = context.Proizvodjaci.FirstOrDefault(p => p.ProizvodjacID == 4) },
                    new Automobil{ NazivAutomobila = "M740", Proizvodjac = context.Proizvodjaci.FirstOrDefault(p => p.ProizvodjacID == 2) },
                    new Automobil{ NazivAutomobila = "i30", Proizvodjac = context.Proizvodjaci.FirstOrDefault(p => p.ProizvodjacID == 5) }
                };
                context.Automobili.AddRange(automobili);
                context.SaveChanges();
            }
        }
    }
}
