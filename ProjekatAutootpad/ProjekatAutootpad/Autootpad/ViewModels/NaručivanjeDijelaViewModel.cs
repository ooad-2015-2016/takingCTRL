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
    class NaručivanjeDijelaViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public string Proizvođač { get; set; }
        public string Model { get; set; }
        public string ImeDijela { get; set; }
        public string Validacija { get; set; }
        public Kupac Naručilac { get; set; }

        public ICommand Naruči { get; set; }

        public NaručivanjeDijelaViewModel(PocetnaViewModel pvm)
        {
            Naručilac = pvm.User;
            Naruči = new RelayCommand<object>(naruči, možeLiNaručiti);
        }

        bool možeLiNaručiti(object p)
        {
            /*            bool uspjeh = Proizvođač.Length > 0 && Model.Length > 0 && ImeDijela.Length > 0;
                        if (!uspjeh)
                        {
                            Validacija = "Morate unijeti sva polja!";
                            NotifyPropertyChanged("Validacija");
                        }

                        return uspjeh;*/

            return true;
        }

        void naruči(object p)
        {
            using (var db = new OtpadDbContext())
            {
                db.NarudzbeDijelova.Add(new NarudžbaDijela(Proizvođač, Model, ImeDijela));
                db.SaveChanges();
                Validacija = "Narudžba uspješna!";
                Proizvođač = "";
                Model = "";
                ImeDijela = "";

                NotifyPropertyChanged("Proizvođač");
                NotifyPropertyChanged("Model");
                NotifyPropertyChanged("ImeDijela");
                NotifyPropertyChanged("Validacija");
            }
        }
    }
}
