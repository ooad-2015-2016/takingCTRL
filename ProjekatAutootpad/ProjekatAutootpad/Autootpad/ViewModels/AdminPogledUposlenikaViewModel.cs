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
using System.Text.RegularExpressions;

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

        public string ImePrezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Verifikacija { get; set; }


        public Radnik KliknutiRadnik { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand IzmjenaRadnika { get; set; }
        public ICommand DodavanjeRadnika { get; set; }
        public ICommand BrisanjeRadnika { get; set; }
        public ICommand SelectionChanged { get; set; }
        public ICommand Edituj { get; set; }
        public ICommand Izbriši { get; set; }


        //public string EditovanoIme { get { return _editovaniRadnik.imePrezime; } set { NotifyPropertyChanged("EditovanoIme"); _editovaniRadnik.imePrezime = value; } }
        //public string EditovaniUsername { get { return _editovaniRadnik.Username; } set { NotifyPropertyChanged("EditovaniUsername"); _editovaniRadnik.Username = value; } }
        //public string EditovaniPass { get { return _editovaniRadnik.Password; } set { NotifyPropertyChanged("EditovaniPass"); _editovaniRadnik.Password = value; } }
        //public string EditovaniEmail { get { return _editovaniRadnik.Email; } set { NotifyPropertyChanged("EditovaniEmail"); _editovaniRadnik.Email = value; } }
        //public DateTime EditovaniDatum { get { return _editovaniRadnik.DatumRodjenja; } set { NotifyPropertyChanged("EditovaniDatum"); _editovaniRadnik.DatumRodjenja = value; } }

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
            Edituj = new RelayCommand<object>(edituj);
            Username = "";
            ImePrezime = "";
            Password = "";
            Verifikacija = "";
            //EditovaniDatum = new DateTime();
            Email = "";
            SelectionChanged = new RelayCommand<object>(selectionChanged);
            Izbriši = new RelayCommand<object>(izbriši);
        }

        public void izbriši(object o)
        {
            if (KliknutiRadnik != null)
            {
                using (var db = new OtpadDbContext())
                {
                    /*EditovaniUsername = "";
                    EditovanoIme = "";
                    EditovaniPass = "";
                    EditovaniDatum = new DateTime();
                    EditovaniEmail = "";*/

                    db.Remove(KliknutiRadnik);
                    db.SaveChanges();
                    Verifikacija = "Uspješno izbrisan radnik.";
                    NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("radnici");
                }
            }
        }

        public void edituj(object o)
        {
            NavigationService.Navigate(typeof(EditRadnikaAdminView), new EditRadnikaAdminViewModel(this));
            //NavigationService.Navigate(typeof(TestView), new TestViewModel(this));

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
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email); 


            if (ImePrezime.Length == 0)
                Verifikacija = "Morate unijeti ime radnika.";
            else if (!match.Success)
                    Verifikacija = "Nije validna mail adresa.";

                else if (Username.Length == 0)
                Verifikacija = "Morate unijeti username.";

            else if (Password.Length < 4)
                Verifikacija = "Password mora imati barem 4 znaka.";
            


            else
                using (var db = new OtpadDbContext())
                {
                    Radnik novi = new Radnik();
                    novi.imePrezime = ImePrezime;
                    novi.Username = Username;
                    novi.Password = Password;
                    novi.Email = Email; 
                    //datum
                    db.Radnici.Add(novi);

                    db.SaveChanges();
                    ImePrezime = "";
                    Username = "";
                    Password = "";
                    Email = "";
                    Verifikacija = "Uspješno dodan radnik";

                    NotifyPropertyChanged("ImePrezime");
                    NotifyPropertyChanged("Username");
                    NotifyPropertyChanged("Password");
                    NotifyPropertyChanged("Email");
                    NotifyPropertyChanged("radnici");
                }

            NotifyPropertyChanged("Verifikacija");

        }

    }
}
