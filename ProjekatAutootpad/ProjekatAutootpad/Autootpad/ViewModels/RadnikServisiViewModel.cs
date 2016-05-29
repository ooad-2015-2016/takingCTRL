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
    class RadnikServisiViewModel : INotifyPropertyChanged
    {
        public Radnik UlogovaniRadnik { get; set; }
        public NarudzbaServisa KliknutiZahtjev { get;set;}
        public ICommand Odbij { get; set; }
        public ICommand Servisiraj { get; set; }
        public string Verifikacija { get; set; }
        public string CijenaTekst { get; set; }

        public List<NarudzbaServisa> zahtjevi
        {
            private set { }
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.narudzbeServisa.ToList();
                }
            }
        }

        public RadnikServisiViewModel(PocetnaViewModel pvm)
        {
            UlogovaniRadnik = pvm.UlogovaniRadnik;
            Odbij = new RelayCommand<object>(odbij);
            Servisiraj = new RelayCommand<object>(servisirano);
        }

        public void odbij(object param)
        {
            if (KliknutiZahtjev != null)
            {
                using (var db = new OtpadDbContext())
                {
                    db.narudzbeServisa.Remove(KliknutiZahtjev);
                    db.SaveChanges();
                    KliknutiZahtjev = null;
                    Verifikacija = "Zahtjev odbijen.";
                    NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("zahtjevi");
                    CijenaTekst = "";
                    NotifyPropertyChanged("CijenaTekst");
                }
            }
            else
            {
                Verifikacija = "Niste odabrali zahtjev.";
                NotifyPropertyChanged("Verifikacija");
            }
        }

        public void servisirano(object param)
        {
            if (KliknutiZahtjev != null)
            {

                try
                {
                    if (decimal.Parse(CijenaTekst) <= 0.0m)
                    {
                        Verifikacija = "Neispravna cijena.";
                        NotifyPropertyChanged("Verifikacija");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Verifikacija = "Neispravna cijena.";
                    NotifyPropertyChanged("Verifikacija");
                    return;
                }

                using (var db = new OtpadDbContext())
                {
                    db.narudzbeServisa.Remove(KliknutiZahtjev);
                    db.SaveChanges();
                    KliknutiZahtjev = null;
                    Verifikacija = "Zahtjev servisiran.";
                    NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("zahtjevi");
                    CijenaTekst = "";
                    NotifyPropertyChanged("CijenaTekst");
                }
            }
            else
            {
                Verifikacija = "Niste odabrali zahtjev.";
                NotifyPropertyChanged("Verifikacija");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

    }
}
