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
    class ZahtjevZaServisRegistrovaniKupacViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public NarudzbaServisa narudzbaServisa { get; set; }
        public PocetnaViewModel Parent { get; set; }
        public Kupac _User { get; set; }
        public ICommand Dodaj { get; set; }

        public bool Online { get; set; }
        public bool Gotovinom { get; set; }

        public string Validacija { get; set; }



        public ZahtjevZaServisRegistrovaniKupacViewModel(PocetnaViewModel pvm)
        {
            narudzbaServisa = new NarudzbaServisa();
            _User = pvm.User;
            this.Parent = pvm;
            Dodaj = new RelayCommand<object>(dodaj, mozeLiSeDodati);
            Validacija = "";
            narudzbaServisa = new NarudzbaServisa();
            narudzbaServisa.opisKvara = "";
            narudzbaServisa.Model = "";
            narudzbaServisa.Proizvodjac = "";
            narudzbaServisa.narucilac = this._User;
        }


        public void dodaj(object parametar)
        {

            if (narudzbaServisa.Model == "" || narudzbaServisa.Proizvodjac == "" || narudzbaServisa.opisKvara == "")
                Validacija = "Morate ispuniti sva polja.";

            else
                using (var db = new OtpadDbContext())
                {
                    //narudzbaServisa.narucilac = _User;
                    db.narudzbeServisa.Add(narudzbaServisa);
                    db.SaveChanges();
                    Validacija = "Uspješno podnesen zahtjev.";
                    narudzbaServisa = new NarudzbaServisa();
                    narudzbaServisa.narucilac = this._User;
                }
            NotifyPropertyChanged("Validacija");




            //Parent.NavigationService.GoBack();
        }

        public bool mozeLiSeDodati(object parametar)
        {
            return true;
        }
        

    }
}
