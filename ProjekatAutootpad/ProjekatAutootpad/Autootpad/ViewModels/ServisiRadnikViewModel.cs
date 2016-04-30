using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class ServisiRadnikViewModel
    {
        public Korisnik User { get; set; }
        //public 
        public List<NarudzbaServisa> SviServisi
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.naruzbeServisa.ToList(); // napraviti migraciju za ovo -> kod mene ne moze, mozda moze nesto kao update -> pitati Emira C.
                }
            }
        }
        // Uradila sam ovo kako je Edo, jer je slično
        // moram još proguglati ViewModel-e

        /* public KupovinaViewModel() // Na šta da se zakači ovaj VM - pitati Edu
        {
        }
        */
    }
}
