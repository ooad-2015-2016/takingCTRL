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
        
        public KupovinaViewModel(PocetnaViewModel pvm)
        {
            User = pvm.User;
        }

    }
}
