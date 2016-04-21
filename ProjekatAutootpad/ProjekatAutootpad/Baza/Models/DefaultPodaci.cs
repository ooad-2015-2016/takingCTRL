using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Baza.Models
{

    class DefaultPodaci
    {
        public static void Initialize(NarudžbaDijelaDbContext context)
        {
            if (!context.NarudžbeDijelova.Any())
            {
                context.NarudžbeDijelova.AddRange(
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
        }
    }
}
