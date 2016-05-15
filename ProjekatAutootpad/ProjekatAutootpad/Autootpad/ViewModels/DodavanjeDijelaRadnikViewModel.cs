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
    class DodavanjeDijelaRadnikViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public ICommand DodajDio { get; set; }
        public ICommand OtkaziDodavanje { get; set; }
        public ICommand OdbijPonuduDijela { get; set; }
        public Radnik UlogovaniRadnik { get; set; }
        public Dio IzabraniDio { get; set; }


        public List<Dio> SviDijelovi
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.Dijelovi.Where(x => !x.UProdaji).ToList();
                }
            }
        }

        public DodavanjeDijelaRadnikViewModel(PocetnaViewModel pvm)
        {
            UlogovaniRadnik = pvm.UlogovaniRadnik;
            DodajDio = new RelayCommand<object>(dodaj, mozeLiSeDodati);
            OdbijPonuduDijela = new RelayCommand<object>(odbij, mozeLiSeDodati);
        }


        public void dodaj(object p)
        {
            using (var db = new OtpadDbContext())
            {
                IzabraniDio.UProdaji = true;
                db.Dijelovi.Update(IzabraniDio);
                IzabraniDio = null;
                db.SaveChanges();
                NotifyPropertyChanged("SviDijelovi");
            }

        }
        public void odbij(object p)
        {
            using (var db = new OtpadDbContext())
            {
                NarudžbaDijela nd = new NarudžbaDijela(IzabraniDio);

                db.Dijelovi.Remove(IzabraniDio);
                db.NarudzbeDijelova.Add(nd);
                IzabraniDio = null;
                db.SaveChanges();
                NotifyPropertyChanged("SviDijelovi");
            }

        }
        
        
        public bool mozeLiSeDodati(object parametar) // Za sada ovu funkciju koristimo i za odbijanje ponuđenog dijela
        {
            return true;
        }
    }
}
