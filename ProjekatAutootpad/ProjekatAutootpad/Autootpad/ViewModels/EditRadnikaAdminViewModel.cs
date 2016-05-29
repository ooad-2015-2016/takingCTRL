using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Data.Json;
using Windows.Storage;
using Windows.Storage.Pickers;

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
        public ICommand QR { get; set; }
        public string Verifikacija { get; set; }

        public EditRadnikaAdminViewModel(AdminPogledUposlenikaViewModel apuvm)
        {
            EditovaniRadnik = apuvm.KliknutiRadnik;
            Ažuriraj = new RelayCommand<object>(ažuriraj);
            QR = new RelayCommand<object>(qr);
            Verifikacija = "";
        }

        public async void qr(object param)
        {
            String MiniQRApiUrl = String.Format("http://miniqr.com/api/create.php?api=http&content={0}&size=150&rtype=json", ("Radnik: " + EditovaniRadnik.imePrezime + "\nUsername: " + EditovaniRadnik.Username + "\nEmail: " + EditovaniRadnik.Email).Replace(" ", "%20").Replace("\n", "%0A"));

            Uri StartUri = new Uri(MiniQRApiUrl);

            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(StartUri);

            JsonObject val = JsonValue.Parse(response).GetObject();
            string URLSlike = val.GetNamedString("imageurl");
            URLSlike.Replace('\\', '/');

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URLSlike);

            WebResponse resp = await req.GetResponseAsync();

            byte[] slika;

            if (req.HaveResponse)
            {
                Stream receiveStream = resp.GetResponseStream();
                using (BinaryReader br = new BinaryReader(receiveStream))
                {
                    slika = br.ReadBytes(500000);
                    br.Dispose();
                }

                FileSavePicker fsp = new FileSavePicker();
                fsp.FileTypeChoices.Add("PNG", new List<String>() { ".png" });
                fsp.SuggestedFileName = "QR " + EditovaniRadnik.Username;

                StorageFile f = await fsp.PickSaveFileAsync();

                await FileIO.WriteBytesAsync(f, slika);
            }
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
