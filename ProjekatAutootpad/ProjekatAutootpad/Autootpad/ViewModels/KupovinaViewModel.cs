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
        public String Izabrana { get { return _izabrana; } set { _izabrana = value; NotifyPropertyChanged("SviDijelovi"); } }

        public Kupac User { get; set; }
        //public 
        private String _trazeni;
        public String Trazeni { get { return _trazeni; } set { _trazeni = value; NotifyPropertyChanged("SviDijelovi"); NotifyPropertyChanged("Dummy"); } }
        public List<Dio> SviDijelovi { get
            {

                using (var db = new OtpadDbContext())
                {
                    return db.Dijelovi.Where(x => x.UProdaji).Where(x => x.Model.StartsWith(Trazeni)).Where(x => x.Proizvodjac == Izabrana).ToList();

                }
            }
        }

        public List<String> Proizvodjaci { get
            {

                List<String> _proizvodjaci = new List<string>();
                List<Dio> _dijelovi;

                using (var db = new OtpadDbContext())
                    _dijelovi = db.Dijelovi.ToList();

                foreach (Dio d in _dijelovi)
                    _proizvodjaci.Add(d.Proizvodjac);

                return _proizvodjaci.Distinct().ToList();
            }
            set
            {
            }
        }

        private decimal _cijena;

        private bool _sUgradnjom;

        public bool SUgradnjom
        {
            get { return _sUgradnjom; }
            set {
                _sUgradnjom = value;

                _cijena = _izabraniDio.ProdajnaCijena;

                if (SUgradnjom)
                    _cijena += 75M;

                if (User.jeliPenzioner)
                    _cijena -= 0.1m * _cijena;

                CijenaTekst = "Cijena: " + _cijena.ToString();
            }
        }

        private string _cijenaTekst;
        public string CijenaTekst
        {
            set { _cijenaTekst = value;
                NotifyPropertyChanged("CijenaTekst");
            }
            get { return _cijenaTekst; }
        }

        //public List<Dio> Narudzba { get; set; }
        private Dio _izabraniDio;

        public Dio IzabraniDio
        {
            get
            {
                return _izabraniDio;
            }
            set
            {
                _izabraniDio = value;
                _cijena = _izabraniDio.ProdajnaCijena;

                if (SUgradnjom)
                    _cijena += 75M;

                if (User.jeliPenzioner)
                    _cijena -= 0.1m * _cijena;

                CijenaTekst = "Cijena: " + _cijena.ToString();

            }
        }
        
        public KupovinaViewModel(PocetnaViewModel pvm)
        {
            User = pvm.User;
            _trazeni = "";
            _izabrana = "Svi";
            _cijena = 0.0m;
            _cijenaTekst = "";
            _sUgradnjom = false;
        }

    }
}
