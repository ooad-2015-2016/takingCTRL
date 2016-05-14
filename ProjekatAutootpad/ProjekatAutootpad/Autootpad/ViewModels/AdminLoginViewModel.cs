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
    class AdminLoginViewModel : INotifyPropertyChanged
    {

        public string VerifikacijaPoruka { get; set; }
        public string UpisaniPass { get; set; }
        public string Password { get; set; }
        public string Pass_b { get; set; }


    

        public INavigationService NavigationService { get; set; }
        public ICommand LoginAdmina { get; set; }
        public ICommand Nazad { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public AdminLoginViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            Password = "adminpass";

            LoginAdmina = new RelayCommand<object>(loginAdmina);
            Nazad = new RelayCommand<object>(nazad);

        }

        private void loginAdmina(object parametar)
        {

            if (UpisaniPass != Password)
            {
                VerifikacijaPoruka = "Password je netačan.";
                NotifyPropertyChanged("VerifikacijaPoruka");
            }
            else
            {
                VerifikacijaPoruka = "";
                NavigationService.Navigate(typeof(AdminPogledUposlenika), new AdminPogledUposlenikaViewModel());

            }
        }



        private void nazad(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }
    }
}
