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
    class PocetnaViewModel
    {
        public Korisnik User { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand LoginKupca { get; set; }
        public ICommand AdminLogin { get; set; }
        public ICommand UlazKaoGost { get; set; }
        public ICommand RegistracijaKupca { get; set; }
        public ICommand Izlaz { get; set; }


        public PocetnaViewModel()
        {
            NavigationService = new NavigationService();
            User = new Korisnik();

            LoginKupca = new RelayCommand<object>(loginKupca);
            Izlaz = new RelayCommand<object>(izlaz);
        }

        private void loginKupca(object parametar)
        {

        }

        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }
    }
}
