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
    class EditRadnikaAdminViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public Radnik EditovaniRadnik { get; set; }
        public ICommand Ažuriraj { get; set; }
        public string Verifikacija { get; set; }

        public EditRadnikaAdminViewModel(AdminPogledUposlenikaViewModel apuvm)
        {
            EditovaniRadnik = apuvm.KliknutiRadnik;
            Ažuriraj = new RelayCommand<object>(ažuriraj);
            Verifikacija = "";
        }

        public void ažuriraj(object param)
        {
            if (EditovaniRadnik.imePrezime.Length == 0)
                Verifikacija = "Niste upisali ime.";
            else if (EditovaniRadnik.Password.Length < 4)
                Verifikacija = "Password mora biti duži od 4 karaktera.";
            //else if (verifikacija maila)
            //Verifikacija = "Password mora biti duži od 4 karaktera.";
            else if (EditovaniRadnik.Username.Length == 0)
                Verifikacija = "Niste upisali username.";

            else
                using (var db = new OtpadDbContext())
                {
                    db.Update(EditovaniRadnik);
                    db.SaveChanges();
                    Verifikacija = "Uspješno ažurirani podaci!";
                }

            NotifyPropertyChanged("Verifikacija");

        }
    }
}
