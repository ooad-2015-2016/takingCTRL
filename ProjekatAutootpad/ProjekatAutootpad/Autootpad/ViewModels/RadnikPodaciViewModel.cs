using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class RadnikPodaciViewModel : INotifyPropertyChanged
    {
        //uposlenik koji se priprema za kreiranje
        public Radnik UlogovaniRadnik { get; set; }

        //kamera uredjaj
        private CameraHelper cam; 
        public CameraHelper Camera { get { return cam; } set { cam = value; cam.InitializeCameraAsync(); } }

        public ICommand DodajUposlenika { get; set; }
        public ICommand Uslikaj { get; set; }
        //Negdje privremeno mora biti slika koja ce se prikazati kad se uslika
        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; OnNotifyPropertyChanged("Slika"); } }
        //kontrola krsenje mvvm
        CaptureElement previewControl;
        public RadnikPodaciViewModel(PocetnaViewModel pvm)
        {
            //incijalicacija uredjaja
            UlogovaniRadnik = pvm.UlogovaniRadnik;

            //DodajUposlenika = new RelayCommand<object>(dodajUposlenika, (object parametar) => true);
            Uslikaj = new RelayCommand<object>(uslikaj, (object parametar) => true);
        }
        //komanda koja inicira slikanje
        public async void uslikaj(object parametar)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }
        //komanda za dodavanje uposlenika
        public void dodajUposlenika(object parametar)
        {
//          eksterniServis.dodajKorisnika(CreateUposlenik);
            
        }
        //callback na read rfid
        public void RfidReadSomething(string rfidKod)
        {
            //CreateUposlenik.RfidKartica = rfidKod;
        }

        //callback funkcija kad se uslika 
        public void SlikanjeGotovo(SoftwareBitmapSource nova)
        {
            Slika = nova;
                      
            
        }
        //proeprty changed observer
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
