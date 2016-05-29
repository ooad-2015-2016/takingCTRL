using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class ZahtjevZaServisRegistrovaniKupacViewModel
    {
        public NarudzbaServisa narudzbaServisa { get; set; }
        public PocetnaViewModel Parent { get; set; }
        public Kupac _User { get; set; }
        public ICommand Dodaj { get; set; }

        public bool Online { get; set; }
        public bool Gotovinom { get; set; }



        public ZahtjevZaServisRegistrovaniKupacViewModel(PocetnaViewModel pvm)
        {
            narudzbaServisa = new NarudzbaServisa();
            _User = pvm.User;
            this.Parent = pvm;
            Dodaj = new RelayCommand<object>(dodaj, mozeLiSeDodati);
        }

        public void spasiZahtjevZaServis()
        {
            Dodaj = new RelayCommand<object>(dodaj, mozeLiSeDodati);
        }

        public void dodaj(object parametar)
        {

            using (var db = new OtpadDbContext())
            {
                //narudzbaServisa.narucilac = _User;
                db.narudzbeServisa.Add(narudzbaServisa);
                db.SaveChanges();
            }
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiSeDodati(object parametar)
        {
            return true;
        }
    }
}
