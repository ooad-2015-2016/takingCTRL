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
    class RegistracijaKupacViewModel : INotifyPropertyChanged
    {
        public string VerifikacijaPoruka { get; set; }
        public string uImeiprezime { get; set; }
        public string uUsername { get; set; }
        public string uPassword { get; set; }
        public string uPassword2 { get; set; }
        public DateTime uDatumrodjenja { get; set; }
        public bool uPenzioner { get; set; }
        public string uEmail { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand RegistrujNovog { get; set; }
        public ICommand IzlazRegistracija { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public RegistracijaKupacViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();
            VerifikacijaPoruka = "";
            uImeiprezime = "";
            uUsername = "";
            uPassword = "";
            uPassword2 = "";
            uPenzioner = false;
            uEmail = "";

            IzlazRegistracija = new RelayCommand<object>(izlazRegistracija);
            RegistrujNovog = new RelayCommand<object>(registrujNovog);
        }

        private void registrujNovog(object parametar)
        {
            using (var db = new OtpadDbContext())
            {
                if (uImeiprezime.Length < 2 || uUsername.Length < 2 || uEmail.Length < 2 || uPassword.Length < 2 || uPassword2.Length < 2)
                {

                    VerifikacijaPoruka = "Unesite sve tražene podatke.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    if (uPassword != uPassword2)
                    {
                        VerifikacijaPoruka = "Unesene lozinke se ne poklapaju.";
                        NotifyPropertyChanged("VerifikacijaPoruka");
                    }
                    else
                    {
                        Kupac postojeci = db.Kupci.Where(x => x.Username == uUsername).FirstOrDefault();
                        if (postojeci != null)
                        {
                            VerifikacijaPoruka = "Korisnik s tim korisničkim imenom već postoji.";
                            NotifyPropertyChanged("VerifikacijaPoruka");
                        }
                        else
                        {
                            Kupac novi = new Kupac(uImeiprezime, uUsername, uPassword, uDatumrodjenja, uEmail, uPenzioner);
                            db.Kupci.Add(novi);
                            db.SaveChanges();
                            VerifikacijaPoruka = "Registracija uspjesno završena.";
                            NotifyPropertyChanged("VerifikacijaPoruka");
                        }
                    }
                }
            }
        }
        private void izlazRegistracija(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }
    }
}

