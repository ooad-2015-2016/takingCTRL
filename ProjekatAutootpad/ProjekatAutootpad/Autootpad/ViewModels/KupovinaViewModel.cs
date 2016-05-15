using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class KupovinaViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public String _izabrana;
        public String Izabrana { get { return _izabrana; } set{ _izabrana = value; NotifyPropertyChanged("SviDijelovi"); } }

        public Korisnik User { get; set; }
        //public 
        private String _trazeni;
        public String Trazeni { get { return _trazeni; } set { _trazeni = value; NotifyPropertyChanged("SviDijelovi"); NotifyPropertyChanged("Dummy"); } }
        public List<Dio> SviDijelovi { get
            {

                using (var db = new OtpadDbContext())
                {
                    if (Izabrana == "Svi")
                        return db.Dijelovi.Where(x => x.Model.StartsWith(Trazeni) && x.UProdaji).ToList();
                    else
                        return db.Dijelovi.Where(x=>x.UProdaji).Where(x => x.Model.StartsWith(Trazeni)).Where(x=>x.Proizvodjac==Izabrana).ToList();

                }
            }
        }
        
        public List<String> Proizvodjaci { get
            {

                List<String> _proizvodjaci = new List<string>();
                _proizvodjaci.Add("Svi");

                foreach(Dio d in SviDijelovi)
                    _proizvodjaci.Add(d.Proizvodjac);

                _proizvodjaci.Add("test");

                return _proizvodjaci.Distinct().ToList();
            }
             set
            {
            }
        }

        public List<Dio> Narudzba { get; set; }
        
        public KupovinaViewModel(PocetnaViewModel pvm)
        {
            User = pvm.User;
            _trazeni = "";
            _izabrana = "Svi";
        }

    }
}
