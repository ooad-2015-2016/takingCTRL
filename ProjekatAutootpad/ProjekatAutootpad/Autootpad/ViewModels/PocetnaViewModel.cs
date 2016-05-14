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
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
        }

        public PocetnaViewModel(AdminLoginViewModel pvm)
        {
            NavigationService = new NavigationService();
            User = new Kupac();
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);

        }

        public PocetnaViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();
            User = new Kupac();
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = "";

            LoginKupca = new RelayCommand<object>(loginKupca);
            LoginRadnika = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            UlazKaoGost = new RelayCommand<object>(ulazKaoGost);
            Izlaz = new RelayCommand<object>(izlaz);
            LoginRadnikaNavigacija = new RelayCommand<object>(loginRadnikaNavigacija);
        }

        private void loginKupca(object parametar)
        {
            using (var db = new OtpadDbContext())
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
                    NavigationService.Navigate(typeof(KupovinaRegistrovaniKupac), new KupovinaViewModel(this));
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
                    NavigationService.Navigate(typeof(KupovinaRegistrovaniKupac), new KupovinaViewModel(this));
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

        private void loginRadnikaNavigacija(object parametar)
        {
            NavigationService.Navigate(typeof(Views.RadnikLogin), new PocetnaViewModel(this));
        }


        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }

    }
}
