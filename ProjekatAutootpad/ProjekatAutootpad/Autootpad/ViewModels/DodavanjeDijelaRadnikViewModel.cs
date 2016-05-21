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
        public bool QR { get; set; }

        

        


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


        public async void dodaj(object p)
        {
            using (var db = new OtpadDbContext())
            {
                IzabraniDio.UProdaji = true;
                db.Dijelovi.Update(IzabraniDio);
                
                if (QR)
                { 
                String MiniQRApiUrl = String.Format("http://miniqr.com/api/create.php?api=http&content={0}&size=150&rtype=json", ("Proizvodjac: " + IzabraniDio.Proizvodjac + "\nModel: " + IzabraniDio.Model + "\nDio: " + IzabraniDio.ImeDijela + "\nCijena: " + IzabraniDio.ProdajnaCijena.ToString()).Replace(" ", "%20").Replace("\n", "%0A"));

                Uri StartUri = new Uri(MiniQRApiUrl);

                HttpClient httpClient = new HttpClient();
                string response = await httpClient.GetStringAsync(StartUri);
                
                JsonObject val = JsonValue.Parse(response).GetObject();
                string URLSlike = val.GetNamedString("imageurl");
                URLSlike.Replace('\\', '/');
                
                HttpWebRequest req = (HttpWebRequest) WebRequest.Create(URLSlike);
                
                WebResponse resp = await req.GetResponseAsync();

                if(req.HaveResponse)
                {
                    Stream receiveStream = resp.GetResponseStream();
                        using (BinaryReader br = new BinaryReader(receiveStream))
                        {
                            IzabraniDio.QR = br.ReadBytes(500000);
                            br.Dispose();
                        }

                    FileSavePicker fsp = new FileSavePicker();
                    fsp.FileTypeChoices.Add("PNG", new List<String>() { ".png" });
                    fsp.SuggestedFileName = "QR " + IzabraniDio.ImeDijela;
                    
                    StorageFile f = await fsp.PickSaveFileAsync();

                    await FileIO.WriteBytesAsync(f, IzabraniDio.QR);
                 
                    }
                }

                NotifyPropertyChanged("SviDijelovi");

                IzabraniDio = null;
                db.SaveChanges();
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
