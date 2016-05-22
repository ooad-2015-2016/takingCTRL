using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAutootpad.Autootpad.Models;
using System.ComponentModel;
using ProjekatAutootpad.Autootpad.Helper;
using System.Windows.Input;
using Windows.UI.Xaml;
using ProjekatAutootpad.Autootpad.Views;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class PocetnaViewModel : INotifyPropertyChanged
    {
        public Kupac User { get; set; }
        public Radnik UlogovaniRadnik { get; set; }

        public string VerifikacijaPoruka { get; set; }
        public string UpisaniUsername { get; set; }
        public string UpisaniPass { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand LoginKupca { get; set; }
        public ICommand AdminLogin { get; set; }
        public ICommand UlazKaoGost { get; set; }
        public ICommand RegistracijaKupca { get; set; }
        public ICommand Izlaz { get; set; }
        public ICommand LoginRadnikaNavigacija { get; set; }
        public ICommand LoginRadnika { get; set; }
        public ICommand Kupovina { get; set; }
        public ICommand Prodaja { get; set; }
        public ICommand Narudžba { get; set; }
        public ICommand Servis { get; set; }
        public ICommand DijeloviRadnik { get; set; }
        public ICommand RadnikEditPodataka { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public PocetnaViewModel()
        {
            NavigationService = new NavigationService();
            User = new Kupac();
            UlogovaniRadnik = new Radnik();
            VerifikacijaPoruka = ""; 
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
            Kupovina = new RelayCommand<object>(kupovina);
            Prodaja = new RelayCommand<object>(prodaja);
            Servis = new RelayCommand<object>(servis);
            DijeloviRadnik = new RelayCommand<object>(dijeloviRadnik);
            RegistracijaKupca = new RelayCommand<object>(kupacRegistracija);
        }
    


    public PocetnaViewModel(AdminLoginViewModel pvm)
        {
            NavigationService = new NavigationService();

            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
            Kupovina = new RelayCommand<object>(kupovina);
            Prodaja = new RelayCommand<object>(prodaja);
            Servis = new RelayCommand<object>(servis);
            RegistracijaKupca = new RelayCommand<object>(kupacRegistracija);
        }

        public PocetnaViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();
            User = pvm.User;
            UlogovaniRadnik = pvm.UlogovaniRadnik;
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
            Kupovina = new RelayCommand<object>(kupovina);
            Prodaja = new RelayCommand<object>(prodaja);
            DijeloviRadnik = new RelayCommand<object>(dijeloviRadnik);
            Narudžba = new RelayCommand<object>(narudžba);
            RegistracijaKupca = new RelayCommand<object>(kupacRegistracija);
            Servis = new RelayCommand<object>(servis);
            RadnikEditPodataka = new RelayCommand<object>(radnikEditPodataka);
        }

        public PocetnaViewModel(RegistracijaKupacViewModel pvm)
        {
            NavigationService = new NavigationService();

            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
            Kupovina = new RelayCommand<object>(kupovina);
            Prodaja = new RelayCommand<object>(prodaja);
            Servis = new RelayCommand<object>(servis);
            RegistracijaKupca = new RelayCommand<object>(kupacRegistracija);

        }

        private void loginKupca(object parametar)
        {
            using (var db = new OtpadDbContext())
            {
                if (UpisaniPass.Length < 2 || UpisaniUsername.Length < 2)
                {
                    VerifikacijaPoruka = "Unesite tražene podatke.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    User = db.Kupci.Where(x => x.Username == UpisaniUsername && x.Password == UpisaniPass).FirstOrDefault();

                    if (User == null)
                    {
                        VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                        NotifyPropertyChanged("VerifikacijaPoruka");
                    }
                    else
                    {
                        VerifikacijaPoruka = "";
                        NotifyPropertyChanged("VerifikacijaPoruka");
                        NavigationService.Navigate(typeof(UlogovaniKupacMenu), new PocetnaViewModel(this));
                    }
                }
            }

        }

        private void loginRadnika(object parametar)
        {
            using (var db = new OtpadDbContext())
            {
                UlogovaniRadnik = db.Radnici.Where(x => x.Username == UpisaniUsername && x.Password == UpisaniPass).FirstOrDefault();

                if (UlogovaniRadnik == null)
                {
                    VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    VerifikacijaPoruka = "";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                    NavigationService.Navigate(typeof(RadnikMeni), new PocetnaViewModel(this));
                }
            }

        }


        private void ulazKaoGost(object parametar)
        {
            NavigationService.Navigate(typeof(PocetnaGost), new KupovinaViewModel(this));
        }

        private void adminLogin(object parametar)
        {
            NavigationService.Navigate(typeof(Views.AdminLogin), new AdminLoginViewModel(this));
        }

        private void kupovina(object parametar)
        {
            NavigationService.Navigate(typeof(KupovinaRegistrovaniKupac), new KupovinaViewModel(this));
        }

        private void prodaja(object parametar)
        {
            NavigationService.Navigate(typeof(ProdajaRegistrovaniKupac), new ProdajaRegistrovaniKupacViewModel(this));
        }
        private void servis(object parametar)
        {
            NavigationService.Navigate(typeof(ZahtjevZaServisRegistrovaniKupac), new ZahtjevZaServisRegistrovaniKupacViewModel(this));
        }

        private void loginRadnikaNavigacija(object parametar)
        {
            NavigationService.Navigate(typeof(Views.RadnikLogin), new PocetnaViewModel(this));
        }

        private void radnikEditPodataka (object parametar)
        {
            NavigationService.Navigate(typeof(RadnikPodaci), new RadnikPodaciViewModel(this));
        }

        private void dijeloviRadnik(object parametar)
        {
            NavigationService.Navigate(typeof(DodavanjeDijelaRadnik), new DodavanjeDijelaRadnikViewModel(this));
        }

        private void narudžba(object parametar)
        {
            NavigationService.Navigate(typeof(NaručivanjeDijela), new NaručivanjeDijelaViewModel(this));
        }

        private void kupacRegistracija(object parametar)
        {
            NavigationService.Navigate(typeof(KupacRegistracija), new RegistracijaKupacViewModel(this));
        }
        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }

    }
}
