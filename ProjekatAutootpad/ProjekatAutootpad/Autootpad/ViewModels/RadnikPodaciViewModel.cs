using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System.Text.RegularExpressions;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class RadnikPodaciViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        //uposlenik koji se priprema za kreiranje
        public Radnik UlogovaniRadnik { get; set; }

        //kamera uredjaj
        private CameraHelper cam; 
        public CameraHelper Camera { get { return cam; } set { cam = value; cam.InitializeCameraAsync(); } }

        public ICommand DodajUposlenika { get; set; }
        public ICommand Uslikaj { get; set; }
        public ICommand Ažuriraj { get; set; }
        public string VerifikacijaPoruka { get; set; }
        //Negdje privremeno mora biti slika koja ce se prikazati kad se uslika
        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; OnNotifyPropertyChanged("Slika"); } }
        
        //kontrola krsenje mvvm
        CaptureElement previewControl;
        public RadnikPodaciViewModel(PocetnaViewModel pvm, SoftwareBitmapSource slika)
        {
            //incijalicacija uredjaja
            UlogovaniRadnik = pvm.UlogovaniRadnik;
            Slika = slika;

            //DodajUposlenika = new RelayCommand<object>(dodajUposlenika, (object parametar) => true);
            Uslikaj = new RelayCommand<object>(uslikaj, (object parametar) => true);
            Ažuriraj = new RelayCommand<object>(ažuriraj, (object parametar) => true);

            /*if (UlogovaniRadnik.Slika != null)
                Slika = ImageFromBytes(UlogovaniRadnik.Slika);*/

        }
        private bool validanMail(string uneseniMail)
        {
            Regex regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regx.Match(uneseniMail);
            if (match.Success)
                return true;

            return false;
        }
        public void ažuriraj(object param)
        {
            using (var db = new OtpadDbContext())
            {
                if (UlogovaniRadnik.imePrezime == "")
                {
                    VerifikacijaPoruka = "Unesite ime.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else if (!validanMail(UlogovaniRadnik.Email))
                {
                    VerifikacijaPoruka = "Niste unijeli validnu email adresu.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    db.Update(UlogovaniRadnik);
                    db.SaveChanges();
                }
            }
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

        //callback funkcija kad se uslika 
        public async void SlikanjeGotovo(SoftwareBitmapSource nova)
        {
            UlogovaniRadnik.Slika = Camera.SlikaByte;
            /*
            FileSavePicker fsp = new FileSavePicker();
            fsp.FileTypeChoices.Add("JPG", new List<String>() { ".jpg" });
            fsp.SuggestedFileName = "slika test";
            StorageFile f = await fsp.PickSaveFileAsync();
            await FileIO.WriteBufferAsync(f, UlogovaniRadnik.Slika.AsBuffer());

            */
            Camera.Slika.Seek(0);



            /*byte[] bytes = new byte[Camera.Slika.Size];
            IBuffer buffer = bytes.AsBuffer();
            await Camera.Slika.ReadAsync(buffer, (uint) Camera.Slika.Size, InputStreamOptions.None);
            await FileIO.WriteBufferAsync(f, buffer);

            SoftwareBitmapSource nanoviji = new SoftwareBitmapSource();*/
            InMemoryRandomAccessStream Slika_op = new InMemoryRandomAccessStream();

            await Slika_op.WriteAsync(UlogovaniRadnik.Slika.AsBuffer());
            await Slika_op.FlushAsync();
            Slika_op.Seek(0);

            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(Slika_op);
            //PixelDataProvider pdp = await decoder.GetPixelDataAsync();
            //SlikaByte = pdp.DetachPixelData();
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
            BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            Slika = new SoftwareBitmapSource();
            await Slika.SetBitmapAsync(softwareBitmapBGR8);

        }
        //proeprty changed observer
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
