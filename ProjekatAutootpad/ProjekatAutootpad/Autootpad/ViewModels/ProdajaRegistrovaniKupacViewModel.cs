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
    class ProdajaRegistrovaniKupacViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public decimal Cijena { get; set; }
        public Kupac User { get; set; }
        public List<NarudžbaDijela> SveNarudzbe
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.NarudzbeDijelova.ToList();
                }
            }
        }

        public ICommand Ponudi { get; set; }
        public ICommand otkazi { get; set; }
        public NarudžbaDijela IzabranaNarudžba { get; set; }

        public ProdajaRegistrovaniKupacViewModel(PocetnaViewModel pvm)
        {
            User = pvm.User;
            Ponudi = new RelayCommand<object>(ponudi, mozeLiSeDodati);
        }

        void ponudi(object parametar)
        {
            var db = new OtpadDbContext();
            db.Dijelovi.Add(new Dio(IzabranaNarudžba, Cijena));
            db.NarudzbeDijelova.Remove(IzabranaNarudžba);
            db.SaveChanges();
            IzabranaNarudžba = null;
            NotifyPropertyChanged("SveNarudzbe");
        }


        bool mozeLiSeDodati(object parametar)
        {
            return true;
        }

    }
}
