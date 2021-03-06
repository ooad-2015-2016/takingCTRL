﻿using System;
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
                        imePrezime = "Alma Hodžić",
                        Username = "ahodzic",
                        Password = "alminpass",
                        Email = "ahodzic3@etf.unsa.ba",
			jeliPenzioner = false
                    }
                );
                context.SaveChanges();

            }
//            if (!context.Dijelovi.Any())
//            {
//                context.Dijelovi.AddRange(
//                    new Dio()
                    //{
//                        ProdajnaCijena = 150.0M,
//                        Model = "Golf 4",
//                        Proizvodjac = "Volkswagen",
//                        ImeDijela = "Akumulator",
//                        UProdaji = true
//                    }
//              );

//                try
//                {
//                    context.SaveChanges();
//                }
//                catch (Exception dbEx)
//                {

//                    throw dbEx.InnerException;
//                }
//            }

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
//                        KorisnikId = 2,
                        imePrezime = "Mujo Mujic",
                        Username = "mmujic",
                        Password = "mujinpass",
                        Email = "mujicmujo@gmail.com",
                        DatumRodjenja = new DateTime(2000, 12, 2)
                    }
                );               
            }

        }
    }
}
