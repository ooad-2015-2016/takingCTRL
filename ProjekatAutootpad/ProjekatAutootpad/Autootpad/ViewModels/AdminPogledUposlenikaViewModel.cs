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
    class AdminPogledUposlenikaViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public Radnik User { get; set; }
        private Radnik _editovaniRadnik;
        public Radnik EditovaniRadnik {
            get { EditovanoIme = _editovaniRadnik.imePrezime; return _editovaniRadnik; }
            set { _editovaniRadnik = value;
                NotifyPropertyChanged("EditovanoIme");
                NotifyPropertyChanged("EditovaniUsername");
                NotifyPropertyChanged("EditovaniPass");
                NotifyPropertyChanged("EditovaniEmail");
                NotifyPropertyChanged("EditovaniDatum");

            }
        }
        public INavigationService NavigationService { get; set; }
        public ICommand IzmjenaRadnika { get; set; }
        public ICommand DodavanjeRadnika { get; set; }
        public ICommand BrisanjeRadnika { get; set; }
        public ICommand SelectionChanged { get; set; }
        public Radnik KliknutiRadnik { get; set; }

        public string EditovanoIme { get { return _editovaniRadnik.imePrezime; } set { NotifyPropertyChanged("EditovanoIme"); _editovaniRadnik.imePrezime = value; } }
        public string EditovaniUsername { get { return _editovaniRadnik.Username; } set { NotifyPropertyChanged("EditovaniUsername"); _editovaniRadnik.Username = value; } }
        public string EditovaniPass { get { return _editovaniRadnik.Password; } set { NotifyPropertyChanged("EditovaniPass"); _editovaniRadnik.Password = value; } }
        public string EditovaniEmail { get { return _editovaniRadnik.Email; } set { NotifyPropertyChanged("EditovaniEmail"); _editovaniRadnik.Email = value; } }
        public DateTime EditovaniDatum { get { return _editovaniRadnik.DatumRodjenja; } set { NotifyPropertyChanged("EditovaniDatum"); _editovaniRadnik.DatumRodjenja = value; } }

        public List<Radnik> radnici
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.Radnici.ToList();
                }
            }
        }

        public AdminPogledUposlenikaViewModel()
        {
            NavigationService = new NavigationService();
            IzmjenaRadnika = new RelayCommand<object>(izmjenaRadnika);
            DodavanjeRadnika = new RelayCommand<object>(dodavanjeRadnika);
            BrisanjeRadnika = new RelayCommand<object>(brisanjeRadnika);
            EditovaniRadnik = new Radnik();
            SelectionChanged = new RelayCommand<object>(selectionChanged);

        }

        public void selectionChanged(object p)
        {
            NotifyPropertyChanged("EditovaniRadnik.Username");
        }

        
        public void brisanjeRadnika(object parametar)
        {

        }
        


        public void izmjenaRadnika(object parametar)
        {

        }

        public void dodavanjeRadnika(object parametar)
        {
            var db = new OtpadDbContext();
            

            if (db.Radnici.Any(x => x.radnikId == EditovaniRadnik.radnikId))
            {
                db.Update(EditovaniRadnik);
            }

            else
            {
                db.Radnici.Add(EditovaniRadnik);
            }

            db.SaveChanges();
            NotifyPropertyChanged("radnici");

        }



    }
}
