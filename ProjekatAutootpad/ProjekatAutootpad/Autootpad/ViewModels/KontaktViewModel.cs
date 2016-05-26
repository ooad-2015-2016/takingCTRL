using ProjekatAutootpad.Autootpad.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Calls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Contacts;


namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class KontaktViewModel
    {
        private string _telefon;
        public string Telefon
        {
            get
            {
                string vrati = "";
                for (int i = 0; i < _telefon.Length; ++i)
                {
                    vrati += _telefon[i];
                    if ((i + 1) % 3 == 0 && i != _telefon.Length - 1)
                        vrati += '-';

                }
                return vrati;
            }
            set
            {
                _telefon = value;
            }
        }
        public string Adresa { get; set; }
        public string Email { get; set; }

        public ICommand Nazovi { get; set; }
        

        public KontaktViewModel(PocetnaViewModel pvm)
        {
            Telefon = "062361430";
            Adresa = "Izmišljena ulica BB";
            Email = "ibro-autootpad@gmail.com";
            Nazovi = new RelayCommand<object>(nazovi);
        }

        async void nazovi(object param)
        {
            PhoneCallStore PhoneCallStore = await PhoneCallManager.RequestStoreAsync();
            Guid LineGuid = await PhoneCallStore.GetDefaultLineAsync();

            PhoneLine pl = await PhoneLine.FromIdAsync(LineGuid);
            pl.Dial(_telefon, "Ibro autootpad");
        }
    }
}
