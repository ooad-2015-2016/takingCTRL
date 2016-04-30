using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class ZahtjevZaServisRegistrovaniKupacViewModel
    {
        public NarudzbaServisa narudzbaServisa { get; set; }
        public ICommand Dodaj { get; set; }

        public void spasiZahtjevZaServis()
        {
            Dodaj = new RelayCommand<object>(dodaj, mozeLiSeDodati);
        }

        public void dodaj(object parametar)
        {
            var db = new OtpadDbContext();
            db.narudzbeServisa.Add(narudzbaServisa);
        }

        public bool mozeLiSeDodati(object parametar)
        {
            return true;
        }
    }
}
