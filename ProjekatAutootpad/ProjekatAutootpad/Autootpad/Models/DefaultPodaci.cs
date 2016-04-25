using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{

    class DefaultPodaci
    {
        public static void Initialize(OtpadDbContext context)
        {
            if (!context.NarudzbeDijelova.Any())
            {
                context.NarudzbeDijelova.AddRange(
                    new NarudžbaDijela()
                    {
                        Proizvođač = "Volkswagen",
                        Model = "Golf 2",
                        NazivDijela = "Anlaser",
                        Prihvaćena = false
                    }
                );
                context.SaveChanges();
            }

            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                    new Korisnik()
                    {
                        imePrezime = "Alma Hodžić",
                        username = "ahodzic",
                        password = "mojPassword",
                        // datumRodjenja = 1998,04,30, -> poslije ću
                        email = "ahodzic3@etf.unsa.ba"
                    }
                );
                context.SaveChanges();
            }
            if (!context.Dijelovi.Any())
            {
                context.Dijelovi.AddRange(
                    new Dio()
                    {
                        NabavnaCijena = 0,
                        ProdajnaCijena = 0,
                        Model = "Nepoznat",
                        Proizvodjac = "Nepoznat"
                    }
                );
                context.SaveChanges();
            }

        }





    }
}
