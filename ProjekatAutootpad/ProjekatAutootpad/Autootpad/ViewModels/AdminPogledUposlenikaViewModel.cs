﻿using System;
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
            get { return _editovaniRadnik; }
            set { _editovaniRadnik = value;
                NotifyPropertyChanged("EditovaniRadnik.imePrezime");
                NotifyPropertyChanged("EditovaniRadnik.Username");
                NotifyPropertyChanged("EditovaniRadnik.Password");
                NotifyPropertyChanged("EditovaniRadnik.DatumRodjenja");
                NotifyPropertyChanged("EditovaniRadnik.Email");
            }
        }

        public Radnik KliknutiRadnik        { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand IzmjenaRadnika { get; set; }
        public ICommand DodavanjeRadnika { get; set; }
        public ICommand BrisanjeRadnika { get; set; }
        public ICommand SelectionChanged { get; set; }
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
            EditovaniRadnik = new Radnik();
            /*EditovaniUsername = "";
            EditovanoIme = "";
            EditovaniPass = "";
            EditovaniDatum = new DateTime();
            EditovaniEmail = "";*/
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
                    NotifyPropertyChanged("radnici");
                }
            }
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
            using (var db = new OtpadDbContext())
            { 
                if (db.Radnici.Any(x => x.radnikId == EditovaniRadnik.radnikId))
                    db.Update(EditovaniRadnik);

                else
                    db.Radnici.Add(EditovaniRadnik);

            db.SaveChanges();
            EditovaniRadnik = new Radnik();
            NotifyPropertyChanged("radnici");
            }

        }
    }
}
