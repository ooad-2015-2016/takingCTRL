using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using ProjekatAutootpad.Autootpad.Views;
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
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class ProdajaRegistrovaniKupacViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            //? je skracena verzija ako nije null
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }


        private CameraHelper cam;
        public CameraHelper Camera { get { return cam; } set { cam = value; cam.InitializeCameraAsync(); } }

        

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public byte[] SlikaByte;
        public byte[] PrihvaćenaSlikaByte;

        public String Cijena { get; set; }
        public String Validacija { get; set; }
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
        public ICommand Uslikaj { get; set; }
        public ICommand PočniSlikanje { get; set; }
        public ICommand Prihvati { get; set; }
        public ICommand otkazi { get; set; }
        public NarudžbaDijela IzabranaNarudžba { get; set; }
        public INavigationService NavigationService { get; set; }


        private SoftwareBitmapSource slika;
        public SoftwareBitmapSource Slika { get { return slika; } set { slika = value; OnNotifyPropertyChanged("Slika"); } }

        public ProdajaRegistrovaniKupacViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();

            User = pvm.User;
            Ponudi = new RelayCommand<object>(ponudi, mozeLiSeDodati);
            Uslikaj = new RelayCommand<object>(uslikaj);
            PočniSlikanje = new RelayCommand<object>(počniSlikanje);
            Prihvati = new RelayCommand<object>(prihvati);
            Validacija = "";
        }


        public ProdajaRegistrovaniKupacViewModel(ProdajaRegistrovaniKupacViewModel pvm)
        {
            NavigationService = new NavigationService();

            User = pvm.User;
            IzabranaNarudžba = pvm.IzabranaNarudžba;
            Ponudi = new RelayCommand<object>(ponudi, mozeLiSeDodati);
            Uslikaj = new RelayCommand<object>(uslikaj);
            PočniSlikanje = new RelayCommand<object>(počniSlikanje);
            Prihvati = new RelayCommand<object>(prihvati);
            PrihvaćenaSlikaByte = pvm.PrihvaćenaSlikaByte;
            Validacija = "";

        }

        public void prihvati(object param)
        {
            PrihvaćenaSlikaByte = SlikaByte;
            NavigationService.Navigate(typeof(ProdajaRegistrovaniKupac), new ProdajaRegistrovaniKupacViewModel(this));
        }

        public void počniSlikanje(object param)
        {
            NavigationService.Navigate(typeof(SlikanjeDijela), new ProdajaRegistrovaniKupacViewModel(this));
                        

        }

        public async void uslikaj(object parametar)
        {
            await Camera.TakePhotoAsync(SlikanjeGotovo);
        }

        public async void SlikanjeGotovo(SoftwareBitmapSource nova)
        {
            SlikaByte = Camera.SlikaByte;
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

            await Slika_op.WriteAsync(SlikaByte.AsBuffer());
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


        void ponudi(object parametar)
        {
            var db = new OtpadDbContext();
            try
            {
                Dio NoviDio = new Dio(IzabranaNarudžba, decimal.Parse(Cijena));
                NoviDio.Slika = PrihvaćenaSlikaByte;
                db.Dijelovi.Add(NoviDio);
                db.NarudzbeDijelova.Remove(IzabranaNarudžba);
                db.SaveChanges();
                IzabranaNarudžba = null;
                Validacija = "";

                NotifyPropertyChanged("SveNarudzbe");
                NotifyPropertyChanged("Validacija");
            }
            catch(Exception ex)
            {
                Validacija = "Niste unijeli ispravnu cijenu.";
                NotifyPropertyChanged("Validacija");


            }
        }


        bool mozeLiSeDodati(object parametar)
        {
            return true;
        }

    }
}
