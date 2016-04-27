using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class KupovinaViewModel
    {
        public Korisnik User { get; set; }
        //public 
        public List<Dio> SviDijelovi { get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.Dijelovi.ToList();
                }
            }
        }
        public List<Dio> Narudzba { get; set; }
        
        public KupovinaViewModel(PocetnaViewModel pvm)
        {
            User = pvm.User;
        }

    }
}
