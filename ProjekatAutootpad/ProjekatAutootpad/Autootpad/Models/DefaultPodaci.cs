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

            if (!context.Kupci.Any())
            {
                context.Kupci.AddRange(
                    new Kupac()
                    {
                        KorisnikId = 1,
                        imePrezime = "Alma Hodžić",
                        username = "ahodzic",
                        password = "mojPassword",
                        // datumRodjenja = 1998,04,30, -> poslije ću
                        email = "ahodzic3@etf.unsa.ba"
                    }
                );

                //context.SaveChanges();
                   

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

                try
                {
                    context.SaveChanges();
                }
                catch (Exception dbEx)
                {

                    throw dbEx.InnerException;
                }
            }

            if (!context.servisi.Any())
            {
                context.servisi.AddRange(
                    new Servis()
                    {
                        cijena = 400,
                        odraden = true
                    }
                );
                context.SaveChanges();
            }

            if (!context.Radnici.Any())
            {
                context.Radnici.AddRange(
                    new Radnik()
                    {
                        KorisnikId = 2,
                        imePrezime = "Mujo Mujic",
                        username = "mmujic",
                        password = "mujinpass",
                        datumRodjenja = new DateTime(2000, 12, 2),
                        email = "mujicmujo@gmail.com"
                    }
                );               
            }

        }
    }
}
